using ConnectFour.Models;

namespace ConnectFour.Players
{
    // ComputerPlayer INHERITS from Player (Inheritance)
    // It provides its own version of GetMove() (Polymorphism)
    internal class ComputerPlayer : Player
    {
        private Random rand = new Random();
        private Board board;

        // Constructor calls the base (Player) constructor
        // This is how inheritance works - we reuse the parent's setup
        public ComputerPlayer(string name, char symbol, Board board) : base(name, symbol)
        {
            this.board = board;
        }

        // Updates the board reference when a new game starts
        public void SetBoard(Board newBoard)
        {
            board = newBoard;
        }

        // The AI follows this priority: Win > Block > Center > Random
        public override int GetMove()
        {
            // Priority 1: Win if possible
            for (int c = 0; c < 7; c++)
            {
                int r = board.GetNextOpenRow(c);
                if (r != -1)
                {
                    board.SetCell(r, c, Symbol);
                    if (board.CheckWin(Symbol))
                    {
                        board.ClearCell(r, c);
                        return c;
                    }
                    board.ClearCell(r, c);
                }
            }

            // Priority 2: Block opponent from winning
            char opponent = Symbol == 'X' ? 'O' : 'X';
            for (int c = 0; c < 7; c++)
            {
                int r = board.GetNextOpenRow(c);
                if (r != -1)
                {
                    board.SetCell(r, c, opponent);
                    if (board.CheckWin(opponent))
                    {
                        board.ClearCell(r, c);
                        return c;
                    }
                    board.ClearCell(r, c);
                }
            }

            // Priority 3: Play center column (best strategic position)
            if (board.GetNextOpenRow(3) != -1) return 3;

            // Priority 4: Pick a random valid column
            int col;
            do { col = rand.Next(0, 7); }
            while (board.GetNextOpenRow(col) == -1);

            return col;
        }
    }
}