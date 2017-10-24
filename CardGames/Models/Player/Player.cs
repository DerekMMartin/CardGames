﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public abstract class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

    }
}
