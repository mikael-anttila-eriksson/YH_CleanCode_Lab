using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MooGame
{
    /// <summary>
    /// The controller pattern defines a class or an object that handles the system events 
    /// and coordinates the actions of other classes or objects. The controller acts as a 
    /// mediator between the user interface (UI) and the domain model, which represents 
    /// the business logic and data of the application. The controller is responsible for 
    /// receiving the user inputs, validating them, invoking the appropriate methods of 
    /// the domain model, and updating the UI accordingly.
    /// </summary>
    internal class MooGameController
    {
		private UI _console;
		private MooGame _mooGame;
        public MooGameController(UI console)
        {
			_console = console;
			_mooGame = new MooGame();
			bool playOn = true;
			_console.WriteLine("Enter your username:\n");
			string name = Console.ReadLine();

			while (playOn)
			{
				string correctAnswer = _mooGame.CreateCorrectAnswer();

				_console.WriteLine("New game:\n");

				_console.WriteLine("Do you want to practice? Y/N");
				string practiceAnswer = _console.PromptYesNo();

				if (CheckYesNo(practiceAnswer))
				{
					_console.WriteLine("For practice, number is: " + correctAnswer + "\n");
				}
				else 
				{
					_console.WriteLine("Real game");
				}

				int nGuess = GameTurn(correctAnswer);
			
				SavePlayerScore(name, nGuess);
				ShowTopList();
				_console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue? Y/N");
				string continueAnswer = _console.PromptYesNo();
				
				
				if (!CheckYesNo(continueAnswer))
				{
					playOn = false;
				}
			}
		}
		private bool CheckYesNo(string answer)
		{
			while (true)
			{
				
				if (answer.ToUpper() == "Y")
				{
					return true;
				}
				else if (answer.ToUpper() == "N")
				{
					return false;
				}
			}
		}
		private void SavePlayerScore(string name, int nGuess)
		{
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(name + "#&#" + nGuess);
			output.Close();
		}
		
		private int GameTurn(string correctAnswer)
		{
			_console.WriteLine("Make a guess!");			

			int nGuess = 0;
			string bbcc = string.Empty;
			
			while (bbcc != "BBBB")
			{
				_console.Write("Your guess: ");
				
				string guess = Console.ReadLine();				
				guess = guess.Replace(" ", string.Empty);	

				if (ValidateGuess(guess) && IsUniqueDigits(guess))				
				{
					bbcc = _mooGame.EvaluateBullsCows(correctAnswer, guess); 
					_console.WriteLine("Result: " + bbcc + "\n");
					nGuess++;
				}				
				else
				{
					_console.WriteLine("Try again.");
				}
			}
			return nGuess;
		}

		private bool ValidateGuess(string guess)
		{
			if (string.IsNullOrEmpty(guess))
			{
				_console.WriteLine("You did not make a guess.");
				return false;
			}
			if (guess.Length != 4)
			{				
				_console.WriteLine("Your guess must have a length of 4.");
				return false;
			}
			if (!int.TryParse(guess, out _))
			{
				_console.WriteLine("Your guess must contain only digits.");
				return false;
			}
			return true;
		}
		private bool IsUniqueDigits(string guess)
		{
			var uniqueDigits = guess.Distinct();
			int count = uniqueDigits.Count();

			if (uniqueDigits.Count() != 4)
			{
				_console.WriteLine("Each digit in your guess should be unique.");
				return false;
			}
			return true;			
		}

		static void ShowTopList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}


			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
			}
			input.Close();
		}
	}
}
