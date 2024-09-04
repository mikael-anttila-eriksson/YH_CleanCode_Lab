using MooGame.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test.Mocks
{
    public class MockUI_For_Controller : IUI
    {
        private List<string> _readLines = new List<string>();
        private int _index = 0;
        public MockUI_For_Controller(List<string> lines)
        {
            _readLines = lines;
        }
        public bool PromptYesNo()
        {
            if(_index > 1)
            {
                return false;
            }
            return true;
        }

        public string ReadLine()
        {
            string line = "";
            if( _index < _readLines.Count )
            {
                line = _readLines[_index];
            }
            else
            {
                line = "end of input lines";
            }
            _index++;
            return line;
        }

        public void Write(string text)
        {
            Debug.WriteLine($"{nameof(Write)} says: {text}");
        }

        public void WriteLine(string text)
        {
            Debug.WriteLine($"{nameof(WriteLine)} says: {text}");
        }
    }
}
