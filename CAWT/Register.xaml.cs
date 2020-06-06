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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            //temporary storage location for database columns
            int id = Convert.ToInt32(txtID.Text);
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            //query that then inserts user inputs from the textboxes to the database
            string query = "Insert into Login(LoginID, Username, Password) Values " +
                "(" + id + ", '" + Username + "', '" + Password + "')";

            //opens the connection to the datbase
            SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3;");
            conn.Open();

            //runs the query and the closes the connection to the database
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Username Successfully added");
            conn.Close();

            //navigates the user back to the participants view window after user has been added
            Login login = new Login();
            login.Show();
            this.Close();

        }

        private void BrtLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
