using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Business;
using MooGame.Presentation;
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
			var ui = new UI();
			var gameController = new MooGameController(ui);

			// Act
			gameController.Run();

			// Assert
			Assert.Fail();
		}
	}
}