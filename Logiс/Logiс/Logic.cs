﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Card = Cards.Card;
using Cards;


namespace Logiс
{
    public class Logic
    {
        //TODO: Change combinations' codes afted making codes' table
        public static int GetPlayerBestCombination(List<Card> hand, List<Card> table)
        {

            #region Create collection for the combination searching
            
            var set = new List<Card>();
            set.AddRange(hand);
            set.AddRange(table);

            #endregion

            if (IsOnlyOneSuit(set))
            {
                if (TryFindRoyalFlush(set))
                    return 100;

                if (TryFindStraightFlush(set))
                    return 90;

                //TODO: Here must be a returning of flush combination
                //TODO: but it depends on the hight card.
                return 10;
            }
            
        }

        public static List<Card> ExtractRoyalFlush(List<Card> set)
        {
            var dictionary = SplitBySuit(set);

            return (from pair in dictionary
                where pair.Value.Count >= 5
                where pair.Value.Any(card => card.Value == CardValue.Ten)
                where pair.Value.Any(card => card.Value == CardValue.Jack)
                where pair.Value.Any(card => card.Value == CardValue.Queen)
                where pair.Value.Any(card => card.Value == CardValue.King)
                select pair).Select(pair => pair.Value).ToList()[0];
        }

        public static List<Card> ExtractStraightFlush(List<Card> set)
        {
            #region Creating new cards' array

            var dictionary = SplitBySuit(set);

            var temp = (from pair in dictionary
                        where pair.Value.Count >= 5
                        select pair.Value).ToList();

            List<Card> list;

            if (temp.Count != 0)
                list = temp[0];
            else
                throw new Exception("Error in the method ExtractStraightFlush. Wrong array format");

            #endregion

            #region Processing the least Straight Flush combination
            
            var listForWheel = (from card in list
                where card.Value == CardValue.Ace
                      || card.Value == CardValue.Two
                      || card.Value == CardValue.Three
                      || card.Value == CardValue.Four
                      || card.Value == CardValue.Five
                select card).ToList();

            if (listForWheel.Count == 5)
                return listForWheel;

            #endregion

            var buf = list.Min();
            list.Sort();
            
            //Searching for the first card in the combination
            
            for (int i = 1; i <= 3; i++)
            {
                if (!(list.Any(card => card.Value == buf.Value + 1 && card.Suit == buf.Suit) &&
                      list.Any(card => card.Value == buf.Value + 2 && card.Suit == buf.Suit)))
                {
                    buf = set[i];

                    if (i == 3)
                        throw new Exception("Error in the method ExtractStraightFlush. There is'n a combination in the input array");
                }
                else
                    break;
            }

            return new List<Card>
            {
                buf,
                new Card(buf.Suit, buf.Value + 1),
                new Card(buf.Suit, buf.Value + 2),
                new Card(buf.Suit, buf.Value + 3)
            };
        }

        public static List<Card> ExtractFourOfAKind(List<Card> set)
        {
            
        }
        
        public static int CompareStraightFlush(List<Card> straightFlush_1, List<Card> straightFlush_2)
        {
            var value_1 = straightFlush_1.Max().Value;
            var value_2 = straightFlush_2.Max().Value;

            if (value_1 > value_2)
                return 1;

            if (value_1 < value_2)
                return -1;
            
            //Processing cases with Ace
            
            if (value_1 == CardValue.Ace)
            {
                var min_1 = straightFlush_1.Min().Value;
                var min_2 = straightFlush_2.Min().Value;

                if (min_1 > min_2)
                    return 1;

                if (min_1 < min_2)
                    return -1;
            }

            return 0;
        }

        public static int CompareFourOfAKind(List<Card> fourOfAKind_1, List<Card> fourOfAKind_2)
        {
            //TODO
            var fou
        }
 
#region Technical functions   
        private static bool IsOnlyOneSuit(List<Card> cards)
        {
            if (cards.Count == 0) 
                throw new Exception("Empty cards' array in the method IsOnlyOneSuit");

            var model = cards[0].Value;

            return cards.All(card => card.Value == model);
        }

        private static Dictionary<CardSuit, List<Card>> SplitBySuit(List<Card> cards)
        {
            var dictionary = new Dictionary<CardSuit, List<Card>>();

            foreach (var card in cards)
            {
                if (dictionary.ContainsKey(card.Suit))
                {
                    dictionary[card.Suit].Add(card);
                }
                else
                {
                    dictionary.Add(card.Suit, new List<Card> {card});
                }
            }

            return dictionary;
        }

        private static bool TryFindRoyalFlush(List<Card> set)
        {
            var dictionary = SplitBySuit(set);

            return (from pair in dictionary
                where pair.Value.Count >= 5
                where pair.Value.Any(card => card.Value == CardValue.Ten)
                where pair.Value.Any(card => card.Value == CardValue.Jack)
                where pair.Value.Any(card => card.Value == CardValue.Queen)
                where pair.Value.Any(card => card.Value == CardValue.King)
                select pair).Any(pair => pair.Value.Any(card => card.Value == CardValue.Ace));
        }

        private static bool TryFindStraightFlush(List<Card> set)
        {
            if (set.Count == 0)
                throw new Exception("Empty cards' array in the method TryFindStraightFlush");

            //We need to create new cards' array, because we need the card value repeats
            // only once in the array

            #region Creating new cards' array
 
            var dictionary = SplitBySuit(set);

            var temp = (from pair in dictionary
                where pair.Value.Count >= 5
                select pair.Value).ToList();

            List<Card> list;

            if (temp.Count != 0)
                list = temp[0];
            else
                return false;

            #endregion

            //Start searching from  the min value 
            var buf = list.Min();

            #region Cheking for the least Straight Flush combination

            if (buf.Value == CardValue.Two)
                if (list.Max().Value == CardValue.Ace)
                    if (list.Any(card => card.Value == CardValue.Three))
                        if (list.Any(card => card.Value == CardValue.Four))
                            return true;

            #endregion
            
            //So as there may be from five to seven cards in the input array
            //we must do some settings for count=6 and count=7

            if (list.Count == 6)
            {
                //For count=6 we must check only one extra if it belongs
                // the interval or not
                if (list.All(card => card.Value != buf.Value + 1))
                {
                    // And if not - chose the next card
                    list.Sort();
                    buf.Value = list[1].Value;
                    list.Remove(buf);
                }
            }
            else if (list.Count == 7)
            {
                //For count=7 we must check two extra cards
                
                if (list.All(card => card.Value != buf.Value + 1))
                {
                    list.Sort();
                    buf.Value = list[1].Value;

                    if (list.All(card => card.Value != buf.Value + 1))
                    {
                        buf.Value = list[2].Value;
                    }
                }
            }

            //At the end of the checking we should check the rest cards
 
            for (int i = 0; i < 4; i++)
            {
                if (list.Any(card => card.Value == buf.Value + 1))
                {
                    buf.Value++;
                }
                else
                    return false;
            }
            
            return true;
        }

        private static bool TryFindFourOfAKind(List<Card> set)
        {
            if (set.Count == 0)
                throw new Exception("Empty cards' array in the method TryFindFourOfAKind");
            
            var buf = set[0].Value;

            //Here we try find four same cards.
            //So as there may be from five to seven cards in the input array,
            // we decided to do extra iterations for count=5
            // instead of making settings for count=6 and count=7
            
            for (int i = 1; i <= 3; i++)
            {
                if (set.Count(card => card.Value == buf) != 4)
                {
                    buf = set[i].Value;
                }
                else
                    return true;
            }

            return false;
        }
    }
#endregion
}
