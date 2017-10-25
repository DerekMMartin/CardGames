using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public class WarPlayer : Player
    {

        public List<Card> DrawPile { get; set; }
        public List<Card> DiscardPile { get; set; }

    }
}
