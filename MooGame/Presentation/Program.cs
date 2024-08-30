using MooGame.Business;
using MooGame.Data;

namespace MooGame.Presentation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IUI console = new UI();
            IMooGame mooGame = new MooGame.Business.MooGame();
            IFileManger manager = new FileManager();
            IRandom randomGenerator = new MyRandom();
            MooGameController controller = new MooGameController(console, mooGame, manager, randomGenerator);
            controller.Run();
        }
    }

}
