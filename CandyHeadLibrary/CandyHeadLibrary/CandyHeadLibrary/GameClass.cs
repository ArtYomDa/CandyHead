using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CandyHeadLibrary
{
    public class GameClass
    {
        #region Instance

        private static GameClass _instance;
        public static GameClass GetInstance()
        {
            if (_instance == null)
                _instance = new GameClass();
            return _instance;
        }

        #endregion

        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();

        private DeckClass _deck = new DeckClass();

        private readonly List<Card> _table = new List<Card>();

        public Dictionary<int, Player> Players { get { return _players; } }

        public DeckClass Deck { get { return _deck; } }

        public List<Card> Table { get { return _table; } }

        public int CurrentBet { get; set; }

        public int ReraiseAmmount { get; set; }

        public void ResetDeck()
        {
            _deck = new DeckClass();
        }

        public void Raise(int id, int bet)
        {
            var player = _players[id];

            player.Cash -= bet;
            player.Bet += bet;
            CurrentBet = bet;

            ReraiseAmmount++;
        }

        public void Call(int id)
        {
            var player = _players[id];

            player.Cash -= CurrentBet - player.Bet;
            player.Bet = CurrentBet;
        }

        
    }
}
