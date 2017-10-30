using CardGames.Models;
using CardGames.Models.Player;
using CardGames.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CardGames.GameControllers
{
    public class BlackJackController : Game
    {
        public MainWindow Window { get; set; }
        public BlackJackGame GameWindow{ get; set; }
        public BlackJackPlayer House { get; set; }
        //add list of player UCs
        //bind them to players
        //update players and UC status each turn
        //Rotate UC appearance in StackPanel
        public BlackJackController(MainWindow m,BlackJackGame w,string[] names)
        {
            Window = m;
            GameWindow = w;
            FileExtension = ".bjsav";
            GDeck = new Deck();
            House=new BlackJackPlayer("House") { IsAi = true };
            Players = new List<Player>();
            for(int i = 0; i < names.Count(); i++)
            {
                Players.Add(new BlackJackPlayer(names[i]));
            }
            StartGame();

        }

        private void StartGame()
        {
            for(int i = 1; i < Players.Count; i++)
            {
                GameWindow.playerlist.Children.Add(new BlackJackPlayerDisplay((BlackJackPlayer)Players[i]));
            }
            GameWindow.cplayerdisplay.Children.Add(new BlackJackPlayerDisplay((BlackJackPlayer)Players[0]));
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
