using Data;
using MySql.Data.MySqlClient;
using RecordStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RecordStoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {

            InitializeComponent();

        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //connects to database using DBConnectionClass
            var dbCon = DBConnection.Instance();
            dbCon.Server = "209.106.201.103";
            dbCon.DatabaseName = "group3";
            dbCon.UserName = "dbstudent6";
            dbCon.Password = "freshsugar87";
            if (dbCon.IsConnect())
            {
                string enteredUser = UserName.Text;
                string EnteredPassword = PasswordEntered.Password;
                //Hashes the entered password to match to database entry
                SHA1Managed sha1 = new SHA1Managed();
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(EnteredPassword));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash) 
                {
                    sb.Append(b.ToString("x2"));
                }
                String HashedPassword = sb.ToString(); //stores hash in string format
                //Code to get a query ran in the database
                string query = $"SELECT firstName, password FROM Employee WHERE firstName = '{enteredUser}' ";
                var cmd = new MySqlCommand(query, DBConnection.Connection);
                var reader = cmd.ExecuteReader();
                Employee loginemployee = new Employee();//Creates an instance of Employee so data in reader can be accessed 
                while (reader.Read())//stores columns from query result in Employee Class
                {
                   
                    string FirstName = reader.GetString(0);
                    string PasswordHash = reader.GetString(1);
                    loginemployee.FirstName = FirstName;
                    loginemployee.Password = PasswordHash;
                }
                //If statement to either give acess upon success or deny upon failure
                if (enteredUser == loginemployee.FirstName && HashedPassword == loginemployee.Password)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainMenu window = new MainMenu();
                    window.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Password or username was incorrect");

                }
                reader.Close();             
            }

        }

    }
}
