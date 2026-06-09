namespace ConnectFour.Players
{
    // Player is an ABSTRACT class - it cannot be created directly
    // It serves as a blueprint for HumanPlayer and ComputerPlayer
    // This demonstrates ABSTRACTION and INHERITANCE in OOP
    internal abstract class Player
    {
        // Properties - encapsulate the player's data
        public string Name { get; private set; }
        public char Symbol { get; private set; }

        // Constructor - forces every player to have a name and symbol
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        // Abstract method - every subclass MUST implement this
        // This is POLYMORPHISM - HumanPlayer and ComputerPlayer
        // each do this differently but are called the same way
        public abstract int GetMove();

        // A regular method all players share
        public override string ToString()
        {
            return $"{Name} ({Symbol})";
        }
    }
}