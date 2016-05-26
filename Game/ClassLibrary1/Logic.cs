using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Card = Cards.Card;
using Cards;


namespace Logiс
{
    public static class LogicClass
    {
        //TODO: Change combinations' codes afted making codes' table
        public static int GetPlayerBestCombination(List<Card> hand, List<Card> table)
        {

            #region Create collection for the combination searching
            
            var set = new List<Card>();
            set.AddRange(hand);
            set.AddRange(table);

            #endregion

            if (TryFindRoyalFlush(set))
                return 10;

            if (TryFindStraightFlush(set))
                return 9;

            if (TryFindFourOfAKind(set))
                return 8;

            if (TryFindFullHouse(set))
                return 7;
            
            if (TryFindFlush(set))
                return 6;

            if (TryFindStraight(set))
                return 5;

            if (TryFindSet(set))
                return 4;

            if (TryFindTwoPairs(set))
                return 3;

            if (TryFindPair(set))
                return 2;

            return 1;
        }

        #region Extract Functions

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
            
            for (int i = 1; i <= 4; i++)
            {
                if (!(list.Any(card => card.Value == buf.Value + 1 && card.Suit == buf.Suit) &&
                      list.Any(card => card.Value == buf.Value + 2 && card.Suit == buf.Suit) &&
                      list.Any(card => card.Value == buf.Value + 3 && card.Suit == buf.Suit)))
                {
                    buf = set[i];

                    if (i == 4)
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
                new Card(buf.Suit, buf.Value + 3),
                new Card(buf.Suit, buf.Value + 4)
            };
        }

        public static List<Card> ExtractFourOfAKind(List<Card> set)
        {
            if (set.Count == 0)
                throw new Exception("Empty cards' array in the method ExtractFourOfAKind");
            
            // Create new card array, because we need to have oportunity
            // to remove cards from the array

            List<Card> _set = new List<Card>(set);
            
            var fourOfAKindCard = _set[0];
            int i = 1;

            while (_set.Count(card1 => card1.Value == fourOfAKindCard.Value) != 4)
            {
                if (i == _set.Count)
                    throw new Exception(
                        "Error in the mothod ExtractFourOfAKind. There isn't valid combination in the array");

                fourOfAKindCard = _set[i];
                i++;
            }

            var list = (from card in _set
                where card.Value == fourOfAKindCard.Value
                select card).ToList();

            _set.RemoveAll(card => card.Value == fourOfAKindCard.Value);

            list.Add(_set.Max());

            return list;
        }

        public static List<Card> ExtractFullHouse(List<Card> set)
        {
            List<Card> rezult = new List<Card>();

            rezult.AddRange(ExtractSet(set));
            rezult.AddRange(ExtractPair(set));

            return rezult;
        }
        
        public static List<Card> ExtractFlush(List<Card> set)
        {
            var dictionary = SplitBySuit(set);

            //Gother cards with same suits 
            
            var listSameSuit = (from pair in dictionary
                where pair.Value.Count >= 5
                select pair.Value).ToList()[0];
            
            //Then remove the least card, until there will be five cards in the array

            while (listSameSuit.Count != 5)
                listSameSuit.Remove(listSameSuit.Min());

            return listSameSuit;
        }

        public static List<Card> ExtractStraight(List<Card> set)
        {
            #region Processing the least Straight Flush combination

            var listForWheel = (from card in set
                                where card.Value == CardValue.Ace
                                      || card.Value == CardValue.Two
                                      || card.Value == CardValue.Three
                                      || card.Value == CardValue.Four
                                      || card.Value == CardValue.Five
                                select card).ToList();

            if (listForWheel.Count == 5)
                return listForWheel;

            #endregion

            var buf = set.Min();
            set.Sort();

            //Searching for the first card in the combination

            for (int i = 1; i <= 4; i++)
            {
                if (!(set.Any(card => card.Value == buf.Value + 1) &&
                      set.Any(card => card.Value == buf.Value + 2) &&
                      set.Any(card => card.Value == buf.Value + 3)))
                {
                    buf = set[i];

                    if (i == 4)
                        throw new Exception("Error in the method ExtractStraight. There is'n a combination in the input array");
                }
                else
                    break;
            }

            return new List<Card>
            {
                buf,
                set.Find(card => card.Value == buf.Value + 1),
                set.Find(card => card.Value == buf.Value + 2),
                set.Find(card => card.Value == buf.Value + 3),
                set.Find(card => card.Value == buf.Value + 4)
            };
        }

