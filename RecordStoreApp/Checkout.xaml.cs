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
                }
                MessageBox.Show("Thank you for the purchase");
                SearchResults.merchList.Clear();
                ItemListBox.Items.Clear();
                TotalBox.Text = "";
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
    }
}
