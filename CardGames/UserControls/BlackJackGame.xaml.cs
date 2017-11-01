using CardGames.GameControllers;
using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private bool InBetting = true;

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
            ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bank -= ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bet;

            if (CurrentPlayer == Controller.Players.Count - 1)
            {
                InBetting = false;
                Controller.GameWindow.dealer.Content = "";
                StartHand();
            }
            SwitchPlayer();
        }

        private void StartHand()
        {//TODO Make cards face down on first deal not the second one.
            betsgrid.Visibility = Visibility.Hidden;
            actiongrid.Visibility = Visibility.Visible;
            Controller.GDeck.Shuffle();
            foreach (Player item in Controller.Players)
            {
                item.Hand.Add(Controller.GDeck.Draw());
                item.Hand.Add(Controller.GDeck.Draw());
            }
            Controller.House.Hand.Add(Controller.GDeck.Draw());
            Controller.GameWindow.dealer.Content += Controller.House.Hand[0].Print() + " ";
            Controller.House.Hand.Add(Controller.GDeck.Draw());
            Controller.GameWindow.dealer.Content += Controller.House.Hand[1].Print() + " ";



            GameUpdateHands();
        }

        private void GameUpdateHands()
        {
            foreach (BlackJackPlayerDisplay item in Controller.GameWindow.playerlist.Children)
            {
                item.UpdateHands();
            }
            ((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).UpdateHands();

        }

        private void SwitchPlayer()
        {

            Controller.GameWindow.DoubleDown.Visibility = Visibility.Visible;
            Controller.GameWindow.Split.Visibility = Visibility.Visible;
            BlackJackPlayerDisplay tmp = (BlackJackPlayerDisplay)cplayerdisplay.Children[1];
            cplayerdisplay.Children.RemoveAt(1);
            playerlist.Children.Add(tmp);

            tmp = playerlist.Children[0] as BlackJackPlayerDisplay;
            playerlist.Children.RemoveAt(0);
            cplayerdisplay.Children.Add(tmp);
            CurrentPlayer = CurrentPlayer + 1 == Controller.Players.Count ? 0 : CurrentPlayer + 1;
            cplayerbet.Content = ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bet;
            cplayername.Content = ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Name;
            bank.Content = ((BlackJackPlayer)Controller.Players[CurrentPlayer]).Bank;
            GameUpdateHands();
            if (!InBetting && CurrentPlayer == 0 && ((BlackJackPlayer)Controller.Players[CurrentPlayer]).hasBustOrStand)
            {
                DealerPlay();
            }
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            BlackJackPlayer player = ((BlackJackPlayer)Controller.Players[CurrentPlayer]);
            Controller.GameWindow.DoubleDown.Visibility = Visibility.Hidden;
            Controller.GameWindow.Split.Visibility = Visibility.Hidden;
            player.Hand.Add(Controller.GDeck.Draw());
            ((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).UpdateHands();
            int HandValue = GetHandValue(player.Hand);

            if (HandValue > 21)
            {
                player.hasBustOrStand = true;
                ((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).Hand.Content += "BUST";
                SwitchPlayer();
            }
            if (player.Hand.Count == 5)
            {
                player.FiveCardCharlie = player.Hand.Count > 4;
                SwitchPlayer();
            }
        }



        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            ((BlackJackPlayer)Controller.Players[CurrentPlayer]).hasBustOrStand = true;
            SwitchPlayer();
        }
        private int GetHandValue(List<Card> Hand)
        {
            int HandValue = 0;
            int AceCount = 0;
            foreach (Card item in Hand)
            {
                if (item.FaceValue == Enums.CardValue.ACE)
                {
                    ++AceCount;
                    HandValue += 11;
                }

                if ((int)item.FaceValue > 9)
                {
                    HandValue += 10;
                }
                else
                {
                    HandValue += (int)item.FaceValue;
                }
            }

            while (AceCount > 0)
            {
                if (HandValue > 21)
                {
                    HandValue -= 10;
                }
                AceCount--;
            }
            return HandValue;
        }


        private void DealerPlay()
        {
            //dont do this
            Controller.GameWindow.Hit.Visibility = Visibility.Hidden;
            Controller.GameWindow.Stand.Visibility = Visibility.Hidden;
            //
            while (GetHandValue(Controller.House.Hand) <= 16)
            {
                Controller.House.Hand.Add(Controller.GDeck.Draw());
                Controller.GameWindow.dealer.Content += Controller.House.Hand[Controller.House.Hand.Count - 1].Print() + " ";
            } 
            GivePayouts();
        }

        private void GivePayouts()
        {
            foreach (Player p in Controller.Players)
            {
                BlackJackPlayer player = (BlackJackPlayer)p;
                if (GetHandValue(Controller.House.Hand) > 21)
                {
                    if (((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).Hand.Content.ToString().Substring(((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).Hand.Content.ToString().Length - 4) != "BUST")
                    {
                        player.Bank += player.Bet * 2;
                    }
                }
                else
                if (GetHandValue(player.Hand) > GetHandValue(Controller.House.Hand))
                {
                    player.Bank += player.Bet * 2;
                }
                ResetPlayerState((BlackJackPlayer)p);
            }
            Controller.House.Hand = new List<Card>();

            foreach (BlackJackPlayerDisplay item in Controller.GameWindow.playerlist.Children)
            {
                item.Hand.Content="";
                item.SplitHand.Content = "";
            }
            ((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).Hand.Content = "";
            ((BlackJackPlayerDisplay)Controller.GameWindow.cplayerdisplay.Children[1]).SplitHand.Content = "";
            Controller.GDeck.Shuffle();
            Controller.GameWindow.actiongrid.Visibility = Visibility.Hidden;
            Controller.GameWindow.betsgrid.Visibility = Visibility.Visible;
        }

        private void ResetPlayerState(BlackJackPlayer p)
        {
            p.Hand = new List<Card>();
            p.hasBustOrStand = false;
            p.FiveCardCharlie = false;
            p.Bet = 0;
        }

        private void DoubleDown_Click(object sender, RoutedEventArgs e)
        {//TODO Do this

        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {
            BlackJackPlayer player = ((BlackJackPlayer)Controller.Players[CurrentPlayer]);
            if (player.Hand[0].FaceValue == player.Hand[1].FaceValue)
            {
                player.SplitHand.Add(player.Hand[1]); player.Hand.RemoveAt(1);// I won this bet
            }
        }
    }
}
