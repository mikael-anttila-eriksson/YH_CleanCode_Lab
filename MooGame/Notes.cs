using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    internal class Notes
    {
        public Notes()
        {
            
            int num = 3435;
            string str = num.ToString();
            int ff = str.Length;
            // ALT 1 Distinct
            var f = str.Distinct();
            int count = f.Count();
            if (count == 4) // == str.Length 
            {
                //ok
            }
            // ALT 2 HashSet
            HashSet<char> digits = new HashSet<char>();
            foreach (char digit in str)
            {
                bool isUnique = digits.Add(digit);
                if (!isUnique)
                {
                    int y = 0;
                    //return false;
                }
            }

            HashSet<int> set = new HashSet<int>();
            set.Add(num);
            set.Add(2);
            set.Add(3);
            set.Add(3);
            set.Add(3);
            set.Add(3);
            set.Add(4);
            set.Add(3);
        }
    }
}
