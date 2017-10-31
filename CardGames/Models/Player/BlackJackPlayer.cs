using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Models.Player
{
    public class BlackJackPlayer : Player,INotifyPropertyChanged
    {
        private int bank;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Bank
        {
            get { return bank; }
            set { bank = value; FieldChanged(); }
        }

        public int Bet { get; set; }

        public List<Card> SplitHand { get; set; }
        public BlackJackPlayer(string name)
        {
            Name = name;
            Bank = 20;
            Hand = new List<Card>();
            SplitHand = new List<Card>();
        }


        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
