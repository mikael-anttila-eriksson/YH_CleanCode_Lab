using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Data
{
    public interface IFileManager
    {
        void SavePlayerScore(string name, int numGuesses, string path);
        List<string[]> ReadData(string path);
    }
}
