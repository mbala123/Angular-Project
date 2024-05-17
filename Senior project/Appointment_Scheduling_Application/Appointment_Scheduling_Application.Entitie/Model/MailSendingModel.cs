using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class MailSendingModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int userId { get; set; }
        [Required]
        [StringLength(50)]
        public string From { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string CC { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        //public virtual MailStatusModel MailStatusModel { get; set; }
        public virtual ToParticipant ToParticipant { get; set; }
    }
    public class ToParticipant
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int UserId { get; set; }
        [Required]
        public string To { get; set; }
    }
}
