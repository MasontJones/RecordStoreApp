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
        List<Merchandise> merchList = new List<Merchandise>();
        SearchClass SearchParameter;
        double TotalTracker = 0.00;
        double TaxRate = 0.07;
        public Checkout()
        {
            InitializeComponent();
            SearchClass search = new SearchClass();
            SearchParameter = search;
        }

        private void MerchIdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateListBox();
            }
        }
        private void UpdateListBox()
        {
            SearchParameter.SearchWords = MerchIdBox.Text;
            var dbCon = DBConnection.Instance();
            dbCon.Server = "209.106.201.103";
            dbCon.DatabaseName = "group3";
            dbCon.UserName = "dbstudent6";
            dbCon.Password = "freshsugar87";
            if (dbCon.IsConnect())
            {
                string query = $"SELECT merchID, merchName, price FROM Merchandise WHERE merchID ='{SearchParameter.SearchWords}';";
                var cmd = new MySqlCommand(query, DBConnection.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                merchList.Clear();
                while (reader.Read())
                {
                    Merchandise nextMerch = new Merchandise();
                    int merchID = reader.GetInt32(0);
                    string merchName = reader.GetString(1);
                    double price = reader.GetDouble(2);
                    nextMerch.merchID = merchID;
                    nextMerch.merchName = merchName;
                    nextMerch.price = price;
                    if(QuantityBox.Text == "")
                    {
                        TotalTracker += price;
                    }
                    else
                    {
                        TotalTracker += price * int.Parse(QuantityBox.Text);
                    }
                    merchList.Add(nextMerch);
                }
                reader.Close();
            }
            TotalBox.Text = $"{TotalTracker:C}";
            TaxBox.Text = $"{TotalTracker * TaxRate:C}";
            if (QuantityBox.Text == "")
            {
                PopulateList();
            }
            else
            {
                for (int i = 0; i < int.Parse(QuantityBox.Text); i++)
                {
                    PopulateList();
                }
            }
            MerchIdBox.Clear();
            QuantityBox.Clear();
        }
        private void PopulateList()
        {
            foreach (Merchandise a in merchList)
            {
                ItemListBox.Items.Add(a);
            }
        }

        private void QuantityBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateListBox();
            }
        }

        private void TenderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
