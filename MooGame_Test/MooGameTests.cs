using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.Business;
using MooGame_Test.Mocks;

namespace MooGame_Test
{
    [TestClass()]
    public class MooGameTests
    {
        [TestMethod()]
        [DataRow("1234", "k-38", "error")]
        [DataRow("-234", "-138", "error")]
        [DataRow("1234", "2835", "BC")]
		[DataRow("1234", "1234", "BBBB")]
        [DataRow("1234", "4321", "CCCC")]
        [DataRow("1234", "5678", "")]
		public void EvaluateBullsCowsTest(string correctAnswer, string guess, string expectedOutput)
        {
            // Arrange
            MooGame.Business.MooGame mooGame = new MooGame.Business.MooGame();
			
            //string correctAnswer = "1234";
			//string guess = "2835";

			// Act
			string actualOutput = mooGame.EvaluateBullsCows(correctAnswer, guess);
            //string expectedOutput = "BC";

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Incorrect evaluation.");
        }
        [TestMethod]
        public void CreateCorrectAnswer_CheckLenght_Test()
        {
            // Arrange: Initialize the object to be tested
            // Act: Act on the object --> call a method
            // Assert: Verify

            // Arrange
            MooGame.Business.MooGame game = new();

            // Act
            IRandom randomGenerator = new MyRandom();
            string answer = game.CreateCorrectAnswer(randomGenerator);

            // Assert
            Assert.IsTrue(answer.Length == 5, "Not 4 characters");
        }
        [TestMethod]
        [DataRow("24251", "2451")]
        [DataRow("42329", "4239")]
        public void CreateCorrectAnswerTest(string randomNumber, string expectedAnswer)
        {
            // Arrange
            MooGame.Business.MooGame game = new();
            List<int> ints = new List<int>();
            for(int i = 0; i < randomNumber.Length; i++)
            {
                int num = Convert.ToInt32(randomNumber[i].ToString());
                ints.Add(num);
            }
            // Act
            int[] df = [2, 4, 2, 5, 1];
            IRandom randomGenerator = new MockRandom(ints);
            string actualAnswer = game.CreateCorrectAnswer(randomGenerator);
            // Assert
            Assert.AreEqual(expectedAnswer, actualAnswer, "Failed to create intended answer");
        }
    }
}