using CardGames.Enums;
using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.GameControllers
{
    public class GoFishController : Game
    {
        public GoFishController(int numOfPlayers, List<string> playerNames)
        {

            GameName = "Go Fish";

            GDeck = new Deck();

            Players = new List<Player>();

            FileExtension = "GoF";

            for (int i = 0; i < numOfPlayers; i++)
            {
                GoFishPlayer p = new GoFishPlayer();

                p.Name = playerNames[i];
                p.IsAi = false;

                p.Hand = new List<Card>();

                for (int j = 0;  j < 7;  j++)
                {
                    p.Hand.Add(GDeck.Draw());
                }
                
                Players.Add(p);
            }
 
        }

        public bool CheckIfPlayerHasCard(GoFishPlayer player, CardValue value)
        {
            bool hasCard = false;

            foreach (Card c in player.Hand)
            {
                if (c.FaceValue == value)
                {
                    hasCard = true;
                }
            }

            return hasCard;
        }

        /// <summary>
        /// Looks through requested player's hand to find all cards that match the requested value
        /// </summary>
        /// <param name="requestedPlayer">Player being asked if they have a card</param>
        /// <param name="requestedValue">Value being looked for</param>
        /// <returns></returns>
        public List<Card> ReturnRequestedCards(GoFishPlayer requestedPlayer, CardValue requestedValue)
        {
            List<Card> requestedCards = (List<Card>)requestedPlayer.Hand.Where(card => card.FaceValue == requestedValue);

            return requestedCards;
        }
        
        /// <summary>
        /// Finds a pair of cards in a hand and returns a list of each pairs 
        /// </summary>
        /// <param name="handOfCards">Player hand being checked for pairs</param>
        /// <returns></returns>
        public List<List<Card>> FindPair(List<Card> handOfCards)
        {
            List<Card> returnPair = new List<Card>();
            
            foreach (Card Card1 in handOfCards)
            {
                foreach (Card Card2 in handOfCards)
                {
                    if (Card1.FaceValue == Card2.FaceValue)
                    {
                        returnPair.Add(Card1);
                        returnPair.Add(Card2);
                    }
                }
            }

            return null;
        }

        public List<Card> RemoveCardsFromHand(List<Card> cardsToRemove, List<Card> hand)
        {
            List<Card> newHand = new List<Card>();

            foreach (Card removeCard in cardsToRemove)
            {
                foreach (Card c in hand)
                {
                    if (removeCard.FaceSuit == c.FaceSuit && removeCard.FaceValue == c.FaceValue)
                    {

                    } else
                    {
                        newHand.Add(c);
                    }
                }
            }
            
            return newHand;
        }

        /// <summary>
        /// Returns list of CardValues that exist in the player's hand
        /// </summary>
        /// <param name="p">Player being evaluated</param>
        /// <returns></returns>
        public List<CardValue> GetRequestableCardValues(GoFishPlayer p)
        {
            List<CardValue> CardVals = new List<CardValue>();

            foreach (Card c in p.Hand)
            {
                if (CardVals.Count != 0 && !CardVals.Contains(c.FaceValue))
                {
                    CardVals.Add(c.FaceValue);
                }
            }
            
            return CardVals;
        }

        public List<Card> AddCardsToHand(GoFishPlayer p, List<Card> cardsToBeAdded)
        {
            foreach (Card c in cardsToBeAdded)
            {
                p.Hand.Add(c);
            }

            return p.Hand;
        }

    }
}
