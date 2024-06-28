using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame;

internal class UI
{    
    public string Read()
    {
        return Console.ReadLine();
    }
    public void WriteLine(string text)
    { 
        Console.WriteLine(text);
    }
    public void Write(string text)
    {
        Console.Write(text);
    }
    public string PromptYesNo() // vår coola grej
    {
        string answer = "";

        while (true)
        {

            var top = Console.CursorTop;
            var left = Console.CursorLeft;

            answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                break;
            }
            else if (answer.ToUpper() == "N")
            {
                break;
            }

            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', answer.Length));
            Console.SetCursorPosition(left, top);
        }

        return answer;
    }

}
