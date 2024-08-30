using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Data
{
    public interface IFileManger
    {
        void SavePlayerScore(string name, int numGuesses);
        List<PlayerData> ReadData();
    }
}
