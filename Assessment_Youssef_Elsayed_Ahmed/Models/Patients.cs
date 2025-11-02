using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Youssef_Elsayed.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PatientNotes { get; set; }
        public ICollection<Appointments> Aappointments { get; set; }
    }
}
