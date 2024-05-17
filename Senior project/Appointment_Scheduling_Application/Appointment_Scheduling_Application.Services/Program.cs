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
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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


#region Services
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ITotalAppointmentServices, TotalAppointmentServices>();
builder.Services.AddTransient<ITotalMeetingTimeServices, TotalMeetingTimeServices>();
builder.Services.AddTransient<IRecoveryServices, RecoveryServices>();
builder.Services.AddTransient<IMailStatusServices, MailStatusServices>();
builder.Services.AddTransient<IMailSendingServices, MailSendingServices>();
builder.Services.AddTransient<IAppointmentServices, AppointmentServices>();
builder.Services.AddTransient<IMailNoticationSendingService, MailNoticationSendingService>();
builder.Services.AddTransient<IManualMapper, ManualMapper>();
builder.Services.AddTransient<IProfileImageService, ProfileImageService>();
builder.Services.AddTransient<IAuthServices, AuthServices>();
builder.Services.AddTransient<IJwtService, JwtService>();
#endregion


#region Mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(50);


    options.SignIn.RequireConfirmedEmail = true;


});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
