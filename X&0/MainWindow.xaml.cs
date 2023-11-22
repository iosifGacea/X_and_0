using Catalog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

namespace X_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
  
        private static ObservableCollection<Player> getAllPlayers()
        {
            SqlConnection con = Connection.Con;
            ObservableCollection<Player> players = new ObservableCollection<Player>();
            try
            {
                SqlCommand cmd = new SqlCommand("SelectAllPlayers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Player player = new Player();
                    player.Id = (int)reader[0];
                    player.Name = (string)reader[1];
                    player.Password = (string)reader[2];
                    player.TotalGames = (int)reader[3];
                    player.WinGames = (int)reader[4];
                    players.Add(player);
                }
                reader.Close();
                return players;
            }
            finally { 
                con.Close(); 
            }

        }
        private bool find(string name, string pass, ObservableCollection<Player> players)
        {
            bool ok = false;
            foreach(Player player in players)
            {
                if (player.Name == name && player.Password == pass)
                    ok = true;
            }

            return ok;
        }
    private void startGameClick(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Player> players = getAllPlayers();
            if (find(name1.Text, password1.Text, players) && find(name2.Text, password2.Text, players))
            {
                string[] aux=new string[2];
                aux[0] = name1.Text;
                aux[1] = name2.Text;
                GameWindow gameWindow = new GameWindow(aux);
                gameWindow.Show();
            }
            else
            {
                MessageBox.Show("ceva nu  e bine !");
            }
        }

        private void createANewAccountClick(object sender, RoutedEventArgs e)
        {
            CreateANewAccount window=new CreateANewAccount();
            window.Show();
        }
    }
}
