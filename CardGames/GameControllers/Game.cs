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
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; }
        public virtual string FileExtension { get; set; }

    }
}
