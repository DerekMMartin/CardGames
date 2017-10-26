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

        /// <summary>
        /// Deals each player 7 cards to add to their starting hand
        /// </summary>
        public void SetupHands()
        {
            foreach (GoFishPlayer gp in Players)
            {
                for (int i = 0; i < 7; i++)
                {
                    gp.Hand.Add(Deck.Draw());
                }
            }
        }

        private void StartGame()
        {
            SetupHands();
        }

    }
}
