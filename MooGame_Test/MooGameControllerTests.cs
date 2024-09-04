using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Business;
using MooGame.Data;
using MooGame.Presentation;
using MooGame_Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test
{
	[TestClass()]
	public class MooGameControllerTests
	{
		[TestMethod()]
		public void MooGameControllerTest()
		{
            // Arrange
            List<int> ints = [1, 2, 3, 4, 5];
			List<string> lines = new List<string>()
			{
				"Testname",
				"1234",
			};

            var ui = new MockUI_For_Controller(lines);
			IMooGame game = new MockMooGame();
			IFileManager manager = new MockFileManger();
			IRandom randomGenerator = new MockRandom(ints);
			var gameController = new MooGameController(ui, game, manager, randomGenerator);

			// Act
			gameController.Run();

			// Assert
			Assert.Fail("Check Standard Output for test result");
		}
	}
}