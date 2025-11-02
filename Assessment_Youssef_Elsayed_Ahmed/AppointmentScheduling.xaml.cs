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
    /// Interaction logic for AppointmentScheduling.xaml
    /// </summary>
    public partial class AppointmentScheduling : Window
    {
        Users user1;
        public AppointmentScheduling(Users user)
        {
            InitializeComponent();
            user1 = user;
            MessageBox.Show($"Welcome {user1.UserName}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient(user1);
            addPatient.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SearchPatient searchPatient = new SearchPatient(user1);
            searchPatient.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment(user1);
            addAppointment.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RemoveAppointment removeAppointment = new RemoveAppointment(user1);
            removeAppointment.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            EditAppointments editAppointments = new EditAppointments(user1);
            editAppointments.Show();
            this.Close();
        }
    }
}
