using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;
using Card = Cards.Card;

namespace DeckNamespace
{
    public class DeckClass
    {
        private List<Card> _cards;
        private Random _random = new Random();

        public DeckClass()
        {
            var cards = new List<Card>();

            //Creating cards' array
            var suit = CardSuit.Club;
            
            for (int i = 0; i < 4; i++)
            {
                var value = CardValue.Two;
                
                for (int j = 0; j < 13; j++)
                {
                    cards.Add(new Card(suit, value));
                    value++;
                }

                suit++;
            }

            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i);
                var tmp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = tmp;
            }
        }

        public Card GetCard()
        {
            if (_cards.Count == 0)
                return null;

            var card = _cards[0];
            _cards.Remove(card);
            return card;
        }
    }
}
