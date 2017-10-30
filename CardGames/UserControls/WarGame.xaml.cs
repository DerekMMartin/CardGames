﻿using CardGames.GameControllers;
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
    /// Interaction logic for WarGame.xaml
    /// </summary>
    public partial class WarGame : UserControl
    {

        public bool IsPvP { get; set; }
        public WarController Controller { get; set; }

        public WarGame()
        {
            InitializeComponent();
        }

        public WarGame(String player1)
        {
            IsPvP = false;
            InitializeComponent();
            Player1Label.Content = player1;
            Player2Label.Content = "Computer";
            Controller = new WarController();
            UpdateLables();
        }

        public WarGame(String player1, String player2)
        {
            IsPvP = true;
            InitializeComponent();
            Player1Label.Content = player1;
            Player2Label.Content = player2;
            Controller = new WarController();
            UpdateLables();
        }

        private void UpdateLables()
        {
            Player1DrawLabel.Content = Controller.Player1.RemainingCards;
            Player2DrawLabel.Content = Controller.Player2.RemainingCards;
            Player1DiscardLabel.Content = Controller.Player1.NumDiscarded;
            Player2DiscardLabel.Content = Controller.Player2.NumDiscarded;
            CardsAtRiskLabel.Content = (Controller.Player1.NumAtRisk + Controller.Player2.NumAtRisk);
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.Draw();
            string card1 = Controller.Player1.FlippedCard.FaceValue.ToString() + Controller.Player1.FlippedCard.FaceSuit.ToString();
            string card2 = Controller.Player2.FlippedCard.FaceValue.ToString() + Controller.Player2.FlippedCard.FaceSuit.ToString();
            Player1Card.Content = card1;
            Player2Card.Content = card2;
            UpdateLables();
        }

    }
}