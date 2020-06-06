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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {
        public UpdateAppointment()
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
        //navigates the user to the admin home window
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        //navigates the user back to the appointments window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Appointments back = new Appointments();
            back.Show();
            this.Close();
        }
        //selects all data in the appointments table and displays on a datagrid
        private void BtnViewAppointments_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Appointments";
            SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3; ");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgAppointments.DataContext = dt;
            reader.Close();
            conn.Close();
        }
        //allows a user to update exisiting appointments
        private void BtnUpdateAppointment_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //temp location for values before being stored in the database
                int id = Convert.ToInt32(txtAppointmentID.Text);
                string Time = txtTime.Text;
                string Date = txtDate.Text;
                string Location = txtLocation.Text;
                int Sid = Convert.ToInt32(txtStaffID.Text);
                int Pid = Convert.ToInt32(txtParticipantID.Text);

                //updates the database with new values to overwrite the old values
                string query = "Update Appointments set Time = '" + Time + "', Date = '" + Date + "', Location = '" + Location + "', StaffID = " + Sid + ", ParticipantID = " + Pid + " " +
                    "where AppointmentID = " + id + "";

                //opens database connections and excutes the query
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Appointment Successfully Updated");
                //closes the connection to the database
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Please enter some details to update appointment");
            }
        }

        //passes all information on the datagrid to the coresponding textboxes
        private void DgAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView rowSelected = dg.SelectedItem as DataRowView;
            if (rowSelected != null)
            {
                txtAppointmentID.Text = rowSelected["AppointmentID"].ToString();
                txtTime.Text = rowSelected["Time"].ToString();
                txtDate.Text = rowSelected["Date"].ToString();
                txtLocation.Text = rowSelected["Location"].ToString();
                txtStaffID.Text = rowSelected["StaffID"].ToString();
                txtParticipantID.Text = rowSelected["ParticipantID"].ToString();
            }
        }
    }
}
