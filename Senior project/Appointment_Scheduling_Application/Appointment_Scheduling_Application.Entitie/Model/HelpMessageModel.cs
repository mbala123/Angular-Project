using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class HelpMessageModel
    {
       
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
