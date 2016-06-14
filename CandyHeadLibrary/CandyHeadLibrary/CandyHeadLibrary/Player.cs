using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CandyHeadLibrary
{
    public class Player
    {
        public List<Card> Hand;
        public int Cash { get; set; }
        public int Id { get; set; }
        public int Combination { get; set; }
        public int Bet { get; set; }
        
    }
}
