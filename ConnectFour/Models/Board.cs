namespace ConnectFour.Models
{
    // The Board class represents the game grid
    // It is responsible for storing the state of the game
    // and checking for win/draw conditions (Encapsulation)
    internal class Board
    {
        // Private fields - data is hidden from outside (Encapsulation)
        private char[,] grid;
        private const int Rows = 6;
        private const int Cols = 7;

        // Constructor - sets up a fresh board when the game starts
        public Board()
        {
            grid = new char[Rows, Cols];
            Initialize();
        }

        // Fills the board with empty cells
        public void Initialize()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    grid[r, c] = '.';
        }

        // Returns the grid so the View can display it
        public char[,] GetGrid() => grid;

        // Drops a disc into a column, returns false if column is full
        public bool DropDisc(int column, char symbol)
        {
            if (column < 0 || column >= Cols) return false;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (grid[r, column] == '.')
                {
                    grid[r, column] = symbol;
                    return true;
                }
            }
            return false; // Column is full
        }

        // Returns the next available row in a column (-1 if full)
        public int GetNextOpenRow(int column)
        {
            for (int r = Rows - 1; r >= 0; r--)
                if (grid[r, column] == '.') return r;
            return -1;
        }

        // Helper methods for the AI to simulate moves
        public void SetCell(int r, int c, char s) => grid[r, c] = s;
        public void ClearCell(int r, int c) => grid[r, c] = '.';

        // Checks if the board is completely full (draw condition)
        public bool IsFull()
        {
            for (int c = 0; c < Cols; c++)
                if (grid[0, c] == '.') return false;
            return true;
        }

        // Checks if the given symbol has 4 in a row anywhere
        public bool CheckWin(char symbol)
        {
            // Horizontal check
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols - 3; c++)
                    if (grid[r, c] == symbol && grid[r, c + 1] == symbol &&
                        grid[r, c + 2] == symbol && grid[r, c + 3] == symbol)
                        return true;

            // Vertical check
            for (int c = 0; c < Cols; c++)
                for (int r = 0; r < Rows - 3; r++)
                    if (grid[r, c] == symbol && grid[r + 1, c] == symbol &&
                        grid[r + 2, c] == symbol && grid[r + 3, c] == symbol)
                        return true;

            // Diagonal check (bottom-left to top-right /)
            for (int r = 3; r < Rows; r++)
                for (int c = 0; c < Cols - 3; c++)
                    if (grid[r, c] == symbol && grid[r - 1, c + 1] == symbol &&
                        grid[r - 2, c + 2] == symbol && grid[r - 3, c + 3] == symbol)
                        return true;

            // Diagonal check (top-left to bottom-right \)
            for (int r = 0; r < Rows - 3; r++)
                for (int c = 0; c < Cols - 3; c++)
                    if (grid[r, c] == symbol && grid[r + 1, c + 1] == symbol &&
                        grid[r + 2, c + 2] == symbol && grid[r + 3, c + 3] == symbol)
                        return true;

            return false;
        }
    }
}