using Appointment_Scheduling_Application.Entitie.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Appointment_Scheduling_Application.Repositories.Base
{
    public class Appointment_Scheduling_Application_DbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=ZSCHN01LP0425;user=sa;password=Password@1;database=Appointment_scheduling");
        }


        public DbSet<AppointmentModel> AppointmentModels { get; set; } = default!;

        public DbSet<TotalAppointmentModel> TotalAppointmentModels { get; set; } = default!;

        public DbSet<TotalMeetingTimeModel > TotalMeetingTimeModels { get; set; } = default!;

        public DbSet<MailSendingModel> MailSendingModels { get; set; } = default!;

        public DbSet<MailStatusModel> MailStatusModels { get; set; } = default!;

        public DbSet<RecoveryModel> RecoveryModels { get; set; } = default!;

        //public DbSet<UserModel> UserModels { get; set; } = default!;

        public DbSet<Participant> participants { get; set; } = default!;

        public DbSet<HelpMessageModel> helpMessageModels { get; set; } = default!;

        public DbSet<ProfileImageModel> profileImageModels { get; set; } = default!;
    }
}
