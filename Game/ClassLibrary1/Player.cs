﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class Player
    {
        public List<Cards.Card> Hand;
        public int Cash { get; set; }
        public int Id { get; set; }
        public int Combination { get; set; }
        
    }
}