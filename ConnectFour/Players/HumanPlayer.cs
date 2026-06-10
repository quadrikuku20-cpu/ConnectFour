namespace ConnectFour.Players
{
    // HumanPlayer gets moves from keyboard input
    // Inherits from Player and overrides GetMove()
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol)
        {
        }

        // Validates input and keeps asking until valid
        public override int GetMove()
        {
            int column;
            while (true)
            {
                Console.Write($"{Name}, choose a column (1-7): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out column) && column >= 1 && column <= 7)
                    return column - 1;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid! Please enter a number between 1 and 7.");
                Console.ResetColor();
            }
        }
    }
}