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
    /// Interaction logic for MerchSearchWindow.xaml
    /// </summary>
    public partial class MerchSearchWindow : Window
    {
        List<Merchandise> merchList = new List<Merchandise>();
        SearchClass SearchParameter;

        public MerchSearchWindow()
        {
            InitializeComponent();
            SearchClass search = new SearchClass();
            SearchParameter = search;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            Results.Items.Clear();
            if (TrackButton.IsChecked == true)
            {
                SearchParameter.SearchWords = SearchBox.Text;
                var dbCon = DBConnection.Instance();
                dbCon.Server = "209.106.201.103";
                dbCon.DatabaseName = "group3";
                dbCon.UserName = "dbstudent6";
                dbCon.Password = "freshsugar87";
                if (dbCon.IsConnect())
                {
                    string query = $"SELECT Track.merchID, Track.trackName, Track.artist, Merchandise.numAvailable, Merchandise.price FROM Track JOIN Merchandise ON Track.merchID=Merchandise.merchID WHERE trackName LIKE @searchwords;";
                    var cmd = new MySqlCommand(query, DBConnection.Connection);
                    string searchTerm = string.Format("%{0}%", SearchParameter.SearchWords);
                    cmd.Parameters.AddWithValue("@searchwords", searchTerm);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    merchList.Clear();
                    while (reader.Read())
                    {
                        Merchandise nextMerch = new Merchandise();
                        int merchID = reader.GetInt32(0);
                        string trackName = reader.GetString(1);
                        string artist = reader.GetString(2);
                        int available = reader.GetInt32(3);
                        double price = reader.GetDouble(4);
                        nextMerch.merchID = merchID;
                        nextMerch.merchName = trackName;
                        nextMerch.merchArtist = artist;
                        nextMerch.available = available;
                        nextMerch.price = price;
                        nextMerch.merchType = "Track";
                        merchList.Add(nextMerch);
                    }
                    reader.Close();
                }
                PopulateList();
            
            }
            else if (AlbumButton.IsChecked == true)
            {
                SearchParameter.SearchWords = SearchBox.Text;
                var dbCon = DBConnection.Instance();
                dbCon.Server = "209.106.201.103";
                dbCon.DatabaseName = "group3";
                dbCon.UserName = "dbstudent6";
                dbCon.Password = "freshsugar87";
                if (dbCon.IsConnect())
                {
                    string query = $"SELECT Album.merchID, Album.albumName, Album.artist, Merchandise.numAvailable, Merchandise.price FROM Album JOIN Merchandise ON Album.merchID=Merchandise.merchID WHERE albumName LIKE @searchwords;";
                    var cmd = new MySqlCommand(query, DBConnection.Connection);
                    string searchTerm = string.Format("%{0}%", SearchParameter.SearchWords);
                    cmd.Parameters.AddWithValue("@searchwords", searchTerm);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    merchList.Clear();
                    while (reader.Read())
                    {
                        Merchandise nextMerch = new Merchandise();
                        int merchID = reader.GetInt32(0);
                        string albumName = reader.GetString(1);
                        string artist = reader.GetString(2);
                        int available = reader.GetInt32(3);
                        double price = reader.GetDouble(4);
                        nextMerch.merchID = merchID;
                        nextMerch.merchName = albumName;
                        nextMerch.merchArtist = artist;
                        nextMerch.available = available;
                        nextMerch.price = price;
                        nextMerch.merchType = "Album";
                        merchList.Add(nextMerch);
                    }
                    reader.Close();
                }
                PopulateList();
            }
            else if (GenreButton.IsChecked == true)
            {
                SearchParameter.SearchWords = SearchBox.Text;
                var dbCon = DBConnection.Instance();
                dbCon.Server = "209.106.201.103";
                dbCon.DatabaseName = "group3";
                dbCon.UserName = "dbstudent6";
                dbCon.Password = "freshsugar87";
                if (dbCon.IsConnect())
                {
                    string query = $"SELECT Track.merchID, Track.trackName, Track.artist, Merchandise.numAvailable, Merchandise.price FROM Merchandise JOIN Track ON Merchandise.merchName = Track.trackName JOIN Genre ON Track.genreID = Genre.genreID WHERE Genre.genreName LIKE @searchwords;";
                    var cmd = new MySqlCommand(query, DBConnection.Connection);
                    string searchTerm1 = string.Format("%{0}%", SearchParameter.SearchWords);
                    cmd.Parameters.AddWithValue("@searchwords", searchTerm1);
                    cmd.Prepare();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    merchList.Clear();
                    while (reader.Read())
                    {
                        Merchandise nextMerch = new Merchandise();
                        int merchID = reader.GetInt32(0);
                        string trackName = reader.GetString(1);
                        string artist = reader.GetString(2);
                        int avaliable = reader.GetInt32(3);
                        double price = reader.GetDouble(4);
                        nextMerch.merchID = merchID;
                        nextMerch.merchName = trackName;
                        nextMerch.merchArtist = artist;
                        nextMerch.available = avaliable;
                        nextMerch.price = price;
                        nextMerch.merchType = "Track";
                        merchList.Add(nextMerch);
                    }
                    reader.Close();
                    
                    string query2 = $"SELECT Album.merchID, Album.albumName, Album.artist, Merchandise.numAvailable, Merchandise.price FROM Merchandise JOIN Album ON Merchandise.merchName = Album.albumName JOIN Genre ON Album.genreID = Genre.genreID WHERE Genre.genreName LIKE @searchwords;";
                    var cmd2 = new MySqlCommand(query2, DBConnection.Connection);
                    string searchTerm2 = string.Format("%{0}%", SearchParameter.SearchWords);
                    cmd2.Parameters.AddWithValue("@searchwords", searchTerm2);
                    cmd2.Prepare();
                    MySqlDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Merchandise nextMerch = new Merchandise();
                        int merchID = reader2.GetInt32(0);
                        string albumName = reader2.GetString(1);
                        string artist = reader2.GetString(2);
                        int available = reader2.GetInt32(3);
                        double price = reader2.GetDouble(4);
                        nextMerch.merchID = merchID;
                        nextMerch.merchName = albumName;
                        nextMerch.merchArtist = artist;
                        nextMerch.available = available;
                        nextMerch.price = price;
                        nextMerch.merchType = "Album";
                        merchList.Add(nextMerch);
                    }
                    reader2.Close();
                }
                PopulateList();
            }
            else
            {
                MessageBox.Show("Select either track, album or genre before searching");            
            }
           
            
        }
        private void PopulateList()
        {
            Results.Items.Clear();
            foreach (Merchandise a in merchList)
            {
                Results.Items.Add(a);
            }
        }

        private void SelectItem_Button_Click(object sender, RoutedEventArgs e)
        {

            Merchandise selectedMerch;
            selectedMerch = Results.SelectedItem as Merchandise;
            if ( selectedMerch != null)
            {
                this.Visibility = Visibility.Collapsed;
                SearchResults search = new SearchResults();
                search.Visibility = Visibility.Visible;
                search.QueryResults(selectedMerch);
            }
            else
            {
                MessageBox.Show("Please select an item");
            }
        }

        private void Checkout_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Checkout checkoutWindow = new Checkout();
            checkoutWindow.Visibility = Visibility.Visible;
        }

        private void Main_Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainMenu window = new MainMenu();
            window.Visibility = Visibility.Visible;
        }
    }
}
