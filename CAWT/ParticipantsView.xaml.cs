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

namespace CAWT
{
    /// <summary>
    /// Interaction logic for ParticipantsView.xaml
    /// </summary>
    public partial class ParticipantsView : Window
    {
        public ParticipantsView()
        {
            InitializeComponent();
        }
        //navigates user to the login window
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        //navigates user tot the user add participant window
        private void BtnParticpantDetails_Click(object sender, RoutedEventArgs e)
        {
            UserAddParticipant add = new UserAddParticipant();
            add.Show();
            this.Close();            
        }
        //navigates user to user make appointment window
        private void BtnMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            UserMakeAppointment make = new UserMakeAppointment();
            make.Show();
            this.Close();
        }
    }
}
