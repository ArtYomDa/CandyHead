using System;
using System.Collections.Generic;
using System.Linq;
using Cards;
using Logiс;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestingInterface
{
    [TestClass]
    public class UnitTest1
    {
        #region Ectract Functions

        [TestMethod]
        public void TestExtractRoyalFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten )
            };
            
            var buf = LogicClass.ExtractRoyalFlush(cards);

            Assert.IsTrue(LogicClass.TryFindRoyalFlush(buf));
        }

        [TestMethod]
        public void TestExtractStraightFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var buf = LogicClass.ExtractStraightFlush(cards);

            Assert.IsTrue(LogicClass.TryFindStraightFlush(buf));
        }

        [TestMethod]
        public void TestExtractFourOfAKind()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten )
            };

            var buf = LogicClass.ExtractFourOfAKind(cards);

            Assert.IsTrue(LogicClass.TryFindFourOfAKind(buf));
        }

        [TestMethod]
        public void TestExtractFullHouse()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Diamond, CardValue.Ace),
                new Card(CardSuit.Heart, CardValue.Ace),
                new Card(CardSuit.Spade, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten )
            };

            var buf = LogicClass.ExtractFullHouse(cards);

            Assert.IsTrue(LogicClass.TryFindFullHouse(buf));
        }

        [TestMethod]
        public void TestExtractFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var buf = LogicClass.ExtractFlush(cards);

            Assert.IsTrue(LogicClass.TryFindFlush(buf));
        }

        [TestMethod]
        public void TestExtractStraight()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var buf = LogicClass.ExtractStraight(cards);

            Assert.IsTrue(LogicClass.TryFindStraight(buf));
        }

        [TestMethod]
        public void TestExtractSet()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var buf = LogicClass.ExtractSet(cards);

            Assert.IsTrue(LogicClass.TryFindSet(buf));
        }

        [TestMethod]
        public void TestExtractTwoPairs()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Diamond, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var buf = LogicClass.ExtractTwoPairs(cards);

            Assert.IsTrue(LogicClass.TryFindTwoPairs(buf));
        }

        [TestMethod]
        public void TestExtractPair()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ace),
                new Card(CardSuit.Club, CardValue.King),
                new Card(CardSuit.Club, CardValue.Queen),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var buf = LogicClass.ExtractPair(cards);

            Assert.IsTrue(LogicClass.TryFindPair(buf));
        }

#endregion

        [TestMethod]
        public void TestCompareStraightFlush()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Three),
                new Card(CardSuit.Club, CardValue.Four),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            Assert.IsTrue(
                LogicClass.CompareStraightFlush(LogicClass.ExtractStraightFlush(cards1),
                    LogicClass.ExtractStraightFlush(cards2)) == 1);
        }

        [TestMethod]
        public void TestCompareCompareFourOfAKind()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Spade, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Heart, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Five),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            Assert.IsTrue(
                LogicClass.CompareFourOfAKind(LogicClass.ExtractFourOfAKind(cards1),
                    LogicClass.ExtractFourOfAKind(cards2)) == -1);
        }

        [TestMethod]
        public void TestCompareFullHouse()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Spade, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Spade, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            Assert.IsTrue(
                LogicClass.CompareFullHouse(LogicClass.ExtractFullHouse(cards1),
                    LogicClass.ExtractFullHouse(cards2)) == 0);
        }
        
        [TestMethod]
        public void TestCompareFlush()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Ten )
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Club, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Eight),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten),
                new Card(CardSuit.Spade, CardValue.Ten )
            };

            Assert.IsTrue(
                LogicClass.CompareFlush(LogicClass.ExtractFlush(cards1),
                    LogicClass.ExtractFlush(cards2)) == -1);
        }

        [TestMethod]
        public void TestCompareStraight()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Eight),
                new Card(CardSuit.Diamond, CardValue.Seven),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten),
            };

            Assert.IsTrue(
                LogicClass.CompareStraight(LogicClass.ExtractStraight(cards1),
                    LogicClass.ExtractStraight(cards2)) == 0);
        }

        [TestMethod]
        public void TestCompareSet()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Nine),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Jack),
            };

            Assert.IsTrue(
                LogicClass.CompareSet(LogicClass.ExtractSet(cards1),
                    LogicClass.ExtractSet(cards2)) == -1);
        }

        [TestMethod]
        public void TestCompareTwoPairs()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Diamond, CardValue.Jack)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            Assert.IsTrue(
                LogicClass.CompareTwoPairs(LogicClass.ExtractTwoPairs(cards1),
                    LogicClass.ExtractTwoPairs(cards2)) == 1);
        }

        [TestMethod]
        public void TestComparePairs()
        {
            var cards1 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Jack),
                new Card(CardSuit.Diamond, CardValue.Jack)
            };

            var cards2 = new List<Card>
            {
                new Card(CardSuit.Club, CardValue.Nine),
                new Card(CardSuit.Heart, CardValue.Nine),
                new Card(CardSuit.Diamond, CardValue.Two),
                new Card(CardSuit.Club, CardValue.Six),
                new Card(CardSuit.Club, CardValue.Ten),
                new Card(CardSuit.Diamond, CardValue.Ten)
            };

            Assert.IsTrue(
                LogicClass.ComparePair(LogicClass.ExtractPair(cards1),
                    LogicClass.ExtractPair(cards2)) == 1);
        }
    }


}
