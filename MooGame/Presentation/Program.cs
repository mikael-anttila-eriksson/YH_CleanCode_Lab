using MooGame.Business;

namespace MooGame.Presentation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            UI console = new UI();
            MooGameController controller = new MooGameController(console);
            controller.Run();
        }
    }

}
