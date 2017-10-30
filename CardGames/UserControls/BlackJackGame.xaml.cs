using CardGames.GameControllers;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
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

namespace CardGames.UserControls
{
    /// <summary>
    /// Interaction logic for BlackJackGame.xaml
    /// </summary>
    public partial class BlackJackGame : UserControl
    {
        public MainWindow Window { get; set; }
        public BlackJackController Controller { get; set; }
        public int CurrentPlayer { get; set; }

        public BlackJackGame(MainWindow w, string[] names)
        {
            Window = w;
            InitializeComponent();
            Controller = new BlackJackController(Window, this, names);

        }

        private void Bet_Click(object sender, RoutedEventArgs e)
        {
            //((BlackJackPlayer)Controller.Players[0]).Bet = 
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoubleDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
