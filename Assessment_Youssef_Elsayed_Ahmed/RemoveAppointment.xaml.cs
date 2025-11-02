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
    public partial class RemoveAppointment : Window
    {
        SystemContext context = new SystemContext();
        public ObservableCollection<Appointments> AppointmentsCollection { get; set; }
        Users User;
        public RemoveAppointment(Users user)
        {
            InitializeComponent();
            User = user;
            ShowApps();
        }
        private void ShowApps()
        {
            AppointmentsCollection = new ObservableCollection<Appointments>(context.Appointments.ToList());
            AppointmentsDataGrid.ItemsSource = AppointmentsCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(AppointmentsDataGrid.SelectedItem is Appointments app)
            {
                context.Appointments.Remove(app);
                context.SaveChanges();
                AppointmentsCollection.Remove(app);
                MessageBox.Show("Appointment Removed Successful");
            }
            else
            {
                MessageBox.Show("Please Select A Appointment To Remove");
            }
        }
    }
}
