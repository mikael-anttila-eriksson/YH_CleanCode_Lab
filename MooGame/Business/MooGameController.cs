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
        private IUI _uiHandler;
        private IMooGame _mooGame;
        private IFileManager _fileManager;
        private IRandom _randomGenerator;
        public MooGameController(IUI uiHandler, IMooGame game, IFileManager manager, IRandom random)
        {
            _uiHandler = uiHandler;
            _mooGame = game;
            _fileManager = manager;
            _randomGenerator = random;            
        }

        public void Run()
        {
            bool playOn = true;
            _uiHandler.WriteLine("Enter your username:\n");
            string name = _uiHandler.ReadLine();

            while (playOn)
            {                
                string correctAnswer = _mooGame.CreateCorrectAnswer(_randomGenerator);

                _uiHandler.WriteLine("New game:\n");

                _uiHandler.WriteLine("Do you want to practice? Y/N");

                if (_uiHandler.PromptYesNo())
                {
                    _uiHandler.WriteLine("For practice, number is: " + correctAnswer + "\n");
                }
                else
                {
                    _uiHandler.WriteLine("Real game");
                }

                int numGuesses = GameTurn(correctAnswer);

                _fileManager.SavePlayerScore(name, numGuesses, "result.txt");                
                ShowTopList();
                _uiHandler.WriteLine("Correct, it took " + numGuesses + " guesses");

                _uiHandler.WriteLine("Continue? Y/N");
                if (!_uiHandler.PromptYesNo())
                {
                    playOn = false;
                }
            }
        }       

        private int GameTurn(string correctAnswer)
        {
            _uiHandler.WriteLine("Make a guess!");

            int nGuess = 0;
            string bbcc = string.Empty;

            while (bbcc != "BBBB")
            {
                _uiHandler.Write("Your guess: ");

                string guess = _uiHandler.ReadLine();
                guess = guess.Replace(" ", string.Empty);                
                if (_mooGame.ValidateInput(guess, out string message))
                {
                    bbcc = _mooGame.EvaluateBullsCows(correctAnswer, guess);
                    _uiHandler.WriteLine("Result: " + bbcc + "\n");
                    nGuess++;
                }
                else
                {
                    _uiHandler.WriteLine(message);
                    _uiHandler.WriteLine("Try again.");
                }
            }
            return nGuess;
        }        

        private List<PlayerData> SortByLowestAverage(List<PlayerData> players)
        {            
            players.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            return players;
		}
        private List<PlayerData> ReadPlayers(string path)
        {
            List<PlayerData> playerStatistics = new List<PlayerData>();
            List<string[]> playerData = _fileManager.ReadData(path);
            string name;
            int guesses = 0;
            foreach (string[] row in playerData)
            {
                name = row[0];
                guesses = Convert.ToInt32(row[1]);
                PlayerData player = new PlayerData(name, guesses);
                int positionInList = playerStatistics.IndexOf(player);
                if (positionInList < 0)
                {
                    playerStatistics.Add(player);
                }
                else
                {
                    playerStatistics[positionInList].Update(guesses);
                }
            }
            return playerStatistics;
        }
        private void ShowTopList()
        {
            List<PlayerData> players = ReadPlayers("result.txt");
            players = SortByLowestAverage(players);
			_uiHandler.WriteLine("Player   games average");
			foreach (PlayerData p in players)
			{
				string result = string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumGames, p.Average());
				_uiHandler.WriteLine(result);
			}			
		}
    }
}
