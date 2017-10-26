using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public class BlackJackPlayer : Player
    {
        public int Money { get; set; }
        public int Bet { get; set; }
        public BlackJackPlayer(string name)
        {
            Name = name;
            Money = 20;
        }
    }
}
