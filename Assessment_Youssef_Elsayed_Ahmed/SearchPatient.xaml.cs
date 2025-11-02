using Assessment_Youssef_Elsayed.Data;
using Assessment_Youssef_Elsayed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assessment_Youssef_Elsayed
{
    public partial class SearchPatient : Window
    {
        Users User;
        SystemContext context = new SystemContext();
        public SearchPatient(Users user)
        {
            InitializeComponent();
            User=user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SearchedName = PatientNameBox.Text;
            var WantedPatient=context.Patients.Where(p=>p.PatientName ==  SearchedName).Include(p=>p.Aappointments).FirstOrDefault();
            if (WantedPatient != null)
            {
                MessageBox.Show("Patient Found");
                MessageBox.Show($"Patient Id={WantedPatient.PatientId}, Patient Name: {WantedPatient.PatientName}");
                MessageBox.Show($"Patient Date Of Birth {WantedPatient.DateOfBirth} Patient Notes: {WantedPatient.PatientNotes}");
                MessageBox.Show("his Appointments");
                if(WantedPatient.Aappointments.Count == 0)
                {
                    MessageBox.Show("He Has No Appointments");
                }
                else
                {
                    foreach (var i in WantedPatient.Aappointments)
                    {
                        MessageBox.Show($"Appointment Id:{i.AppId}");
                        MessageBox.Show($"Appointment Doctor Id: {i.DoctorId}");
                        MessageBox.Show($"$Appointment Date: {i.AppDateTime}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Patient Not Found Try Again");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppointmentScheduling appointmentScheduling = new AppointmentScheduling(User);
            appointmentScheduling.Show();
            this.Close();
        }
    }
}
