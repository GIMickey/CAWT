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
    /// Interaction logic for UserMakeAppointment.xaml
    /// </summary>
    public partial class UserMakeAppointment : Window
    {
        public UserMakeAppointment()
        {
            InitializeComponent();
        }

        //selects all data from appointments table and dispalys on the datagrid
        private void BtnViewAppointment_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Appointments";
           
            //opens database connection
            SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3; ");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            //loads data into the datagrid
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgAppointments.DataContext = dt;

            reader.Close();
            conn.Close();
        }

        //creates an appointment and loads data into the appointments table on the database
        private void BtnMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //creates a temporary storage location the users inputs
                int id = Convert.ToInt32(txtAppointmentID.Text);
                string Time = txtTime.Text;
                string Date = txtDate.Text;
                string Location = txtLocation.Text;
                int Sid = Convert.ToInt32(txtStaffID.Text);
                int Pid = Convert.ToInt32(txtParticipantID.Text);

                //inserts query that inserts the data into the appointments table on the database
                string query = "Insert into Appointments(AppointmentID, Time, Date, Location, StaffID, ParticipantID) Values " +
                    "(" + id + ", '" + Time + "', '" + Date + "', '" + Location + "', " + Sid + ", " + Pid + ")";

                //opens the database connection
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment Successfully added");
                conn.Close();

                //navigates the user back to the participants view window after the insert is complete
                ParticipantsView back = new ParticipantsView();
                back.Show();
                this.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter valid appointment details");
            }
        }
        //navigates user to the login window
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        // navigates user back to the participants view window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ParticipantsView back = new ParticipantsView();
            back.Show();
            this.Close();
        }
    }
}
