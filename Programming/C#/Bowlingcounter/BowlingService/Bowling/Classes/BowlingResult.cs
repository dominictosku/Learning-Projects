using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Classes
{
    public enum BowlingRoll
    {
        Strike,
        Spare,
        Normal,
        Miss
    }

    public class BowlingResult
    {
        public const int MAXPINS = 10;

        private int pinsStanding = MAXPINS;
        public BowlingResult(short frame) 
        {
            Frame = frame;
        }

        public short Frame { get; set; }
        public byte Round { get; set; }
        public int Points => PinsPerRound.Sum(x => x);
        public int[] PinsPerRound { get; set; } = new int[3] { 0,0,0 };
        public BowlingRoll[] RollResultPerRound { get; set; } = new BowlingRoll[3] { BowlingRoll.Miss, BowlingRoll.Miss, BowlingRoll.Miss };
        public int PinsStanding
        {
            get
            {
                return pinsStanding;
            }
            set
            {
                pinsStanding = value;
                if (pinsStanding < 0)
                {
                    pinsStanding = 0;
                }
            }
        }

        public bool FrameOver { get; set; }

        public string GetSymbolForBowlingRoll(int round)
        {
            var roll = RollResultPerRound[round];

            switch (roll)
            {
                case BowlingRoll.Miss:
                    return "O";
                case BowlingRoll.Strike:
                    return "▶◀";
                case BowlingRoll.Spare:
                    return "◢";
                default:
                    return PinsPerRound[round].ToString();
            }
        }
    }
}