        public static List<Card> ExtractSet(List<Card> cards)
        {
            var list = new List<Card>(cards);
            List<Card> rezult = new List<Card>();
            
            for (int i = 0; i < list.Count && list.Count > 3; i++)
            {
                var card = list[i];
                
                //If there is Set in the input array
                
                if (list.Count(card1 => card1.Value == card.Value) == 3)
                {
                    // take it
                    var range = list.FindAll(card1 => card1.Value == card.Value);
                    
                    // and if it is greater than a preveous one
                    if (rezult.Count != 0)
                        if (range.Max().Value <= rezult.Max().Value) 
                            continue;

                    // put it in the output array
                    rezult.Clear();
                    rezult.AddRange(range);
                    
                    //Remove finded Set from array
                    list.RemoveAll(card1 => card1.Value == card.Value);
                    i = -1;     //reset i
                }
            }
            
            //Put kickers in the output array
            
            list = new List<Card>(cards);
            rezult.ForEach(card => list.Remove(card));

            rezult.Add(list.Max());
            list.Remove(list.Max());
            rezult.Add(list.Max());

            return rezult;
        }

        public static List<Card> ExtractTwoPairs(List<Card> set)
        {
            var list = new List<Card>(set);
            List<Card> rezult = new List<Card>();

            for (int i = 0; i < 2; i++)
            {
                var buf = ExtractPair(list);
                
                rezult.Add(buf[0]);
                rezult.Add(buf[1]);

                var key = buf[0];
                list.RemoveAll(card => card.Value == key.Value);

                var value = CardValue.Two;

                //We have removed two cards from list and there can be less then 5 cars. This is unacceptable.
                //So we put two other cards into list and have checked before that these cards won't make extra Pairs
                for (int j = 0; j < 2; j++)
                {
                    while (true)
                    {
                        if (value > CardValue.Ace)
                            throw new Exception("Unknown error in the method EctractTwoPairs");

                        if (list.Any(card => card.Value == value))
                            value++;
                        else
                        {
                            list.Add(new Card(CardSuit.Club, value));
                            break;
                        }
                    }
                }
                
            }

            rezult.Add(list.Max());

            return rezult;
        }

        public static List<Card> ExtractPair(List<Card> set)
        {
            var list = new List<Card>(set);
            List<Card> rezult = new List<Card>();

            //for (int i = 0; i < 5 && i < list.Count; i++)
            //{
            //    var card = set[i];

            //    if (set.Count(card1 => card1.Value == card.Value) == 2)
            //    {
            //        rezult.Add(card);
            //        list.Remove(card);
            //        rezult.Add(list.Find(card1 => card1.Value == card.Value));

            //        break;
            //    }
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    rezult.Add(list.Max());
            //    list.Remove(list.Max());
            //}

            //return rezult;

            for (int i = 0; i < list.Count && list.Count >= 2; i++)
            {
                var card = list[i];

                //If there is Pair in the input array

                if (list.Count(card1 => card1.Value == card.Value) >= 2)
                {
                    // take it
                    var range = list.FindAll(card1 => card1.Value == card.Value);

                    // and if it is greater than a preveous one
                    if (rezult.Count != 0)
                        if (range.Max().Value <= rezult.Max().Value)
                            continue;

                    // put it in the output array
                    rezult.Clear();
                    rezult.AddRange(range);

                    //Remove finded Pair from array
                    list.RemoveAll(card1 => card1.Value == card.Value);
                    i = -1; //reset i
                }
            }

            //Initialize list with the input array without Pair for adding kickers
            list = new List<Card>(set);
            rezult.ForEach(card => list.Remove(card));

            for (int i = 0; i < 3; i++)
            {
                rezult.Add(list.Max());
                list.Remove(list.Max());
            }

            return rezult;
        }

        #endregion        
        
        #region Compare Functions

        public static int CompareStraightFlush(List<Card> straightFlush_1, List<Card> straightFlush_2)
        {
            return CompareStraight(straightFlush_1, straightFlush_2);
        }

        public static int CompareFourOfAKind(List<Card> fourOfAKind_1, List<Card> fourOfAKind_2)
        {
            //Notice: combination in the array starts with four same cards and ends with kicker.
            //So array must be got from the Extract function

            return CompareCombinationsWithKickers(fourOfAKind_1, fourOfAKind_2, 4);
        }

        public static int CompareFullHouse(List<Card> fullHouse_1, List<Card> fullHouse_2)
        {
            return CompareCombinationsWithKickers(fullHouse_1, fullHouse_2, 3);
        }
        
        public static int CompareFlush(List<Card> flush_1, List<Card> flush_2)
        {
            var value_1 = flush_1.Max().Value;
            var value_2 = flush_2.Max().Value;

            if (value_1 > value_2)
                return 1;

            if (value_1 < value_2)
                return -1;

            return 0;
        }
        
        public static int CompareStraight(List<Card> straight_1, List<Card> straight_2)
        {
            var value_1 = straight_1.Max().Value;
            var value_2 = straight_2.Max().Value;

            if (value_1 > value_2)
                return 1;

            if (value_1 < value_2)
                return -1;

            //Processing cases with Ace

            if (value_1 == CardValue.Ace)
            {
                var min_1 = straight_1.Min().Value;
                var min_2 = straight_2.Min().Value;

                if (min_1 > min_2)
                    return 1;

                if (min_1 < min_2)
                    return -1;
            }

            return 0;
        }

