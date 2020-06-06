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
    /// Interaction logic for RemoveParticipant.xaml
    /// </summary>
    public partial class RemoveParticipant : Window
    {
        public RemoveParticipant()
        {
            InitializeComponent();
        }

        //a button that will remove a selected user from the database using there ID number
        private void BtnRemoveParticipant_Click(object sender, RoutedEventArgs e)
        {
            // A try catch statement that asks the user to input data first
            try
            {
                //creates a temporary save location for ID number
                int participantNo = Convert.ToInt32(txtRemoveParticipant.Text);

                //2 querys that will select a vail id number from the participants table and if valid, delete that participant
                string query1 = "select ParticipantID from Participants where ParticipantID = " + participantNo + " ";
                string query2 = "delete from Participants where ParticipantID = " + participantNo + " ";

                //opens a connection to the database
                SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3; ");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                //if id exists, delete it
                if (reader.HasRows)
                {
                    SQLiteCommand cmd2 = new SQLiteCommand(query2, conn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Participant has been deleted");
                }
                //no id exists, prompt user
                else
                {
                    MessageBox.Show("No Participant exists with that number");
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid Participant to be removed");
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

        //navigates user to the participants window
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Participants back = new Participants();
            back.Show();
            this.Close();
        }
    }
}
