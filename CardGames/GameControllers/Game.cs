using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.GameControllers
{
    public abstract class Game
    {
        public List<BlackjackPlayer> Players { get; set; }
        public Deck Deck { get; set; }
        public string FileExtension { get; set; }

        public abstract void SaveGame();
    }
}
