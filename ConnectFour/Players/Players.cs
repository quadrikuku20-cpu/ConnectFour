namespace ConnectFour.Players
{
    // Abstract base class for all player types
    // Demonstrates Abstraction and Inheritance
    internal abstract class Player
    {
        public string Name { get; private set; }
        public char Symbol { get; private set; }

        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // Each player type implements this differently (Polymorphism)
        public abstract int GetMove();

        public override string ToString()
        {
            return $"{Name} ({Symbol})";
        }
    }
}