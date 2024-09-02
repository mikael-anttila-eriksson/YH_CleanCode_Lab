using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Presentation;

public class UI : IUI
{
    public string ReadLine()
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
    public bool PromptYesNo() 
    {
        string answer = "";

        while (true)
        {

            var top = Console.CursorTop;
            var left = Console.CursorLeft;

            answer = Console.ReadLine();

            if (answer.ToUpper() == "Y" || answer.ToUpper() == "YES")
            {
                return true;
            }
            else if (answer.ToUpper() == "N" || answer.ToUpper() == "NO")
            {
                return false;
            }
            else if (answer == "MOOOOO")
            {
                Console.Write("Welcome to the secret cow level!");
                SecretCowLevel();
                return false;
            }

            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', answer.Length));
            Console.SetCursorPosition(left, top);
        }
    }
    public void SecretCowLevel()
    {
        string[] lines = new string[]
        {
            " ___________",
            "| Hello World |",
            "  ===========",
            "           \\",
            "            \\",
            "              ^__^",
            "              (oo)\\_______",
            "              (__)\\       )\\/\\",
            "                  ||----w |",
            "                  ||     ||"
        };
        
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}



