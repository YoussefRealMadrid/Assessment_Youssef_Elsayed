using Assessment_Youssef_Elsayed.Data;
using Assessment_Youssef_Elsayed.Models;
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
    public partial class AddPatient : Window
    {
        SystemContext context = new SystemContext();
        Users User;
        public AddPatient(Users user)
        {
            InitializeComponent();
            User = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(Patientnametext.Text) || string.IsNullOrEmpty(Patientnumbertext.Text) || string.IsNullOrEmpty(Patientdateofbirthtext.Text))
            {
                MessageBox.Show("Please Enter The patient information fully");
            }
            else
            {
                string pname = Patientnametext.Text;
                string pnumber = Patientnumbertext.Text;
                DateOnly pdob = DateOnly.Parse(Patientdateofbirthtext.Text);
                string pnotes = Patientnotestext.Text;
                Patients patient = new Patients
                {
                    PatientName=pname,
                    PatientPhone=pnumber,
                    DateOfBirth=pdob,
                    PatientNotes=pnotes
                };
                context.Patients.Add(patient);
                context.SaveChanges();
                MessageBox.Show("Patient Added Successfully");
                AppointmentScheduling appointmentScheduling = new AppointmentScheduling(User);
                appointmentScheduling.Show();
                this.Close();
            }
        }
    }
}
