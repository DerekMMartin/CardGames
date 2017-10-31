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
        public bool IsWon { get; set; }
        public WarPlayer LosingPlayer { get; set; }
        public bool IsWar { get; set; }
        public string FileExtension { get; private set; } = "war";
        public string GameName { get; private set; } = "War";

        public WarController(string player1, string player2)
        {
            Player1 = new WarPlayer();
            Player2 = new WarPlayer();
            Player1.Name = player1;
            Player2.Name = player2;
            DealCards();
        }

        public void DealCards()
        {
            Deck deck = new Deck();
            int size = deck.Cards.Count;
            for (int i = 0; i < size; i += 2)
            {
                Player1.DrawPile.Add(deck.Draw());
                Player2.DrawPile.Add(deck.Draw());
            }
            Player1.Shuffle();
            Player2.Shuffle();
            Player1.RemainingCards = Player1.DrawPile.Count();
            Player1.NumDiscarded = Player1.DiscardPile.Count();
            Player2.RemainingCards = Player2.DrawPile.Count();
            Player2.NumDiscarded = Player2.DiscardPile.Count();
        }

        public void Draw()
        {
            DrawPlayerCard(Player1);
            DrawPlayerCard(Player2);
            Card card1 = Player1.FlippedCard;
            Card card2 = Player2.FlippedCard;
            IsWar = false;
            if (!IsWon)
            {
                CheckCards(card1, card2);
            }

        }

        private void CheckCards(Card card1, Card card2)
        {
            if (card1.FaceValue == card2.FaceValue)
            {
                Player1.War();
                Player2.War();
                IsWar = true;
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
            }
            foreach (Card card in Player2.CardsAtRisk)
            {
                player.DiscardPile.Add(card);
            }
            Player1.CardsAtRisk.Clear();
            Player2.CardsAtRisk.Clear();
        }

        private Card DrawPlayerCard(WarPlayer player)
        {
            Card card = player.Draw();
            if(card == null)
            {
                //if the player has less than three cards in play and or discarded, they lose
                if(player.DiscardPile.Count + player.CardsAtRisk.Count + 1 <= 3)
                {
                    IsWon = true;
                    LosingPlayer = player;
                }
                else if(IsWar)
                {
                    //if there are any remaining cards besides the previous flipped
                    if(player.CardsAtRisk.Count != 1)
                    {
                        player.FlippedCard = player.CardsAtRisk.Last();
                        player.CardsAtRisk.Remove(player.FlippedCard);
                    }
                    else
                    {
                        IsWon = true;
                    LosingPlayer = player;
                    }

                }
                else
                {
                    player.Shuffle();
                    card = DrawPlayerCard(player);
                }
            }
            return card;
        }

    }
}
