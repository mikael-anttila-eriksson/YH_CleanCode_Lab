﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MooGame
{
    internal class MooGameController
    {
        public MooGameController()
        {
			UI _console = new UI();
			bool playOn = true;
			bool practice = false;
			_console.WriteLine("Enter your user name:\n");
			string name = Console.ReadLine();

			while (playOn)
			{
				string goal = MakeGoal();

				_console.WriteLine("New game:\n");

				_console.WriteLine("Do you want to practice? Y/N");
				string practiceAnswer = _console.PromptYesNo();

				practice = CheckYesNo(practiceAnswer);
				if (practice)
				{
					_console.WriteLine("For practice, number is: " + goal + "\n");
				}
				else 
				{
					_console.WriteLine("Real game");
				}

				_console.WriteLine("Make a guess!");
				string guess = Console.ReadLine();

				int nGuess = 1;
				string bbcc = CheckBC(goal, guess);
				_console.WriteLine("Result: " + bbcc + "\n");
				while (bbcc != "BBBB,")
				{
					nGuess++;
					_console.Write("Your guess: ");
					guess = Console.ReadLine();
					bbcc = CheckBC(goal, guess);
					_console.WriteLine("Result: " + bbcc + "\n");
				}
				SavePlayerScore(name, nGuess);
				ShowTopList();
				_console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue? Y/N");
				string answer = Console.ReadLine();
				
				//Continue from here. Use PromptYesNO && CheckYesNo
				
				if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
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
					
					break;
				}
				else if (answer.ToUpper() == "N")
				{
					return false;
					
					break;
				}
			}
		}
		private void SavePlayerScore(string name, int nGuess)
		{
			StreamWriter output = new StreamWriter("result.txt", append: true);
			output.WriteLine(name + "#&#" + nGuess);
			output.Close();
		}
		private void Method3()
		{

		}
		private void Method4()
		{

		}
		static string MakeGoal()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

		static string CheckBC(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";     // if player entered less than 4 chars
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					char iGoal = goal[i];
					char jGuess = guess[j];
					if (iGoal == jGuess)
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
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
