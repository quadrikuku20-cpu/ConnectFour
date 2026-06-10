namespace ConnectFour.Views
{
    // Handles all console display - separated from game logic
    // Single Responsibility Principle
    internal class ConsoleView
    {
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

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("| ");
            for (int i = 1; i <= 7; i++)
                Console.Write(i + " ");
            Console.WriteLine("|");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowTurn(string name, char symbol)
        {
            Console.ForegroundColor = symbol == 'X'
                ? ConsoleColor.Red
                : ConsoleColor.Yellow;
            Console.WriteLine($"{name}'s turn ({symbol})");
            Console.ResetColor();
        }

        public void ShowMessage(string message)
        {
            Console.ResetColor();
            Console.WriteLine(message);
        }

        // New method - shows score at end of game
        public void ShowResult(string winnerName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n★ {winnerName} wins the game! Congratulations! ★");
            Console.ResetColor();
        }
    }
}