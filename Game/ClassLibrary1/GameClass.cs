using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deck = DeckNamespace.DeckClass;
using Player = Players.Player;

namespace Game
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

        private readonly Deck _deck = new Deck();

        public List<Player> Players { get { return _players; } }

        public Deck Deck { get { return _deck; } }


    }
}
