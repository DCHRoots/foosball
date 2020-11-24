using System;

namespace Foosball
{
    public class Goal
    {
        public Goal(DateTime date)
        {
            this.Date = date;
        }
        public DateTime Date { get; set; }
    }
}
