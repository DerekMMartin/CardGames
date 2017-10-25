using CardGames.Models;
using CardGames.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.GameControllers
{
    public class WarController
    {
        public WarPlayer Player1 { get; set; }
        public WarPlayer Player2 { get; set; }
        public bool IsPvP { get; set; }

        public WarController(string Player1Name)
        {

        }

        public WarController(string Player1Name, string Player2Name)
        {

        }

        public void DealCards()
        {
            Deck deck = new Deck();
            for (int i = 0; i < deck.Cards.Count();  i += 2)
            {
                Player1.DrawPile.Add(deck.Draw());
                Player2.DrawPile.Add(deck.Draw());
            }
        }

        public void Draw()
        {

        }

    }
}
