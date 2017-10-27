using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public class WarPlayer : Player
    {

        public List<Card> DrawPile { get; set; }
        public List<Card> DiscardPile { get; set; }
        public Card FlippedCard { get; set; }
        public List<Card> CardsAtRisk { get; set; }

        public WarPlayer()
        {
            DrawPile = new List<Card>();
            DiscardPile = new List<Card>();
            CardsAtRisk = new List<Card>();
        }

        public Card Draw()
        {
            if(DrawPile.Count == 0)
            {
                return null;
            }
            Card card = DrawPile.First();
            FlippedCard = card;
            DrawPile.Remove(card);
            return card;
        }

        public Card War()
        {
            if(DrawPile.Count <= 1)
            {
                Shuffle();
            }
            CardsAtRisk.Add(FlippedCard);
            CardsAtRisk.Add(DrawPile.First());
            DrawPile.Remove(DrawPile.First());
            return Draw();
        }

        public void Shuffle()
        {

            foreach (Card card in DrawPile)
            {
                DiscardPile.Add(card);
            }
            DrawPile.Clear();
            Random rand = new Random();
            int size = DiscardPile.Count();
            for (int i = 0; i < size; i++)
            {
                int selection = rand.Next(DiscardPile.Count());
                DrawPile.Add(DiscardPile[selection]);
            }
            DiscardPile.Clear();
        }

    }
}
