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
        public int RemainingCards { get; set; }
        public int NumDiscarded { get; set; }
        public int NumAtRisk { get; set; }
        public WarPlayer()
        {
            DrawPile = new List<Card>();
            DiscardPile = new List<Card>();
            CardsAtRisk = new List<Card>();
            NumAtRisk = 0;
        }

        public Card Draw()
        {
            NumAtRisk = 0;
            if(DrawPile.Count == 0)
            {
                return null;
            }
            Card card = DrawPile.First();
            FlippedCard = card;
            DrawPile.Remove(card);
            RemainingCards = DrawPile.Count();
            NumDiscarded = DiscardPile.Count();
            NumAtRisk += 1;
            return card;
        }

        public void War()
        {
            if(DrawPile.Count <= 1)
            {
                Shuffle();
            }
            CardsAtRisk.Add(FlippedCard);
            CardsAtRisk.Add(DrawPile.First());
            DrawPile.Remove(DrawPile.First());
            CardsAtRisk.Add(DrawPile.First());
            DrawPile.Remove(DrawPile.First());
            CardsAtRisk.Add(DrawPile.First());
            DrawPile.Remove(DrawPile.First());
            RemainingCards = DrawPile.Count();
            NumDiscarded = DiscardPile.Count();
            NumAtRisk += 3;
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
