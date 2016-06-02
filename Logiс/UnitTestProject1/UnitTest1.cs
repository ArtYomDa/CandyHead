using System;
using System.Collections.Generic;
using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Card = Cards.Card;
using Logiсa = Logiс.LogicClass;

namespace TestingPrivateMethods
{
    [TestClass]
    public class UnitTest1
    {
        //WARNING: before testing make sure that testing methods turned to publik

        #region True
        [TestMethod]
        public void TestIsOnlyOneSuit()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace)
            };

            Assert.IsTrue(Logiсa.IsOnlyOneSuit(cards));
        }

        [TestMethod]
        public void TestSplitBuSuit()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Ace)
            };

            Assert.IsTrue(Logiсa.SplitBySuit(cards).Count == 4);
        }

        [TestMethod]
        public void TestCompareCombinationsWithKickers()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Eight)
            };

            Assert.IsTrue(Logiсa.CompareCombinationsWithKickers(cards1, cards2, 1) == 1);
        }

        [TestMethod]
        public void TestTryFindRoyalFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsTrue(Logiсa.TryFindRoyalFlush(cards));
        }

        [TestMethod]
        public void TestTryFindStraightFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsTrue(Logiсa.TryFindStraightFlush(cards));
        }

        [TestMethod]
        public void TestTryFindFourOfAKind()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsTrue(Logiсa.TryFindFourOfAKind(cards));
        }

        [TestMethod]
        public void TestTryFindFullHouse()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Diamond, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Jack)
            };

            Assert.IsTrue(Logiсa.TryFindFullHouse(cards));
        }

        [TestMethod]
        public void TestTryFindPair()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Jack)
            };

            Assert.IsTrue(Logiсa.TryFindPair(cards));
        }

        [TestMethod]
        public void TestTryFindSet()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Jack)
            };

            Assert.IsTrue(Logiсa.TryFindSet(cards));
        }

        [TestMethod]
        public void TestTryFindFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsTrue(Logiсa.TryFindFlush(cards));
        }

        [TestMethod]
        public void TestTryFindStraight()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsTrue(Logiсa.TryFindStraight(cards));
        }

        [TestMethod]
        public void TestTryFindTwoPairs()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Four)
            };

            Assert.IsTrue(Logiсa.TryFindTwoPairs(cards));
        }

        [TestMethod]
        public void TestExtract()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Four)
            };

            Assert.IsTrue(Logiсa.TryFindTwoPairs(cards));
        }
#endregion

        #region False
        [TestMethod]
        public void TestIsOnlyOneSuit_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Four),
                new Card(CardSuit.Spade, CardValue.Four),
                new Card(CardSuit.Heart, CardValue.Eight)
            };

            Assert.IsFalse(Logiсa.IsOnlyOneSuit(cards));
        }

        [TestMethod]
        public void TestTryFindRoyalFlush_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsFalse(Logiсa.TryFindRoyalFlush(cards));
        }

        [TestMethod]
        public void TestTryFindStraightFlush_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsFalse(Logiсa.TryFindStraightFlush(cards));
        }

        [TestMethod]
        public void TestTryFindFourOfAKind_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsFalse(Logiсa.TryFindFourOfAKind(cards));
        }

        [TestMethod]
        public void TestTryFindFullHouse_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Jack),
                new Card(CardSuit.Heart, CardValue.Jack)
            };

            Assert.IsFalse(Logiсa.TryFindFullHouse(cards));
        }

        [TestMethod]
        public void TestTryFindPair_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack)
            };

            Assert.IsFalse(Logiсa.TryFindPair(cards));
        }

        [TestMethod]
        public void TestTryFindSet_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Jack)
            };

            Assert.IsFalse(Logiсa.TryFindSet(cards));
        }

        [TestMethod]
        public void TestTryFindFlush_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsFalse(Logiсa.TryFindFlush(cards));
        }

        [TestMethod]
        public void TestTryFindStraight_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten)
            };

            Assert.IsFalse(Logiсa.TryFindStraight(cards));
        }

        [TestMethod]
        public void TestTryFindTwoPairs_false()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Five),
                new Card(CardSuit.Club, CardValue.Four)
            };

            Assert.IsFalse(Logiсa.TryFindTwoPairs(cards));
        }
#endregion
    }
}
