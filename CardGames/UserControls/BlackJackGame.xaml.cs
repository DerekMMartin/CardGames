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
        public int CurrentPlayer { get; set; } = 0;

        public BlackJackGame(MainWindow w, string[] names)
        {
            Window = w;
            InitializeComponent();
            Controller = new BlackJackController(Window, this, names);

        }

        private void Bet_Click(object sender, RoutedEventArgs e)
        {
            ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bet = int.Parse(((Button)sender).Content.ToString().Substring(1));
            //If Last person Make bet invis, make other visable
            SwitchPlayer();
        }

        private void SwitchPlayer()
        {
            BlackJackPlayerDisplay tmp = (BlackJackPlayerDisplay)cplayerdisplay.Children[1];
            cplayerdisplay.Children.RemoveAt(1);
            playerlist.Children.Add(tmp);

            tmp = playerlist.Children[0] as BlackJackPlayerDisplay;
            playerlist.Children.RemoveAt(0);
            cplayerdisplay.Children.Add(tmp);

            CurrentPlayer = CurrentPlayer  + 1 == Controller.Players.Count ? 0 : CurrentPlayer + 1;
            cplayerbet.Content = ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bet;
            cplayername.Content = ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Name;
            bank.Content = ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bank;
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
