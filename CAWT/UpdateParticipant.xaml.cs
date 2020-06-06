using System.Data;
using System.Data.SQLite;
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
    /// Interaction logic for UpdateParticipant.xaml
    /// </summary>
    public partial class UpdateParticipant : Window
    {
        public UpdateParticipant()
        {
            InitializeComponent();
        }

        //querys the participants table in the database and displays all information on a datagrid
        private void BtnViewParticipantDetails_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Participants";
            SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3; ");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgParticipants.DataContext = dt;

            reader.Close();
            conn.Close();
        }

        //moves the information displayed on the datagrid to its corresponding textbox
        private void DgParticipants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView rowSelected = dg.SelectedItem as DataRowView;
            if (rowSelected !=null)
            {
                txtParticipantID.Text = rowSelected["ParticipantID"].ToString();
                txtFirstName.Text = rowSelected["FirstName"].ToString();
                txtSurname.Text = rowSelected["Surname"].ToString();
                txtAddress1.Text = rowSelected["Address1"].ToString();
                txtAddress2.Text = rowSelected["Address2"].ToString();
                txtTown.Text = rowSelected["Town"].ToString();
                txtCounty.Text = rowSelected["County"].ToString();
                txtPostcode.Text = rowSelected["Postcode"].ToString();
                txtContactNo.Text = rowSelected["ContactNo"].ToString();
                txtDOB.Text = rowSelected["DOB"].ToString();
            }
        }

        //updates existing records on the database
        private void BtnUpdateParticipantDetails_Click(object sender, RoutedEventArgs e)
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

                //updates values from the above varibles into the database
                string query = "Update Participants set FirstName = '" + FirstName + "', Surname = '" + Surname + "', Address1 = '" + Address1 + "', Address2 = '" + Address2 + "', Town = '" + Town + "', County = '" + County + "', Postcode = '" + Postcode + "', ContactNo = '" + ContactNo + "', DOB = '" + DOB + "' " +
                    "where ParticipantID = " + id + "";

                //Opens a connection to the database and executes its query
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Participants Details have been Successfully updated");
                conn.Close();

                Participants participant = new Participants();
                participant.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter some details to update participant");
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

        //navigates user to the participant window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Participants back = new Participants();
            back.Show();
            this.Close();
        }
    }
}
