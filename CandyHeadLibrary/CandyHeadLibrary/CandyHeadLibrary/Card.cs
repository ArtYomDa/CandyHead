using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CandyHeadLibrary
{
    public class Card : IComparable<Card>
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

        public int CompareTo(Card other)
        {
            if (Value < other.Value)
                return -1;

            if (Value == other.Value)
                return 0;

            return 1;
        }
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
