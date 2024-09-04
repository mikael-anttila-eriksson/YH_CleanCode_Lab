using MooGame.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test.Mocks
{
    public class MockFileManger : IFileManager
    {
        public List<string[]> ReadData(string path)
        {
            List<string[]> data = new List<string[]>()
            {
                new string[] {"Jones", "5"}
            };
            return data;
        }

        public void SavePlayerScore(string name, int numGuesses, string path)
        {
            Debug.WriteLine($"{nameof(SavePlayerScore)}({name}, {numGuesses}) was called.");
        }
    }
}
