namespace ConnectFour.Players
{
    // HumanPlayer INHERITS from Player (Inheritance)
    // It gets its move from keyboard input
    internal class HumanPlayer : Player
    {
        // Constructor passes name and symbol up to the Player base class
        public HumanPlayer(string name, char symbol) : base(name, symbol)
        {
        }

        // Override GetMove() to get input from the user (Polymorphism)
        public override int GetMove()
        {
            int column;
            while (true)
            {
                Console.Write($"{Name}, choose a column (1-7): ");
                string? input = Console.ReadLine();

                // Validate input - must be a number between 1 and 7
                if (int.TryParse(input, out column) && column >= 1 && column <= 7)
                    return column - 1; // Convert to 0-based index

                Console.WriteLine("Invalid input! Please enter a number between 1 and 7.");
            }
        }
    }
}