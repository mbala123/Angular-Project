using System;
using System.ComponentModel.DataAnnotations;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class UserModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserRoleId { get; set; }
        [Required]
        public byte[] Profile { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,13}", ErrorMessage = "Invalid FirstName")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,13}", ErrorMessage = "Invalid LasrName")]
        public string LastName { get; set; }
        [Required]
       //[RegularExpression(@"[A-Za-z@$!%*#?&]{8,10}", ErrorMessage = "Password requirements not met")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public bool IsEmailConfirmed { get; set; }
        [Required]
        [RegularExpression(@".{10,13}", ErrorMessage = "Invalid phone number")]
        public long PhoneNumber { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool ExistingOrNot { get; set; }


        //public virtual RecoveryModel RecoveryModel { get; set; }
        //public virtual MailSendingModel MailSendingModel { get; set; }
        //public virtual AppointmentModel AppointmentModel { get; set; }
        //public virtual TotalAppointmentModel TotalAppointmentModel { get; set; }
        //public virtual TotalMeetingTimeModel TotalMeetingTimeModel { get; set; }
    }
}
