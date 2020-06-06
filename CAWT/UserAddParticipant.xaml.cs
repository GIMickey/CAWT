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
    /// Interaction logic for UserAddParticipant.xaml
    /// </summary>
    public partial class UserAddParticipant : Window
    {
        public UserAddParticipant()
        {
            InitializeComponent();
        }

        //users adds a new participant to the database
        private void BtnAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //temporary storage location for database columns
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
                //query that then inserts user inputs from the textboxes to the database
                string query = "Insert into Participants(ParticipantID, FirstName, Surname, Address1, Address2, Town, County, Postcode, ContactNo,DOB) Values " +
                    "(" + id + ", '" + FirstName + "', '" + Surname + "', '" + Address1 + "', '" + Address2 + "', '" + Town + "', '" + County + "', '" + Postcode + "', '" + ContactNo + "', '" + DOB + "')";

                //opens the connection to the datbase
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
                conn.Open();
                //runs the query and the closes the connection to the database
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Client Successfully added");
                conn.Close();
                //navigates the user back to the participants view window after user has been added
                ParticipantsView participant = new ParticipantsView();
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
        //navigates user back to the participants view window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ParticipantsView back = new ParticipantsView();
            back.Show();
            this.Close();
        }
    }
}
