using Assessment_Youssef_Elsayed.Data;
using Assessment_Youssef_Elsayed.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class DoctorPage : Window
    {
        Users User;
        SystemContext context = new SystemContext();
        public ObservableCollection<Appointments> AppointmentsCollection {  get; set; }
        Appointments selected {  get; set; }
        public DoctorPage(Users user)
        {
            InitializeComponent();
            User=user;
            MessageBox.Show($"Welcome Dr.{User.UserName}");
            ShowDocApp();
        }
        private void ShowDocApp()
        {
            AppointmentsCollection = new ObservableCollection<Appointments>(context.Appointments.Where(a=>a.AppDay == "Sunday").Include(i=>i.User).Where(a=>a.DoctorId == User.UserId).ToList());
            AppointmentsDataGrid.ItemsSource= AppointmentsCollection;
        }

        private void AppointmentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AppointmentsDataGrid.SelectedItem is Appointments App)
            {
                selected = App;
                StatusBox.Text=App.AppStatus;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selected != null)
            {
                selected.AppStatus = StatusBox.Text;
                context.SaveChanges();
                ShowDocApp();
                MessageBox.Show("Appointment Status Updated Successful");
            }
            else
            {
                MessageBox.Show("Select Appointment To Update");
            }
        }
    }
}
