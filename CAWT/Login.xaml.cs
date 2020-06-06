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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        //Login Button
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Path for the database
            SQLiteConnection conn = new SQLiteConnection("Data Source = C:\\SQLite\\CAWT.db; Version = 3; ");
            // A try catch statement that asks the user to input data first
            try
            {
                //Opening the database connection
                conn.Open();
                //Query for the database that selects all users from the login table
                string query = "Select * from Login where Username='" + this.txtUsername.Text + "' and Password='" + this.txtPassword.Password + "'";            
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = cmd.ExecuteReader();

                //creating the admin page requirements
                string password = "password";
                string userName, enterPassword;
                userName = txtUsername.Text;
                enterPassword = txtPassword.Password;                

                //setting the counter to 0 an incrementing it to check for different users
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }

                //log in successfully
                if (count == 1)
                {
                    MessageBox.Show("Username and Password was correct");
                    conn.Close();

                    //directs user with the password "password" to the admin page
                    if (password.Equals(enterPassword))
                    {
                        MessageBox.Show("Welcome admin user");
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    //directs all other users to the user page
                    else
                    {
                        ParticipantsView user = new ParticipantsView();
                        user.Show();
                        this.Close();
                    }
                }

                //tells the user at login that the username is a duplicate
                else if (count > 1)
                    {
                        MessageBox.Show("Duplicate Username and Password, Try Again");
                    }
                
                //tells the user that there login credientals are wrong and try again
                else if (count < 1)
                    {
                        MessageBox.Show("Invalid, please try again");
                    }
                
            }
            // error checker to check and display exceptions
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //closes the program
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Navigates User to Register
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
