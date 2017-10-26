using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.GameControllers
{
    public class BlackJackController : Game
    {
        public BlackJackController(string[] names)
        {
            FileExtension = ".bjsav";
            Deck = new Deck();
            Players = new List<Player>();
            Players.Add(new BlackJackPlayer("House") { IsAi = true });
            for(int i = 0; i < names.Count(); i++)
            {
                Players.Add(new BlackJackPlayer(names[i]));
            }
            StartGame();
        }

        private void StartGame()
        {
            GetPlayerBets();
        }

        private void GetPlayerBets()
        {

        }

        public override void SaveGame()
        {
            throw new NotImplementedException();
        }
    }
}
