using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            UI console = new UI();
            MooGameController controller = new MooGameController(console);
        }          
    }   
    
}
