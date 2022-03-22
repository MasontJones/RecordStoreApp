using Data;
using MySql.Data.MySqlClient;
using RecordStoreApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecordStoreApp
{
    /// <summary>
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchResults : Window
    {
        public SearchResults()
        {
            InitializeComponent();
        }
        public void QueryResults(Merchandise merchFound) //gets the results from the merch search window and displays them 
        {
            MerchIDBlock.Text = merchFound.merchID.ToString();
            MerchNameBlock.Text = merchFound.merchName;
            MerchPriceBlock.Text = $"${merchFound.price.ToString()}";
            if (merchFound.avaliabale == 0)
            {
                InStockBlock.Text = "Not in stock";
            }
            else
            {
                InStockBlock.Text = "Is in stock";
            }
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MerchSearchWindow window = new MerchSearchWindow();
            window.Visibility = Visibility.Visible;
            Close();

        }

    }
}
