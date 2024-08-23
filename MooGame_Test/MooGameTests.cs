using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.Business;

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
    }
}