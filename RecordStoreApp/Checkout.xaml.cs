using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Data;
using MySql.Data.MySqlClient;
using RecordStoreApp.Model;

namespace RecordStoreApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Checkout : Window
    {

        double TaxRate = 0.07;
        public Checkout()
        {
            InitializeComponent();
            PopulateList();
            Taxes();
        }
        private void Taxes()
        {
            double total = 0;
            foreach(Merchandise a in SearchResults.merchList)
            {
                total += a.price;
            }
            double TaxPercent = total * TaxRate;
            TaxBox.Text = $"{TaxPercent.ToString("C2")}";
            TotalBox.Text = $"{total.ToString("C2")}";
            total = total + TaxPercent;
            string finalTotal = total.ToString("C2");
            GrandTotalBox.Text = $"{finalTotal}";
        }
        private void MerchIdBox_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.Key == Key.Enter)
            {
                UpdateListBox();
            }
            */
        }
       
        private void PopulateList()
        {
            foreach (Merchandise a in SearchResults.merchList)
            {
                ItemListBox.Items.Add(a);
            }
        }

        private void QuantityBox_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.Key == Key.Enter)
            {
                UpdateListBox();
            }
            */
        }

        private void TenderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemListBox.Items.Count != 0) 
            {
                bool nameEntered = Check(NameBox.Text);
                if (nameEntered is true)
                {
                    string newEmail = EmailCheck(EmailBox.Text);
                    string newPhone = PhoneCheck(PhoneBox.Text);
                    string firstName = FirstName(NameBox.Text);
                    string lastName = LastName(NameBox.Text);
                    var dbCon = DBConnection.Instance();
                    dbCon.Server = "209.106.201.103";
                    dbCon.DatabaseName = "group3";
                    dbCon.UserName = "dbstudent6";
                    dbCon.Password = "freshsugar87";
                    if (dbCon.IsConnect())
                    {
                        foreach (Merchandise a in SearchResults.merchList)
                        {
                            string query = $"UPDATE Merchandise JOIN {a.merchType} ON Merchandise.merchID = {a.merchType}.merchID SET Merchandise.numAvailable = Merchandise.numAvailable -1 WHERE Merchandise.merchID={a.merchID} and Merchandise.numAvailable > 0;";
                            var cmd = new MySqlCommand(query, DBConnection.Connection);
                            cmd.ExecuteNonQuery();
                        }
                        //string query2 = $"INSERT INTO Customer VALUES(null, '{firstName}', '{lastName}', {newPhone}, {newEmail});";
                        string query2 = $"INSERT INTO Customer VALUES(null, @firstName, @lastName, @newPhone, @newEmail);";
                        var cmd2 = new MySqlCommand(query2, DBConnection.Connection);
                        cmd2.Parameters.AddWithValue("@firstName", firstName);
                        cmd2.Parameters.AddWithValue("@lastName", lastName);
                        cmd2.Parameters.AddWithValue("@newPhone", newPhone);
                        cmd2.Parameters.AddWithValue("@newEmail", newEmail);
                        cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Thank you for your purchase {firstName} {lastName}");
                    SearchResults.merchList.Clear();
                    ItemListBox.Items.Clear();
                    TotalBox.Text = "";
                    TaxBox.Text = "";
                    GrandTotalBox.Text = "";
                    EmailBox.Text = "";
                    PhoneBox.Text = "";
                    EmailBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter customers first and last name");
                }
            }
            else
            {
                MessageBox.Show("There are no items to checkout with please add items to cart");
            }
        }


        private void MerchSearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MerchSearchWindow window = new MerchSearchWindow();
            window.Visibility = Visibility.Visible;
        }
        static bool Check(String EnteredName)
        {
            String[] Names = EnteredName.Split(' ');
            EnteredName = Regex.Replace(EnteredName, @"\s+", " ");
            int nums =0;
            foreach(string a in Names)
            {
                nums++;
            }
            if (String.IsNullOrWhiteSpace(EnteredName))
            {
                return false;
            }
            else if(nums > 2)
            {
                return false;
            }
            else if(nums <= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static string FirstName(string fullName)
        {
            fullName = Regex.Replace(fullName, @"\s+", " ");
            string[] Names = fullName.Split(' ');
            string firstName = Names[0];
            return firstName;

        }
        static string LastName(string fullName)
        {
            fullName = Regex.Replace(fullName, @"\s+", " ");
            string[] Names = fullName.Split(' ');
            string lastName = Names[1];
            return lastName;

        }
        static string EmailCheck(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                string isNull = "Null";
                return isNull;
            }
            else
            {
                string isNotNull = $"'{email}'";
                return isNotNull;
            }
        }
        static string PhoneCheck(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                string isNull = "Null";
                return isNull;
            }
            else
            {
                string isNotNull = $"'{phone}'";
                return isNotNull;
            }
        }
    }
}
