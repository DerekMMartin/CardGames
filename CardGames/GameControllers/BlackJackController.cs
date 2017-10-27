using CardGames.Models;
using CardGames.Models.Player;
using CardGames.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.GameControllers
{
    public class BlackJackController : Game
    {
        public MainWindow Window { get; set; }
        public BlackJackGame GameWindow{ get; set; }
        //add list of player UCs
        //bind them to players
        //update players and UC status each turn
        //Rotate UC appearance in StackPanel
        public BlackJackController(string[] names)
        {
            FileExtension = ".bjsav";
            Deck = new Deck();
            Players.Add(new BlackJackPlayer("House") { IsAi = true });
            for(int i = 0; i < names.Count(); i++)
            {
                Players.Add(new BlackJackPlayer(names[i]));
            }
            StartGame();

        }

        private void StartGame()
        {
            while (Hand());
        }

        private bool Hand()
        {
            GetPlayerBets();






            return true;
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
