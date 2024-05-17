using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class MailStatusModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int MailId { get; set; }
        [Required]
        public string MailStatus { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
