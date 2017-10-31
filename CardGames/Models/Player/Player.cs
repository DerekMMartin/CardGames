using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    [Serializable]
    public abstract class Player
    {
        public string Name { get; set; }
        public bool IsAi { get; set; }
        public List<Card> Hand { get; set; }

    }
}
