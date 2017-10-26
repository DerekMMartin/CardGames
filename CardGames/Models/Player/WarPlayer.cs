﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public class WarPlayer : BlackjackPlayer
    {

        public List<Card> DrawPile { get; set; }
        public List<Card> DiscardPile { get; set; }
        public Card FlippedCard { get; set; }
        public List<Card> CardsAtRisk { get; set; }

        public Card Draw()
        {
            if(DrawPile.Count == 0)
            {
                Shuffle();
            }
            Card card = DrawPile.First();
            FlippedCard = card;
            DrawPile.Remove(card);
            return card;
        }

        public Card War()
        {
            if(DrawPile.Count == 0)
            {
                Shuffle();
            }
            CardsAtRisk.Add(FlippedCard);
            CardsAtRisk.Add(DrawPile.First());
            DrawPile.Remove(DrawPile.First());
            return Draw();
        }

        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < DiscardPile.Count();)
            {
                DrawPile.Add(DiscardPile[rand.Next(DiscardPile.Count())]);
            }
        }

    }
}
