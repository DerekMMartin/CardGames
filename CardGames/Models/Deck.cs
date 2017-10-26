using CardGames.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models
{
    public class Deck
    {
        /// <summary>
        /// The current cards in the deck
        /// </summary>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// The cards that have already been drawn
        /// </summary>
        public List<Card> Drawn { get; set; }

        /// <summary>
        /// Consstructs a new deck and populates with the 52 playing cards
        /// </summary>
        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Card newCard = new Card(i, suit);
                    Cards.Add(newCard);
                }
            }


        }

        /// <summary>
        /// Grabs the top card of the deck and temporarly removes it from the deck so it cannot be drawn again
        /// </summary>
        /// <returns>The top card of the deck or null if the deck is empty</returns>
        public Card Draw()
        {
            Card drawnCard;
            if(Cards.Count > 0)
            {
                drawnCard = Cards.First();
                Cards.Remove(drawnCard);
                Drawn.Add(drawnCard);
            }
            else
            {
                drawnCard = null;
            }
            return drawnCard;
        }

        /// <summary>
        /// Takes all cards both drawn and in the deck, puts them back in the deck and randomizes the order
        /// </summary>
        public void Shuffle()
        {

            ClearDrawnPile();
            
            for (int i = 0; i < 52; i++)
            {
                Random rand = new Random();
                int randomNum = rand.Next(Cards.Count);
                Card card = Cards[randomNum];
                Drawn.Add(card);
                Cards.Remove(card);
            }

            foreach (Card card in Drawn)
            {
                Cards.Add(card);
            }

            ClearDrawnPile();

        }

        /// <summary>
        /// Takes all cards in the draw pile and puts the back into the deck
        /// </summary>
        private  void ClearDrawnPile()
        {
            foreach (Card card in Drawn)
            {
                Cards.Add(card);
                Cards.Remove(card);
            }
        }
    }
}
