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
            for (int i = 0; i < numOfPlayers; i++)
            {
                GoFishPlayer p = new GoFishPlayer();

                p.Name = playerNames[i];
                p.IsAi = false;

                p.Hand = new List<Card>();

                Players.Add(p);
            }
        }

        private void StartGame()
        {
            SetupHands();
        }

        /// <summary>
        /// Deals each player 7 cards to add to their starting hand
        /// </summary>
        private void SetupHands()
        {
            foreach (GoFishPlayer gp in Players)
            {
                for (int i = 0; i < 7; i++)
                {
                    gp.Hand.Add(Deck.Draw());
                }
            }
        }

        private bool AskForCard(GoFishPlayer requestedPlayer)
        {
            //requestedPlayer.Hand.Where()

            return true;
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
        

        public override void SaveGame()
        {
            throw new NotImplementedException();
        }



    }
}
