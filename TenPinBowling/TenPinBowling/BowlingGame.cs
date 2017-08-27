using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
    public class BowlingGame
    {
     
        private int[] rolls = new int[21];
        private int currentRoll;

        public void Roll(int pinsHit)
        {
            rolls[currentRoll++] = pinsHit;
        }

        public int GetTotalScore()
        {   int totalScore = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    totalScore += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    totalScore += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    totalScore += SummOfBallsInAFrame(roll);
                    roll += 2;
                }
            }
            return totalScore;
        }

        private int SummOfBallsInAFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }
        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
        static void Main(string[] args)
        {
        }
    }
}
