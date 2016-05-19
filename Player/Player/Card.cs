using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public Card() 
        { }
    }

    public enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum CardSuit
    {
        Heart,      //Червы
        Diamond,    //Буби
        Club,       //Крести
        Spade       //Вини
    }
}
