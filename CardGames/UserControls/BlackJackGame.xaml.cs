using CardGames.GameControllers;
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

        public StackPanel PlayerList { get; set; }
        public StackPanel Hand { get; set; }
        public StackPanel SplitHand { get; set; }
        public StackPanel Dealer { get; set; }
        public Label CPlayerName { get; set; }
        public Label Bank { get; set; }
        public Label CPlayerBet { get; set; }
        public StackPanel BetsPanel { get; set; }
        public Grid ActionGrid { get; set; }

        public BlackJackGame(MainWindow w, string[] names)
        {
            Window = w;
            InitializeComponent();

            PlayerList = playerlist;
            Hand = hand;
            SplitHand = splithand;
            Dealer = dealer;
            CPlayerName = cplayername;
            Bank = bank;
            CPlayerBet = cplayerbet;
            BetsPanel = betsgrid;
            ActionGrid = actiongrid;

            Controller = new BlackJackController(names)
            {
                GameWindow = this,
                Window = Window
            };

        }

        private void Bet_Click(object sender, RoutedEventArgs e)
        {

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
