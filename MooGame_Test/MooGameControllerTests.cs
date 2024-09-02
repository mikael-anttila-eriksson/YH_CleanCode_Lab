using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Business;
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
            var ui = new MockUI();
			//var game = new 
			var randomGenerator = new MockRandom(ints);
			//var gameController = new MooGameController(ui, randomGenerator);

			// Act
			//gameController.Run();

			// Assert
			Assert.Fail();
		}
	}
}