using MooGame.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test.Mocks
{
    internal class MockMooGame : IMooGame
    {
        public string CreateCorrectAnswer(IRandom randomGenerator)
        {
            return "1234";
        }

        public string EvaluateBullsCows(string correctAnswer, string guess)
        {
            return "BBBB";
        }

        public bool IsUniqueDigits(string guess, out string message)
        {
            message = $"Test in {nameof(IsUniqueDigits)}";
            return true;
        }

        public bool ValidateGuess(string guess, out string message)
        {
            message = $"Test in {nameof(ValidateGuess)}";
            return true;
        }

        public bool ValidateInput(string guess, out string message)
        {
            message = $"Test in {nameof(ValidateInput)}";
            return true;
        }
    }
}
