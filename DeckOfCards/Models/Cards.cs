using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{

    public class Set
    {
        public bool success { get; set; }
        public Cards[] cards { get; set; }
        public string deck_id { get; set; }
        public int remaining { get; set; }
    }

    public class Cards
    {
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }

}
