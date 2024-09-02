using Microsoft.VisualStudio.TestTools.UnitTesting;
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
	public class UITests
	{
		[TestMethod()]
		public void ReadTest()
		{
			//Arrange
			IUI console = new MockUI();

			// Act
			console.ReadLine();

			// Assert
		}

		[TestMethod()]
		public void WriteLineTest()
		{
			//Arrange
			IUI console = new MockUI();

			// Act
			console.WriteLine("test");			

			// Assert
		}

		[TestMethod()]
		public void WriteTest()
		{
			//Arrange
			IUI console = new MockUI();

			// Act
			console.Write("test");

			// Assert
		}

		[TestMethod()]
		public void PromptYesNoTest()
		{
			//Arrange
			IUI console = new MockUI();

			// Act
			console.PromptYesNo();

			// Assert
		}		
	}
}