        public static int CompareSet(List<Card> set_1, List<Card> set_2)
        {
            //Notice: the first three card in the arrays are Sets
            //The rest are kickers in discending order

            return CompareCombinationsWithKickers(set_1, set_2, 3);
        }

        public static int CompareTwoPairs(List<Card> twoPairs_1, List<Card> twoPairs_2)
        {
            return CompareCombinationsWithKickers(twoPairs_1, twoPairs_2, 4);
        }

        public static int ComparePair(List<Card> pair_1, List<Card> pair_2)
        {
            //Notice: the first two card in the arrays are Pairs
            //The rest are kickers in discending order

            return CompareCombinationsWithKickers(pair_1, pair_2, 2);
        }
        
        #endregion

        #region TryFind functions  

        public static bool IsOnlyOneSuit(List<Card> cards)
        {
            if (cards.Count == 0) 
                throw new Exception("Empty cards' array in the method IsOnlyOneSuit");

            var model = cards[0].Value;

            return cards.All(card => card.Value == model);
        }

        public static Dictionary<CardSuit, List<Card>> SplitBySuit(List<Card> cards)
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

        public static int CompareCombinationsWithKickers(List<Card> comb_1, List<Card> comb_2, int kickerIndex)
        {
            var card_1 = comb_1[0];
            var card_2 = comb_2[0];

            if (card_1.Value == card_2.Value)
            {
                card_1 = comb_1[kickerIndex];
                card_2 = comb_2[kickerIndex];
            }

            if (card_1.Value > card_2.Value)
                return 1;

            if (card_1.Value < card_2.Value)
                return -1;

            return 0;
        }


        public static bool TryFindRoyalFlush(List<Card> set)
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

        public static bool TryFindStraightFlush(List<Card> set)
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

            return TryFindStraight(list);
        }

        public static bool TryFindFourOfAKind(List<Card> set)
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

        public static bool TryFindFullHouse(List<Card> set)
        {
            var list = new List<Card>(set);

            if (TryFindPair(list))
            {
                var pair = ExtractPair(list);

                var key = pair[0];

                list.RemoveAll(card => card.Value == key.Value);

                if (TryFindSet(list))
                    return true;
            }

            return false;
        }

        public static bool TryFindFlush(List<Card> set)
        {
            var dictionary = SplitBySuit(set);

            if (dictionary.Any(pair => pair.Value.Count >= 5))
                return true;

            return false;
        }

        public static bool TryFindStraight(List<Card> set)
        {
            if (set.Count == 0)
                throw new Exception("Empty cards' array in the method TryFindStraight");
            
            //Start searching from  the min value 
            var buf = set.Min();

            #region Cheking for the least Straight Flush combination

            if (buf.Value == CardValue.Two)
                if (set.Max().Value == CardValue.Ace)
                    if (set.Any(card => card.Value == CardValue.Three))
                        if (set.Any(card => card.Value == CardValue.Four))
                            return true;

            #endregion

            //So as there may be from five to seven cards in the input array
            //we must do some settings for count=6 and count=7

            if (set.Count == 6)
            {
                //For count=6 we must check only one extra if it belongs
                // the interval or not
                if (set.All(card => card.Value != buf.Value + 1))
                {
                    // And if not - chose the next card
                    set.Sort();
                    buf.Value = set[1].Value;
                    set.Remove(buf);
                }
            }
            else if (set.Count == 7)
            {
                //For count=7 we must check two extra cards

                if (set.All(card => card.Value != buf.Value + 1))
                {
                    set.Sort();
                    buf.Value = set[1].Value;

                    if (set.All(card => card.Value != buf.Value + 1))
                    {
                        buf.Value = set[2].Value;
                    }
                }
            }

            //At the end of the checking we should check the rest cards

            for (int i = 0; i < 4; i++)
            {
                if (set.Any(card => card.Value == buf.Value + 1))
                {
                    buf.Value++;
                }
                else
                    return false;
            }

            return true;
        }

        public static bool TryFindSet(List<Card> cards)
        {
            if (cards.Count == 0)
                throw new Exception("Empty cards' array in the method TryFindSet");

            //Here we try find four same cards.
            //So as there may be from five to seven cards in the input array,
            // we decided to do extra iterations 
            // instead of making settings for count=6 and count=7

            return cards.Any(card => cards.Count(card1 => card1.Value == card.Value) >= 3);
        }

        public static bool TryFindTwoPairs(List<Card> set)
        {
            var list = new List<Card>(set);
            
            for (int i = 0; i < 2; i++)
            {
                if (TryFindPair(list))
                {
                    var pair = ExtractPair(list);
                    var key = pair[0];
                    list.RemoveAll(card => card.Value == key.Value);
                }
                else
                    return false;
            }

            return true;
        }

        public static bool TryFindPair(List<Card> set)
        {
            if (set.Count == 0)
                throw new Exception("Empty cards' array in the method TryFindPair");

            var list = new List<Card>(set);
            return list.Any(card => list.Count(card1 => card1.Value == card.Value) >= 2);
        }

        #endregion

    }

}
