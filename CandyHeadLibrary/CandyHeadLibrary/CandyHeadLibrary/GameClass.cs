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

        private readonly List<Player> _players = new List<Player>();

        private readonly DeckClass _deck = new DeckClass();

        public List<Player> Players { get { return _players; } }

        public DeckClass Deck { get { return _deck; } }


    }
}
