using Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for MerchManagement.xaml
    /// </summary>
    public partial class MerchManagement : Window
    {
        public MerchManagement()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.Server = "209.106.201.103";
            dbCon.DatabaseName = "group3";
            dbCon.UserName = "dbstudent6";
            dbCon.Password = "freshsugar87";
            if (dbCon.IsConnect())
            {
                if (priceBox.Text == "") 
                {
                    string query = $"UPDATE Merchandise SET numAvailable =@inStock WHERE merchId = {merchIdBox.Text}";
                    var command = new MySqlCommand(query, DBConnection.Connection);
                    command.Parameters.AddWithValue("@inStock", int.Parse(inStockBox.Text));
                    command.Prepare();
                    command.ExecuteReader().Close();
                }
                else if (inStockBox.Text == "")
                {
                    string query = $"UPDATE Merchandise SET price =@price WHERE merchId =@merchID";
                    var command = new MySqlCommand(query, DBConnection.Connection);
                    command.Parameters.AddWithValue("@price", double.Parse(priceBox.Text));
                    command.Parameters.AddWithValue("@merchID", merchIdBox.Text);
                    command.Prepare();
                    command.ExecuteReader().Close();
                }
                else
                {
                    string query = $"UPDATE Merchandise SET price =@price, numAvailable =@numAvail" +
                        $" WHERE merchId =@merchID";
                    var command = new MySqlCommand(query, DBConnection.Connection);
                    command.Parameters.AddWithValue("@price", double.Parse(priceBox.Text));
                    command.Parameters.AddWithValue("@numAvail", int.Parse(inStockBox.Text));
                    command.Parameters.AddWithValue("@merchID", int.Parse(merchIdBox.Text));
                    command.Prepare();
                    command.ExecuteReader().Close();
                }
            }
        }

        private void newMerchButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            AddNewMerch addNewMerch = new AddNewMerch();
            addNewMerch.Visibility = Visibility.Visible;
        }

        private void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Checkout checkout = new Checkout();
            checkout.Visibility = Visibility.Visible;
        }

        private void MerchSearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MerchSearchWindow addNewMerch = new MerchSearchWindow();
            addNewMerch.Visibility = Visibility.Visible;
        }
    }
}
