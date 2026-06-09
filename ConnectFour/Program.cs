using ConnectFour.Controllers;

namespace ConnectFour
{
    // Program.cs is the entry point of the application
    // It simply creates a GameController and starts the game
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.StartGame();
        }
    }
}