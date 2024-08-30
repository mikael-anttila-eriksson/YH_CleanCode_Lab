using MooGame.Data;
using MooGame.Presentation;

namespace MooGame.Business
{
    /// <summary>
    /// The controller pattern defines a class or an object that handles the system events 
    /// and coordinates the actions of other classes or objects. The controller acts as a 
    /// mediator between the user interface (UI) and the domain model, which represents 
    /// the business logic and data of the application. The controller is responsible for 
    /// receiving the user inputs, validating them, invoking the appropriate methods of 
    /// the domain model, and updating the UI accordingly.
    /// </summary>
    public class MooGameController
    {
        private IUI _console;
        private MooGame _mooGame;
        private FileManager _fileManager;
        public MooGameController(IUI console)
        {
            _console = console;
            _mooGame = new MooGame();
            _fileManager = new FileManager();
            //ReadData();
        }

        public void Run()
        {
            bool playOn = true;
            _console.WriteLine("Enter your username:\n");
            string name = _console.Read();

            while (playOn)
            {
                string correctAnswer = _mooGame.CreateCorrectAnswer();

                _console.WriteLine("New game:\n");

                _console.WriteLine("Do you want to practice? Y/N");

                if (_console.PromptYesNo())
                {
                    _console.WriteLine("For practice, number is: " + correctAnswer + "\n");
                }
                else
                {
                    _console.WriteLine("Real game");
                }

                int numGuesses = GameTurn(correctAnswer);

                _fileManager.SavePlayerScore(name, numGuesses);
                ShowTopList();
                _console.WriteLine("Correct, it took " + numGuesses + " guesses\nContinue? Y/N");

                if (!_console.PromptYesNo())
                {
                    playOn = false;
                }
            }
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
                if (_mooGame.ValidateInput(guess, out string message))
                {
                    bbcc = _mooGame.EvaluateBullsCows(correctAnswer, guess);
                    _console.WriteLine("Result: " + bbcc + "\n");
                    nGuess++;
                }
                else
                {
                    _console.WriteLine(message);
                    _console.WriteLine("Try again.");
                }
            }
            return nGuess;
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
                PlayerData playerData = new PlayerData(name, guesses);
                int positionInList = results.IndexOf(playerData);
                if (positionInList < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[positionInList].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                string str = string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumGames, p.Average());
                Console.WriteLine(str);
            }
            input.Close();
        }
       
  //      public List<PlayerData> Logic(List<PlayerData> players)
  //      {
		//	return players = players.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
		//}
        public void ShowList(List<PlayerData> players)
        {
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in players)
			{
				string str = string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumGames, p.Average());
				Console.WriteLine(str);
			}			
		}
    }
}
