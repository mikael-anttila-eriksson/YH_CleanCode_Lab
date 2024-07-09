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
    public string PromptYesNo() // our cool thing
    {
        string answer = "";

        while (true)
        {

            var top = Console.CursorTop;
            var left = Console.CursorLeft;

            answer = Console.ReadLine();

            if (answer.ToUpper() == "Y" || answer.ToUpper() == "YES")
            {
                break;
            }
            else if (answer.ToUpper() == "N" || answer.ToUpper() == "NO")
            {
                break;
            }
            else if (answer == "MOOOOO")
            {
                Console.Write("Welcome to the secret cow level!");
                SecretCowLevel();
                break;
            }

            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', answer.Length));
            Console.SetCursorPosition(left, top);
        }

        return answer;
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

		// Loop through each line and print it
		foreach (string line in lines)
		{
			Console.WriteLine(line);
		}
	}
}
    


