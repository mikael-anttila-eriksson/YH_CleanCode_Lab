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
    public class FileManagerTests
    {
        [TestMethod()]
        public void ReadDataTest()
        {
            // Arrange            
            List<string[]> expectedList = new List<string[]>()
            {
                new string[] { "Sherlock_Holmes", "5" },
                new string[] { "Harry_Potter", "8" },
                new string[] { "Frodo_Baggins", "7" },
                new string[] { "Katniss_Everdeen", "6" },
                new string[] { "Darth_Vader", "4" },
                new string[] { "Wonder_Woman", "9" },
                new string[] { "Sherlock_Holmes", "3" },
                new string[] { "Katniss_Everdeen", "7" },
                new string[] { "Frodo_Baggins", "5" },
                new string[] { "Darth_Vader", "6" },
                new string[] { "Wonder_Woman", "8" },
                new string[] { "Harry_Potter", "4" },
            };
            FileManager manager = new FileManager();
            // Act
            List<string[]> actualList = manager.ReadData("testdata.txt");
            
            // Assert
            Assert.AreEqual(expectedList.Count, actualList.Count, "List sizes do not match");

            for (int i = 0; i < expectedList.Count; i++)
            {
                var expected = expectedList[i];
                var actual = actualList[i];                
                Assert.IsTrue(expected.SequenceEqual(actual), $"List elements at index {i} do not match.");                
            }
        }
    }
}