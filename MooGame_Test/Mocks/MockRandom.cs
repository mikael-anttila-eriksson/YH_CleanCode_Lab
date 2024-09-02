using MooGame.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test.Mocks
{
    public class MockRandom : IRandom
    {
        private List<int> _ints;
        
        private int index = 0;
        public MockRandom(List<int> ints)
        {
            this._ints = ints;
        }
        public int Next(int maxValue)
        {
            int nextNumber = _ints[index];
            index++;
            return nextNumber;
        }
    }
}
