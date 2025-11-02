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
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        SystemContext context = new SystemContext();
        Users User;
        public AddAppointment(Users user)
        {
            InitializeComponent();
            User=user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(PatientIdbox.Text) 
                || string.IsNullOrEmpty(DoctorIdbox.Text) 
                || string.IsNullOrEmpty(AppDatebox.Text) 
                || string.IsNullOrEmpty(AppDaybox.Text)
                || string.IsNullOrEmpty(AppReasonbox.Text)
                || string.IsNullOrEmpty(AppStatusbox.Text))
            {
                MessageBox.Show("Please Fill in All the spaces");
            }
            else
            {
                int pid = int.Parse(PatientIdbox.Text);
                int docid = int.Parse(DoctorIdbox.Text);
                DateTime Apdate = DateTime.Parse(AppDatebox.Text);
                string AppDay = AppDaybox.Text;
                string Appreason = AppReasonbox.Text;
                string AppStatus = AppStatusbox.Text;
                Appointments appointment = new Appointments
                {
                    PatientId=pid,
                    DoctorId=docid,
                    AppDateTime=Apdate,
                    AppDay=AppDay,
                    AppReason=Appreason,
                    AppStatus=AppStatus
                };
                context.Appointments.Add(appointment);
                context.SaveChanges();
                MessageBox.Show("Appoinment Added Successfully");
                AppointmentScheduling appointmentScheduling = new AppointmentScheduling(User);
                appointmentScheduling.Show();
                this.Close();
            }
        }
    }
}
