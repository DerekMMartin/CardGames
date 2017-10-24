﻿using CardGames.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models
{
    public class Card
    {
        public int FaceValue { get; set; }
        public Suit FaceSuit { get; set; }


        public Card()
        {

        }

        public Card(int faceValue, Suit faceSuit)
        {
            FaceValue = faceValue;
            FaceSuit = faceSuit;
        }

        public override string ToString()
        {
            return $"{FaceValue} of {FaceSuit}";
        }
    }
}
