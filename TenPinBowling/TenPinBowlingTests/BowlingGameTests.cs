using System;
using System.Runtime.ExceptionServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TenPinBowling;

namespace TenPinBowlingTests
{
    [TestClass]
    public class BowlingGameTests
    {
        BowlingGame game;
        [TestInitialize]
        public void Setup()
        {
            game = new BowlingGame();
        }

        public void MultipleRolls(int rolls , int pinsHit )
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pinsHit);
            }
        }
        [TestMethod]
        public void NotEvenASinglePinHitShouldReturnZeroScore()
        {
            int rolls = 20;
            int pinsHit = 0;

            MultipleRolls(rolls, pinsHit);
           
            Assert.AreEqual(0, game.GetTotalScore());
        }

        [TestMethod]
        public void AllBallsHitOnePinEachShouldReturnScoreOfTwenty()
        {
            int rolls = 20;
            int pinsHit = 1;

            MultipleRolls(rolls, pinsHit);

            Assert.AreEqual(20, game.GetTotalScore());
        }

        [TestMethod]
        public void BowlWithOneSpare()
        {
           game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            MultipleRolls(17,0);
            Assert.AreEqual(16,game.GetTotalScore());
        }

        [TestMethod]
        public void FirstOneStrikeFollowedByNoSpareOrNoStrike()
        {
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);
            MultipleRolls(16, 0);
            Assert.AreEqual(28, game.GetTotalScore());
        }

        [TestMethod]
        public void AllStrikeWithBonusChancesBothStrike()
        {
            MultipleRolls(12, 10);
            Assert.AreEqual(300, game.GetTotalScore());
        }

        [TestMethod]
        public void Random_SpareAndStrike_WithLastStrike_AndBonusChances_NeitherStrike_NorSpare()
        {
            game.Roll(10);
            game.Roll(7);
            game.Roll(3);
            game.Roll(9);
            game.Roll(0);
            game.Roll(10);
            game.Roll(0);
            game.Roll(8);
            game.Roll(8);
            game.Roll(2);
            game.Roll(0);
            game.Roll(6);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);
            Assert.AreEqual(167, game.GetTotalScore());
        }
    }
}
