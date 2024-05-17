using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class RecoveryModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Question { get; set; }
        [Required]
        [StringLength(50)]
        public string Answer { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
