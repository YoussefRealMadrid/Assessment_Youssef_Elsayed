using Assessment_Youssef_Elsayed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Youssef_Elsayed.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext() { }
        public SystemContext(DbContextOptions options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=COM170-LAB3\\SQLEXPRESS;Initial Catalog=Medical_Appointment_Booking_System;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
