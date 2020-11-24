using System;
using System.Collections.Generic;

namespace Foosball
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public List<Set> Sets { get; set; }
    }
}
