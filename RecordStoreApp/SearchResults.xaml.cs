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
        public static List<Merchandise> merchList = new List<Merchandise>();
        bool inStock = false;
        Merchandise item;
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
                inStock = true;
                item = merchFound;
            }
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MerchSearchWindow window = new MerchSearchWindow();
            window.Visibility = Visibility.Visible;
            Close();

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (inStock is true)
            {
                MessageBox.Show("Item added to cart");
                merchList.Add(item);
                this.Visibility = Visibility.Collapsed;
                MerchSearchWindow window = new MerchSearchWindow();
                window.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("This item is out of stock");
            }

        }

        private void Checkout_Button_Click(object sender, RoutedEventArgs e)
        {
            if (inStock is true)
            {
                merchList.Add(item);
                this.Visibility = Visibility.Collapsed;
                Checkout checkWin = new Checkout();
                checkWin.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("This item is out of stock");
            }
        }
    }
}
