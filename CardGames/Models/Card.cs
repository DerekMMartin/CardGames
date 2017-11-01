using CardGames.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models
{
    [Serializable]
    public class Card
    {
        public CardValue FaceValue { get; set; }
        public Suit FaceSuit { get; set; }


        public Card()
        {

        }

        public Card(int faceValue, Suit faceSuit)
        {
            FaceValue = (CardValue)faceValue;
            FaceSuit = faceSuit;
        }

        public override string ToString()
        {
            return $"{FaceValue} of {FaceSuit}";
        }
        public string Print()
        {
            string cardNumber = "";
            switch ((int)FaceValue)
            {
                case 1:
                    cardNumber = "A";
                    break;
                case 11:
                    cardNumber = "J";
                    break;
                case 12:
                    cardNumber = "Q";
                    break;
                case 13:
                    cardNumber = "K";
                    break;
                default:
                    cardNumber = (int)FaceValue +"";
                    break;
            }
            return cardNumber + FaceSuit.ToString().Substring(0, 1);
        }
    }
}
