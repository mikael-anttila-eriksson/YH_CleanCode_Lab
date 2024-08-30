using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Business
{
    public class MooGame
    {
        private const int START = 0;
        private const int END = 3;
        private int _position;
        /// <summary>
        /// BULL is a correctly guessed number and position.		
        /// </summary>
        private const string BULL = "B";
        /// <summary>
        /// COW is a correctly gussed number with an incorrect position.
        /// </summary>
        private const string COW = "C";
        public MooGame()
        {

        }
        public string CreateCorrectAnswer()
        {
            Random randomGenerator = new Random();
            string correctAnswer = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (correctAnswer.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                correctAnswer = correctAnswer + randomDigit;
            }
            return correctAnswer;
        }
        public string EvaluateBullsCows(string correctAnswer, string guess)
        {
            string result = string.Empty;
            string bulls = string.Empty;
            string cows = string.Empty;

            for (_position = START; _position <= END; _position++)
            {
                for (int positionToEvaluate = 0; positionToEvaluate < 4; positionToEvaluate++)
                {
                    int iGoal = 0;
                    bool int1 = int.TryParse(correctAnswer[_position].ToString(), out iGoal);
                    int jGuess = 0;
                    bool int2 = int.TryParse(guess[positionToEvaluate].ToString(), out jGuess);
                    if(!int1 || !int2)
                    {
                        return "error";
                    }
                    if (iGoal == jGuess)
                    {
                        if (_position == positionToEvaluate)
                        {
                            bulls += BULL;
                        }
                        else
                        {
                            cows += COW;
                        }
                    }

                }
            }
            result = bulls + cows;
            return result;
        }
        public bool ValidateInput(string guess, out string message)
        {
			bool step1 = ValidateGuess(guess, out message);
            if (!step1)
            {
                return false;
            }

			bool step2 = IsUniqueDigits(guess, out message);
            if (!step2)
            {
                return false;
            }
            return true;
		}
		public bool ValidateGuess(string guess, out string message)
		{
            message = string.Empty;

			if (string.IsNullOrEmpty(guess))
			{
				message = "You did not make a guess.";
				return false;
			}
			if (guess.Length != 4)
			{
				message = "Your guess must have a length of 4.";
				return false;
			}
			if (!int.TryParse(guess, out _))
			{
				message = "Your guess must contain only digits.";
				return false;
			}
			return true;
		}
		public bool IsUniqueDigits(string guess, out string message)
		{
            message = string.Empty;

			var uniqueDigits = guess.Distinct();
			int count = uniqueDigits.Count();

			if (uniqueDigits.Count() != 4)
			{
				message = "Each digit in your guess should be unique.";
				return false;
			}
			return true;
		}
	}
}
