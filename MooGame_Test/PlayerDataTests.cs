using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test
{
	[TestClass()]
	public class PlayerDataTests
	{
		[TestMethod()]
		public void UpdateTest()
		{
			// Arrange: Initialize the object to be tested
			int guesses = 5;
			PlayerData playerData = new PlayerData("Erik", guesses);

			// Act: Act on the object --> call a method
			int newGuesses = 3;
			playerData.Update(newGuesses);
			int actualGuesses = playerData.TotalGuesses;
			int expectedGuesses = guesses + newGuesses;

			// Assert: Verify
			Assert.AreEqual(expectedGuesses, actualGuesses, "Total guesses not correct.");
		}
		[TestMethod()]
		public void AverageTest()
		{
			// Arrange: Initialize the object to be tested
			int guesses = 5;
			PlayerData playerData = new PlayerData("Erik", guesses);

			// Act: Act on the object --> call a method
			int newGuesses = 3;
			playerData.Update(newGuesses);
			double expectedAverage = 4;
			double actualAverage = playerData.Average();

			// Assert: Verify
			Assert.AreEqual(expectedAverage, actualAverage, "Incorrect average.");
		}

	}
}