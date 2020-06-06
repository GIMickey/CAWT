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
    /// Interaction logic for AddParticipant.xaml
    /// </summary>
    public partial class AddParticipant : Window
    {
        public AddParticipant()
        {
            InitializeComponent();
        }

        //connects to the database and inputs text from the textboxes into the database
        private void BtnAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //creates a temporary location to store data before moving it to the database
                int id = Convert.ToInt32(txtParticipantID.Text);
                string FirstName = txtFirstName.Text;
                string Surname = txtSurname.Text;
                string Address1 = txtAddress1.Text;
                string Address2 = txtAddress2.Text;
                string Town = txtTown.Text;
                string County = txtCounty.Text;
                string Postcode = txtPostcode.Text;
                string ContactNo = txtContactNo.Text;
                string DOB = txtDOB.Text;

                //inserts values from the above varibles into the database
                string query = "Insert into Participants(ParticipantID, FirstName, Surname, Address1, Address2, Town, County, Postcode, ContactNo,DOB) Values " +
                    "(" + id + ", '" + FirstName + "', '" + Surname + "', '" + Address1 + "', '" + Address2 + "', '" + Town + "', '" + County + "', '" + Postcode + "', '" + ContactNo + "', '" + DOB + "')";

                //Opens a connection to the database and executes its query
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client Successfully added");
                conn.Close();

                Participants participant = new Participants();
                participant.Show();
                this.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter some details");
            }

        }

        //navigates user to the login window
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //navigates user to the admin home window
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        //navigates user back to previous window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Participants back = new Participants();
            back.Show();
            this.Close();
        }
    }
}
