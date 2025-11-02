using Assessment_Youssef_Elsayed.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assessment_Youssef_Elsayed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SystemContext context = new SystemContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = UsernameBox.Text;
            string password = UserPassBox.Password;
            if(string.IsNullOrEmpty(name)  || string.IsNullOrEmpty(password))
            {
                txterror.Text = "Please Enter Username Or Password";
            }
            else
            {
                var user=context.Users.FirstOrDefault(x=> x.UserName == name && x.UserPassword==password);
                if(user != null)
                {
                    if(user.UserRole == "Receptionist")
                    {
                        AppointmentScheduling appointmentScheduling = new AppointmentScheduling(user);
                        appointmentScheduling.Show();
                    }
                    else
                    {
                        DoctorPage doctorPage = new DoctorPage(user);
                        doctorPage.Show();
                    }
                    this.Close();
                }
                else
                {
                    txterror.Text = "Invalid Username or Password";
                }
            }
        }
    }
}