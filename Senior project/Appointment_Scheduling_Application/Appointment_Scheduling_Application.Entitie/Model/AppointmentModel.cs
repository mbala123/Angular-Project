using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class AppointmentModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int UserId { get; set; }
        [Required]
        public string Timeduration { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public virtual Participant Participants { get; set; }
    }
    public class Participant
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int UserId { get; set; }
        [Required]
        public string Participants { get; set; }
    }

}
