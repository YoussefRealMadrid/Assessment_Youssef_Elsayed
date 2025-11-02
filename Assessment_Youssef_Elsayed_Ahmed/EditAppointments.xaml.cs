using Assessment_Youssef_Elsayed.Data;
using Assessment_Youssef_Elsayed.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EditAppointments.xaml
    /// </summary>
    public partial class EditAppointments : Window
    {
        Appointments selectedAppointment { get; set; }
        SystemContext context = new SystemContext();
        Users User;
        public ObservableCollection<Appointments> AppointmentsCollection { get; set; }
        public EditAppointments(Users user)
        {
            InitializeComponent();
            User = user;
            ShowApps();
        }
        private void ShowApps()
        {
            AppointmentsCollection= new ObservableCollection<Appointments>(context.Appointments.ToList());
            AppointmentsDataGrid.ItemsSource = AppointmentsCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectedAppointment != null)
            {
                selectedAppointment.DoctorId = int.Parse(AppDocIdText.Text);
                selectedAppointment.PatientId = int.Parse(AppPatIdText.Text);
                selectedAppointment.AppDateTime = DateTime.Parse(AppDateText.Text);
                selectedAppointment.AppDay = AppDayText.Text;
                selectedAppointment.AppStatus = AppStatText.Text;
                selectedAppointment.AppReason = AppReaText.Text;
                context.SaveChanges();
                ShowApps();
                MessageBox.Show("Appointment Editted Successful");
            }
            else
            {
                MessageBox.Show("Please Select Appointment to Edit");
            }
        }

        private void AppointmentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AppointmentsDataGrid.SelectedItem is Appointments app)
            {
                selectedAppointment = app;
                AppIdText.Text=app.AppId.ToString();
                AppDocIdText.Text=app.DoctorId.ToString();
                AppPatIdText.Text=app.PatientId.ToString();
                AppDateText.Text=app.AppDateTime.ToString();
                AppDayText.Text=app.AppDay.ToString();
                AppStatText.Text=app.AppStatus.ToString();
                AppReaText.Text=app.AppReason.ToString();
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
