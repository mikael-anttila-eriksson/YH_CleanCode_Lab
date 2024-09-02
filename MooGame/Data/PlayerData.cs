using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Data
{
    public class PlayerData
    {
        public string Name { get; private set; }
        public int NumGames { get; private set; }
        public int TotalGuesses { get; private set; }

        public PlayerData(string name, int guesses)
        {
            Name = name;
            NumGames = 1;
            TotalGuesses = guesses;
        }
        public void Update(int guesses)
        {
            TotalGuesses += guesses;
            NumGames++;
        }
        public double Average()
        {
            return (double)TotalGuesses / NumGames;
        }
        public override bool Equals(object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
