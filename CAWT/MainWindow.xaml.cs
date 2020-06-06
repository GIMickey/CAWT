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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CAWT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //navigates user to Participants window
        private void BtnParticipants_Click(object sender, RoutedEventArgs e)
        {
            Participants participant = new Participants();
            participant.Show();
            this.Close();
        }

        //navigates user to login window
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();      
        }

        //navigates user to appointments window
        private void BtnManageAppointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments appointment = new Appointments();
            appointment.Show();
            this.Close();
        }
    }
}
