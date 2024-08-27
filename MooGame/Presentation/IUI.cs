﻿namespace MooGame.Presentation
{
    public interface IUI
    {
        public string Read();
        public void Write(string text);
        public void WriteLine(string text);
        public bool PromptYesNo();

	}
}
