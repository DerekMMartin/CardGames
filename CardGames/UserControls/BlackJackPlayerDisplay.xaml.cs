using CardGames.Models;
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
    /// Interaction logic for BlackJackPlayerDisplay.xaml
    /// </summary>
    public partial class BlackJackPlayerDisplay : UserControl
    {
        public BlackJackPlayer Player { get; set; }
        public Label Hand { get; set; }
        public Label SplitHand { get; set; }
        public BlackJackPlayerDisplay(BlackJackPlayer p)
        {
            InitializeComponent();
            Player = p;
            Hand = hand;
            SplitHand = splitHand;
            name.Content = Player.Name;

            bank.DataContext = Player;
            bank.SetBinding(Label.ContentProperty, new Binding("Bank"));

        }
        public void UpdateHands()
        {
            Hand.Content = "";
            SplitHand.Content = "";
            foreach (Card c in Player.Hand)
            {
                Hand.Content += c.Print() + " ";
            }
            foreach (Card c in Player.SplitHand)
            {
                SplitHand.Content += c.Print() + " ";
            }
        }
    }
}
