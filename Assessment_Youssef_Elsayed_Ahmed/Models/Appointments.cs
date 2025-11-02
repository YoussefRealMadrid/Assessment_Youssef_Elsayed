using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Youssef_Elsayed.Models
{
    public class Appointments
    {
        [Key]
        public int AppId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppDateTime { get; set; }
        [Required]
        public string AppReason { get; set; }
        public string AppStatus { get; set; }
        public string AppDay { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Users User { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patients Patient { get; set; }

    }
}
