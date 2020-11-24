using System;
using System.Collections.Generic;

namespace Foosball
{
    public class Set
    {
        public DateTime StartDate { get; set; }

        public List<Goal> Goals { get; set; }
        public Team Team { get; set; }
    }
}
