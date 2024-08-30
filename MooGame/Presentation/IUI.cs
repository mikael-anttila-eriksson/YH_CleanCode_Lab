namespace MooGame.Presentation
{
    public interface IUI
    {
        public string ReadLine();
        public void Write(string text);
        public void WriteLine(string text);
        public bool PromptYesNo();

	}
}
