using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.GameControllers
{
    public class WarController
    {
        public WarPlayer Player1 { get; set; }
        public WarPlayer Player2 { get; set; }
        public bool IsPvP { get; set; }
        public bool IsWon { get; set; }
        public WarPlayer LosingPlayer { get; set; }

        public WarController(string Player1Name)
        {

        }

        public WarController(string Player1Name, string Player2Name)
        {

        }

        public void DealCards()
        {
            Deck deck = new Deck();
            for (int i = 0; i < deck.Cards.Count();  i += 2)
            {
                Player1.DrawPile.Add(deck.Draw());
                Player2.DrawPile.Add(deck.Draw());
            }
        }

        public void Draw()
        {
            Card card1 = DrawPlayerCard(Player1);
            Card card2 = DrawPlayerCard(Player2);
            if (!IsWon)
            {
                CheckCards(card1, card2);
            }

        }

        private void CheckCards(Card card1, Card card2)
        {
            if ((int)card1.FaceValue == (int)card2.FaceValue)
            {
                CheckCards(Player1.War(), Player2.War());
            }
            else if ((int)card1.FaceValue > (int)card2.FaceValue || (int)card1.FaceValue == 1)
            {
                ClearBoard(Player1);
            }
            else
            {
                ClearBoard(Player2);
            }

        }

        private void ClearBoard(WarPlayer player)
        {
            player.DiscardPile.Add(Player1.FlippedCard);
            player.DiscardPile.Add(Player2.FlippedCard);
            foreach (Card card in Player1.CardsAtRisk)
            {
                player.DiscardPile.Add(card);
                CardsAtRisk.Remove(card);
            }
            foreach (Card card in Player2.CardsAtRisk)
            {
                player.DiscardPile.Add(card);
                CardsAtRisk.Remove(card);
            }
        }

        private void DrawPlayerCard(WarPlayer player)
        {
            Card card = player.Draw();
            if(card == null)
            {
                if(player.DiscardPile.Count() <= 3)
                {
                    IsWon = true;
                    LosingPlayer = player;
                }
                else
                {
                    player.Shuffle();
                }
            }
        }

    }
}
