using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    public class Player
    {
        public Player()
        {
            for(byte i = 1; i <= 10; i++)
            {
                Results.Add(new BowlingResult(i));
            }
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<BowlingResult> Results { get; set; } = new();
    }
}
