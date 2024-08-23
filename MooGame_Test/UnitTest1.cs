namespace MooGame_Test
{
    [TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			// Arrange: Initialize the object to be tested
			// Act: Act on the object --> call a method
			// Assert: Verify

			// Arrange
			MooGame.Buisiness.MooGame game = new();
			
			// Act
			string answer = game.CreateCorrectAnswer();

			// Assert
			Assert.IsTrue(answer.Length == 5, "Not 4 characters");
		}
		//[TestMethod]
		//public void Test_CheckPromtYesNo()
		//{
		//	// Arrange
		//	UI console = new();
		//	MooGameController controller = new MooGameController(console);

		//	// Act
		//	string answer = "R";
			
		//	bool actualCheck = console.PromptYesNo(answer);
		//	bool expectedCheck = false;
			
		//	// Assert
		//	Assert.AreEqual(expectedCheck, actualCheck);
		//}
	}
}