using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class Player
    {
        public List<Card.Card> Hand;
        public int Cash { get; set; }
        public int Id { get; set; }
    }
}
