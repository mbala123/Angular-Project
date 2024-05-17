using Appointment_Scheduling_Application.Repositories.Base;
using Appointment_Scheduling_Application.Repositories.Repositories;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Appointment_Scheduling_Application.Services.Auth_Services;
using Appointment_Scheduling_Application.Services.MailSendingService;
using Appointment_Scheduling_Application.Services.Mapping;
using Appointment_Scheduling_Application.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




#region Services
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ITotalAppointmentServices, TotalAppointmentServices>();
builder.Services.AddScoped<ITotalMeetingTimeServices, TotalMeetingTimeServices>();
builder.Services.AddScoped<IRecoveryServices, RecoveryServices>();
builder.Services.AddScoped<IMailStatusServices, MailStatusServices>();
builder.Services.AddScoped<IMailSendingServices, MailSendingServices>();
builder.Services.AddScoped<IAppointmentServices, AppointmentServices>();
builder.Services.AddScoped<IMailNoticationSendingService, MailNoticationSendingService>();
builder.Services.AddScoped<IProfileImageService, ProfileImageService>();
builder.Services.AddScoped<IManualMapper, ManualMapper>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
#endregion


#region Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITotalAppointmentRepository, TotalAppointmentRepository>();
builder.Services.AddScoped<ITotalMeetingTimeRepository, TotalMeetingTimeRepository>();
builder.Services.AddScoped<IRecoveryRepository, RecoveryRepository>();
builder.Services.AddScoped<IMailStatusRepository, MailStatusRepository>();
builder.Services.AddScoped<IMailSendingRepository, MailSendingRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHelpMessageRepository, HelpMessageRepository>();
builder.Services.AddScoped<IProfileImageRepository, ProfileImageRepository>();
#endregion


#region UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion


#region DbContext
builder.Services.AddScoped<Appointment_Scheduling_Application_DbContext>();

#endregion


#region Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Appointment_Scheduling_Application_DbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);


    options.SignIn.RequireConfirmedEmail = true;


});
#endregion


#region log configuratio
var _logger = new LoggerConfiguration().WriteTo.File("D:\\ASSESMENT PROJECT\\Appointment_Scheduling_Application\\Log_files\\LoggingFileAPI.log", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Logging.AddSerilog(_logger);
#endregion


#region Mapper Configuration
builder.Services.AddAutoMapper(typeof(Program).Assembly);
#endregion


#region Angular Connection
builder.Services.AddCors(options => options.AddPolicy(name: "LoginOrigins",

               policy =>
               {
                   policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
               }
               )
               );
#endregion


#region JWT Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0123456789ABCDEF"))
    };
});

#endregion


#region Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});



#endregion


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("LoginOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
