using ConnectFour.Models;
using ConnectFour.Views;
using ConnectFour.Players;

namespace ConnectFour.Controllers
{
    // GameController manages the entire game flow
    // It connects the Model (Board), View (ConsoleView), 
    // and Players together - this is the MVC pattern
    internal class GameController
    {
        private Board board;
        private ConsoleView view;
        private Player? player1;
        private Player? player2;

        public GameController()
        {
            board = new Board();
            view = new ConsoleView();
        }

        // Sets up the game by asking for names and game mode
        private void Setup()
        {
            view.ShowWelcome();

            // Ask for player 1 name
            Console.Write("Enter Player 1 name: ");
            string name1 = Console.ReadLine() ?? "Player 1";

            // Ask for game mode
            view.ShowMessage("\nSelect Game Mode:");
            view.ShowMessage("1. Human vs Human");
            view.ShowMessage("2. Human vs Computer");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   (choice != 1 && choice != 2))
            {
                view.ShowMessage("Please enter 1 or 2:");
            }

            player1 = new HumanPlayer(name1, 'X');

            if (choice == 1)
            {
                Console.Write("Enter Player 2 name: ");
                string name2 = Console.ReadLine() ?? "Player 2";
                player2 = new HumanPlayer(name2, 'O');
            }
            else
            {
                player2 = new ComputerPlayer("Computer", 'O', board);
            }
        }

        // Main game loop
        public void StartGame()
        {
            Setup();
            bool playAgain = true;

            while (playAgain)
            {
                // Reset board for new game
                board = new Board();

                // Update board reference in ComputerPlayer if needed
                if (player2 is ComputerPlayer ai)
                    ai.SetBoard(board);

                Player currentPlayer = player1!;

                while (true)
                {
                    view.DisplayBoard(board.GetGrid());
                    view.ShowTurn(currentPlayer.Name, currentPlayer.Symbol);

                    // Add a small delay for computer moves
                    if (currentPlayer is ComputerPlayer)
                        Thread.Sleep(800);

                    // Get and validate the move
                    int column = -1;
                    bool validMove = false;

                    while (!validMove)
                    {
                        column = currentPlayer.GetMove();
                        if (board.DropDisc(column, currentPlayer.Symbol))
                            validMove = true;
                        else
                            view.ShowMessage("That column is full! Try another.");
                    }

                    // Check for win
                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        view.DisplayBoard(board.GetGrid());
                        view.ShowMessage($"\n🎉 {currentPlayer.Name} wins!");
                        break;
                    }

                    // Check for draw
                    if (board.IsFull())
                    {
                        view.DisplayBoard(board.GetGrid());
                        view.ShowMessage("\nIt's a draw!");
                        break;
                    }

                    // Switch turns
                    currentPlayer = (currentPlayer == player1) ? player2! : player1!;
                }

                // Ask to play again
                view.ShowMessage("\nPlay again? (1 = Yes, 0 = No): ");
                playAgain = Console.ReadLine() == "1";
            }

            view.ShowMessage("\nThanks for playing! Goodbye 👋");
        }
    }
}