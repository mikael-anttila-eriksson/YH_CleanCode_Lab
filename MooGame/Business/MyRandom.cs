using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Business
{
    public class MyRandom : IRandom
    {
        private readonly Random _random;
        public MyRandom()
        {
            _random = new Random();
        }
        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
