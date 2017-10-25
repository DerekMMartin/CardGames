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
        public GoFishController(int players, List<string> playerNames)
        {
            for (int i = 0; i < players; i++)
            {
                GoFishPlayer p = new GoFishPlayer();

                p.Name = playerNames[i];
                p.IsAi = false;

                p.Hand = new List<Card>();

                Players.Add(p);
            }
        }


    }
}
