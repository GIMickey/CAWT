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
    /// Interaction logic for Participants.xaml
    /// </summary>
    public partial class Participants : Window
    {
        public Participants()
        {
            InitializeComponent();
        }

        //navigates user to add participants window
        private void BtnAddParticipant_Click(object sender, RoutedEventArgs e)
        {
            AddParticipant add = new AddParticipant();
            add.Show();
            this.Close();
        }

        //selects all participants in the participant table and displays them on a datagrid
        private void BtnViewParticipant_Click(object sender, RoutedEventArgs e)
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

        //navigates user to update participant window
        private void BtnUpdateParticipant_Click(object sender, RoutedEventArgs e)
        {
            UpdateParticipant update = new UpdateParticipant();
            update.Show();
            this.Close();

        }

        //navigates user to remove a participant window
        private void BtnRemoveParticipant_Click(object sender, RoutedEventArgs e)
        {
            RemoveParticipant remove = new RemoveParticipant();
            remove.Show();
            this.Close();

        }

        //navigates user to login page
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        //navigates user to the main windows (home page)
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
