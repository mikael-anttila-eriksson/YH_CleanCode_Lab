using MooGame.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame_Test
{
	public class MockUI : IUI
	{

		public string Read()
		{
			Debug.WriteLine(nameof(Read));
			return "";
		}

		public void Write(string text)
		{
			Debug.WriteLine(nameof(Write));
		}

		public void WriteLine(string text)
		{
			Debug.WriteLine(nameof(WriteLine));
		}
		public bool PromptYesNo()
		{
			Debug.WriteLine(nameof(PromptYesNo));
			return true;
		}
	}
}
