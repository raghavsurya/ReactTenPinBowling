using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
    public class BowlingGame
    {
     
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pinsHit)
        {
            _rolls[_currentRoll++] = pinsHit;
        }

        public int GetTotalScore()
        {   int totalScore = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    totalScore += 10 + BonusForStrikeHit(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    totalScore += 10 + BonusForSpareHit(roll);
                    roll += 2;
                }
                else
                {
                    totalScore += SummOfRollsInAFrame(roll);
                    roll += 2;
                }
            }
            return totalScore;
        }

        private int SummOfRollsInAFrame(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }

        private int BonusForSpareHit(int roll)
        {
            return _rolls[roll + 2];
        }

        private int BonusForStrikeHit(int roll)
        {
            return _rolls[roll + 1] + _rolls[roll + 2];
        }
        private bool IsSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }
        static void Main(string[] args)
        {
        }
    }
}
