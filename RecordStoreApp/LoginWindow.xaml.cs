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
                string query = $"SELECT password FROM Employee WHERE firstName=@username;";
                var cmd = new MySqlCommand(query, DBConnection.Connection);
                cmd.Parameters.AddWithValue("@username", enteredUser);
                cmd.Prepare();
                var reader = cmd.ExecuteReader();
                Employee loginemployee = new Employee();//Creates an instance of Employee so data in reader can be accessed 
                while (reader.Read())//stores columns from query result in Employee Class
                {
                   
                    string hashedPassword = reader.GetString(0);
                    loginemployee.Password = hashedPassword;
                }
                reader.Close();
                //If statement to either give acess upon success or deny upon failure
                bool isValid = BCrypt.Net.BCrypt.Verify(EnteredPassword, loginemployee.Password);
                if (isValid)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainMenu window = new MainMenu();
                    window.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Password or username was incorrect");
                    PasswordEntered.Clear();
                    UserName.Clear();
                }
                
            }

        }

    }
}
