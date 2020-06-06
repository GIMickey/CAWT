using System;
using System.Data;
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
    /// Interaction logic for DeleteAppointment.xaml
    /// </summary>
    public partial class DeleteAppointment : Window
    {
        public DeleteAppointment()
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
        //user enters an id number to delete appointment from the appointments table
        private void BtnDeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //creates a temporary location to store id number
                int AppointmentNo = Convert.ToInt32(txtAppointmentID.Text);
                //creates 2 querys to select and delete from the database using id number
                string query1 = "select AppointmentID from Appointments where AppointmentID = " + AppointmentNo + " ";
                string query2 = "delete from Appointments where AppointmentID = " + AppointmentNo + " ";
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3; ");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query1, conn);

                SQLiteDataReader reader = cmd.ExecuteReader();
                //checks if the id number is valid and deletes it from the appointments table
                if (reader.HasRows)
                {
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, conn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Appointment has been deleted");
                }
                //no id exists and lets user know
                else
                {
                    MessageBox.Show("No Appointment exists with that number");
                }

                //closes the reader and the connection and navigates back to the appointments window
                reader.Close();
                conn.Close();

                Appointments back = new Appointments();
                back.Show();
                this.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter a valid appointment to be deleted");
            }
        }
    }
}
