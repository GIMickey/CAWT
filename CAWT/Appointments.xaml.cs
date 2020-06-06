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
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public Appointments()
        {
            InitializeComponent();
        }

        //navigates user to make appointment window
        private void BtnMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointment make = new MakeAppointment();
            make.Show();
            this.Close();
        }
        //navigates user to update appointment window
        private void BtnUpdateAppointment_Click(object sender, RoutedEventArgs e)
        {
            UpdateAppointment update = new UpdateAppointment();
            update.Show();
            this.Close();
        }
        //navigates user to delete appointment window
        private void BtnDeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            DeleteAppointment delete = new DeleteAppointment();
            delete.Show();
            this.Close();
        }
        //navigates user to login window
        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        //navigates user to admin home window
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        //selects all data from appointments table and displays it to a datagrid
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
    }
}
