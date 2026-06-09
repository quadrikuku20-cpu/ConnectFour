namespace ConnectFour.Views
{
    // ConsoleView handles all display output
    // Keeping display logic separate from game logic is good OOP design
    // This is called the "Single Responsibility Principle"
    internal class ConsoleView
    {
        // Shows the welcome screen when the game starts
        public void ShowWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║       CONNECT FOUR GAME       ║");
            Console.WriteLine("║    SODV1202 - OOP Project     ║");
            Console.WriteLine("╚═══════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        // Displays the game board with colors
        public void DisplayBoard(char[,] grid)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  CONNECT FOUR\n");
            Console.ResetColor();

            for (int r = 0; r < grid.GetLength(0); r++)
            {
                Console.Write("| ");
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    char cell = grid[r, c];

                    if (cell == 'X')
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (cell == 'O')
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.Write((cell == '.' ? '·' : cell) + " ");
                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }

            // Column numbers at the bottom
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("| ");
            for (int i = 1; i <= 7; i++)
                Console.Write(i + " ");
            Console.WriteLine("|");
            Console.ResetColor();
            Console.WriteLine();
        }

        // Shows whose turn it is
        public void ShowTurn(string name, char symbol)
        {
            Console.ForegroundColor = symbol == 'X'
                ? ConsoleColor.Red
                : ConsoleColor.Yellow;
            Console.WriteLine($"{name}'s turn ({symbol})");
            Console.ResetColor();
        }

        // Shows a general message
        public void ShowMessage(string message)
        {
            Console.ResetColor();
            Console.WriteLine(message);
        }
    }
}