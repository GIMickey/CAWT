using System;
using System.Data.SQLite;
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
    /// Interaction logic for MakeAppointment.xaml
    /// </summary>
    public partial class MakeAppointment : Window
    {
        public MakeAppointment()
        {
            InitializeComponent();
        }
        //navigates user to admin home window
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        //navigates user to login window
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        //navigates user back to appointments window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Appointments back = new Appointments();
            back.Show();
            this.Close();
        }
        //submits an appointment to the appointment table on the database
        private void BtnMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //creates temporary location to store values before sending them to the appointment table
                int id = Convert.ToInt32(txtAppointmentID.Text);
                string Time = txtTime.Text;
                string Date = txtDate.Text;
                string Location = txtLocation.Text;
                int Sid = Convert.ToInt32(txtStaffID.Text);
                int Pid = Convert.ToInt32(txtParticipantID.Text);

                //sends data to the database
                string query = "Insert into Appointments(AppointmentID, Time, Date, Location, StaffID, ParticipantID) Values " +
                    "(" + id + ", '" + Time + "', '" + Date + "', '" + Location + "', " + Sid + ", " + Pid + ")";

                //opens connection to the database and executes the query
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment Successfully added");

                //closes the database connections and navigates user back to appointments window
                conn.Close();

                Appointments back = new Appointments();
                back.Show();
                this.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter valid appointment details");
            }
        }
    }
}
