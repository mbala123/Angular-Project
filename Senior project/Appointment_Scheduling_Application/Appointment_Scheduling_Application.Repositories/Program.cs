using Appointment_Scheduling_Application.Repositories.Base;
using Appointment_Scheduling_Application.Repositories.Repositories;
using Appointment_Scheduling_Application.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Repository
builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<ITotalAppointmentRepository, TotalAppointmentRepository>();
builder.Services.AddTransient<ITotalMeetingTimeRepository, TotalMeetingTimeRepository>();
builder.Services.AddTransient<IRecoveryRepository, RecoveryRepository>();
builder.Services.AddTransient<IMailStatusRepository, MailStatusRepository>();
builder.Services.AddTransient<IMailSendingRepository, MailSendingRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IHelpMessageRepository, HelpMessageRepository>();
builder.Services.AddTransient<IProfileImageRepository, ProfileImageRepository>();
#endregion

#region UintOfWork
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
#endregion


#region DbContext
builder.Services.AddTransient<Appointment_Scheduling_Application_DbContext>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
