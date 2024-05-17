using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Scheduling_Application.Entitie.Model
{
    public class ProfileImageModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
    }
}
