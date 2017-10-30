using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public class BlackJackPlayer : Player
    {
        public int Bank { get; set; }
        public int Bet { get; set; }
        public List<Card> SplitHand { get; set; }
        public BlackJackPlayer(string name)
        {
            Name = name;
            Bank = 20;
            Hand = new List<Card>();
            SplitHand = new List<Card>();
        }
    }
}
