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
            Deck d = new Deck();

            Players = new List<Player>();

            for (int i = 0; i < numOfPlayers; i++)
            {
                GoFishPlayer p = new GoFishPlayer();

                p.Name = playerNames[i];
                p.IsAi = false;

                p.Hand = new List<Card>();

                for (int j = 0;  j < 7;  j++)
                {
                    p.Hand.Add(Deck.Draw());
                }
                
                Players.Add(p);
            }
 
        }

        private void StartGame()
        {
            //SetupHands();
            //Ask player for card 
            //Check for card in that players hand -- CheckIfPlayerHasCard();
            //if true return a list of cards to put into the requester -- ReturnRequestedCards();
            //else GOFISH BABYYY

            //Player pulls card from deck
            //if card == requested card tell other player card face + value and player goes again

            //Loop until player gets 4 of a kind
            
        }
        
        private bool CheckIfPlayerHasCard(GoFishPlayer player, CardValue value)
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
        private List<Card> ReturnRequestedCards(GoFishPlayer requestedPlayer, CardValue requestedValue)
        {
            List<Card> requestedCards = (List<Card>)requestedPlayer.Hand.Where(card => card.FaceValue == requestedValue);

            return requestedCards;
        }
        
        private bool ValidatePair(Card card1, Card Card2)
        {
            bool validPair = false;

            if (card1.FaceValue == Card2.FaceValue)
            {
                validPair = true;
            }
            
            return validPair;
        }
        
        /// <summary>
        /// Returns list of CardValues that exist in the player's hand
        /// </summary>
        /// <param name="p">Player being evaluated</param>
        /// <returns></returns>
        private List<CardValue> GetRequestableCardValues(GoFishPlayer p)
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

        private List<Card> AddCardsToHand(GoFishPlayer p, List<Card> cardsToBeAdded)
        {
            foreach (Card c in cardsToBeAdded)
            {
                p.Hand.Add(c);
            }

            return p.Hand;
        }

        public override void SaveGame()
        {
            throw new NotImplementedException();
        }



    }
}
