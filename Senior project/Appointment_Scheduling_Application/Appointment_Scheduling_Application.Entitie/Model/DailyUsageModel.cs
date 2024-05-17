using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class TotalMeetingTimeModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int Userid { get; set; }
        [Required]
        public string TimeSpended { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
    public class  TotalAppointmentModel
    {
        [Required]
        [Key]

        public int Id { get; set; }
        [Required]
        [ForeignKey("Id")]
        public int Userid { get; set; }
        [Required]
        public int AppointmentCount { get; set;}
        [Required]
        public DateTime DateTime { get; set; }
    }

}
