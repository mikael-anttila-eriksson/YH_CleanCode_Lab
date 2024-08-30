using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Business
{
    public interface IMooGame
    {
        string CreateCorrectAnswer(IRandom randomGenerator);
        string EvaluateBullsCows(string correctAnswer, string guess);
        bool ValidateInput(string guess, out string message);
        bool ValidateGuess(string guess, out string message);
        bool IsUniqueDigits(string guess, out string message);
    }
}
