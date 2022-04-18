using Data;
using MySql.Data.MySqlClient;
using RecordStoreApp.Model;
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

namespace RecordStoreApp
{
    /// <summary>
    /// Interaction logic for AddNewMerch.xaml
    /// </summary>
    public partial class AddNewMerch : Window
    {
        public AddNewMerch()
        {
            InitializeComponent();
        }

        private void addMerchandiseButton_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.Server = "209.106.201.103";
            dbCon.DatabaseName = "group3";
            dbCon.UserName = "dbstudent6";
            dbCon.Password = "freshsugar87";
            if (dbCon.IsConnect())
            {
                if (artistBox.Text == "" || nameBox.Text == "" || priceBox.Text == "" || numInStockBox.Text == "" ||
                    genreComboBox.SelectedIndex == -1 || trackOrAlbumComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing value(s)");
                }
                else
                {
                    if (trackOrAlbumComboBox.Text == "Track")
                    {
                        string query = $"INSERT INTO Merchandise (merchName, price, numAvailable) VALUES (@name, " +
                            $"@price, @numAvail)";
                        var command = new MySqlCommand(query, DBConnection.Connection);
                        command.Parameters.AddWithValue("@name", nameBox.Text);
                        command.Parameters.AddWithValue("@price", double.Parse(priceBox.Text));
                        command.Parameters.AddWithValue("@numAvail", int.Parse(numInStockBox.Text));
                        command.Prepare();
                        command.ExecuteReader().Close();
                        string query2 = $"INSERT INTO Track (merchID, trackName, genreID, artist) VALUES " +
                            $"((SELECT Merchandise.merchID FROM Merchandise WHERE merchName = @name), @name, " +
                            $"(SELECT Genre.genreID FROM Genre WHERE genreName = @genre), @artist)";
                        var command2 = new MySqlCommand(query2, DBConnection.Connection);
                        command2.Parameters.AddWithValue("@name", nameBox.Text);
                        command2.Parameters.AddWithValue("@genre", genreComboBox.Text);
                        command2.Parameters.AddWithValue("@artist", artistBox.Text);
                        command2.Prepare();
                        command2.ExecuteReader().Close();
                    }
                    else
                    {
                        string query = $"INSERT INTO Merchandise (merchName, price, numAvailable) VALUES (@name, " +
                            $"@price, @numAvail)";
                        var command = new MySqlCommand(query, DBConnection.Connection);
                        command.Parameters.AddWithValue("@name", nameBox.Text);
                        command.Parameters.AddWithValue("@price", double.Parse(priceBox.Text));
                        command.Parameters.AddWithValue("@numAvail", int.Parse(numInStockBox.Text));
                        command.Prepare();
                        command.ExecuteReader().Close();
                        string query2 = $"INSERT INTO Album (merchID, albumName, artist, genreID) VALUES " +
                            $"((SELECT Merchandise.merchID FROM Merchandise WHERE merchName = @name), @name, " +
                            $"@artist, (SELECT Genre.genreID FROM Genre WHERE genreName = @genre))";
                        var command2 = new MySqlCommand(query2, DBConnection.Connection);
                        command2.Parameters.AddWithValue("@name", nameBox.Text);
                        command2.Parameters.AddWithValue("@genre", genreComboBox.Text);
                        command2.Parameters.AddWithValue("@artist", artistBox.Text);
                        command2.Prepare();
                        command2.ExecuteReader().Close();
                    }
                }
            }
        }
        List<Genre> genreList = new List<Genre>();
        private void genreComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.Server = "209.106.201.103";
            dbCon.DatabaseName = "group3";
            dbCon.UserName = "dbstudent6";
            dbCon.Password = "freshsugar87";
            if (dbCon.IsConnect())
            {
                string query = $"SELECT genreName FROM Genre;";
                var cmd = new MySqlCommand(query, DBConnection.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Genre newGenre = new Genre();
                    newGenre.genreName = reader.GetString(0);
                    genreList.Add(newGenre);
                }
                reader.Close();
                cmd.ExecuteReader().Close();
            }
            foreach (Genre a in genreList)
            {
                genreComboBox.Items.Add(a.genreName);
            }
        }

        private void MerchSearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MerchSearchWindow addNewMerch = new MerchSearchWindow();
            addNewMerch.Visibility = Visibility.Visible;
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Checkout checkout = new Checkout();
            checkout.Visibility = Visibility.Visible;
        }
    }
}
