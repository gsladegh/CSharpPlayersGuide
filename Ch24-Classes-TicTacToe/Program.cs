/*
 *  TIC-TAC-TOE
 *  
    This final challenge requires building a more complex object-oriented program from start to 
    finish: the game of Tic-Tac-Toe. This is the most significant program we have made so far, so 
    expect to take some time to get it right.

    Boss Battle Tic-Tac-Toe 300 XP

    Completing designs for the three games in the Chamber of Design causes the pedestals to light up red
    again, and another door opens, letting you into the final chamber. This chamber has only a single large, 
    broad pedestal. Inscribed on the stone floor in a circle around the pedestal are the engraved words,“Only 
    a True Programmer can build object-oriented programs.”

    More text engraved on the pedestal describes what you recognize as the game of Tic-Tac-Toe, stating 
    that in ancient times, inhabitants of the land would use this as a Battle of Wits to determine the outcome 
    of political strife. Instead of fighting wars, they would battle it out in a game of Tic-Tac-Toe.
    Your job is to recreate the game of Tic-Tac-Toe, allowing two players to compete against each other. The 
    following features are required: 

    • Two human players take turns entering their choice using the same keyboard.
    • The players designate which square they want to play in. Hint: You might consider using the number 
    pad as a guide. For example, if they enter 7, they have chosen the top left corner of the board.
    • The game should prevent players from choosing squares that are already occupied. If such a move 
    is attempted, the player should be told of the problem and given another chance.
    • The game must detect when a player wins or when the board is full with no winner (draw/”cat”). 
    • When the game is over, the outcome is displayed to the players.
    • The state of the board must be displayed to the player after each play. Hint: One possible way to 
    show the board could be like this:
    It is X's turn.
     | X |
    ---+---+---
     | O | X
    ---+---+---
    O | |
    What square do you want to play in?
    Objectives:
    • Build the game of Tic-Tac-Toe as described in the requirements above. Starting with CRC cards is 
    recommended, but the goal is to make working software, not CRC cards.
    • Answer this question: How might you modify your completed program if running multiple rounds 
    was a requirement (for example, a best-out-of-five series)?
 */

Console.WriteLine("Welcome to Tic-Tac-Toe. Creating a game.");
TicTacToeGame game = new TicTacToeGame();
game.PlayGame();

public class TicTacToeGame
{
    public void PlayGame()
    {
        Board board = new Board();
        BoardRenderer renderer = new BoardRenderer();
        Player player1 = new Player(Cell.X); // Will be X
        Player player2 = new Player(Cell.O); // Will be O    
        int turnNumber = 0;

        Player currentPlayer = player1;

        while (turnNumber < 9) // 9 moves is hte max
        {
            Console.WriteLine($"It is {currentPlayer.Symbol}'s turn.");
            renderer.Draw(board);
            Square square = currentPlayer.PickSquare(board);
            board.FillCell(square.Row, square.Column, currentPlayer.Symbol);
            if (HasWon(board, Cell.X))
            {
                renderer.Draw(board);
                Console.WriteLine("X Won!");
                return;
            }
            else if (HasWon(board, Cell.O))
            {
                renderer.Draw(board);
                Console.WriteLine("O Won!");
                return;
            }

            // change to the other player.
            currentPlayer = currentPlayer == player1 ? player2 : player1;
            turnNumber++;
        }

        renderer.Draw(board);
        Console.WriteLine("Draw!");
    }

    private bool HasWon(Board board, Cell value)
    {
        // Check rows.
        if (board.ContentsOf(0, 0) == value && board.ContentsOf(0, 1) == value && board.ContentsOf(0, 2) == value) return true;
        if (board.ContentsOf(1, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(1, 2) == value) return true;
        if (board.ContentsOf(2, 0) == value && board.ContentsOf(2, 1) == value && board.ContentsOf(2, 2) == value) return true;

        // Check columns.
        if (board.ContentsOf(0, 0) == value && board.ContentsOf(1, 0) == value && board.ContentsOf(2, 0) == value) return true;
        if (board.ContentsOf(0, 1) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(2, 1) == value) return true;
        if (board.ContentsOf(0, 2) == value && board.ContentsOf(1, 2) == value && board.ContentsOf(2, 2) == value) return true;

        // Check diagonals.
        if (board.ContentsOf(0, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(2, 2) == value) return true;
        if (board.ContentsOf(2, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(0, 2) == value) return true;

        return false;
    }
}

public class BoardRenderer
{
    public void Draw(Board board)
    {
        char[,] symbols = new char[3, 3];
        symbols[0, 0] = GetCharacterFor(board.ContentsOf(0, 0));
        symbols[0, 1] = GetCharacterFor(board.ContentsOf(0, 1));
        symbols[0, 2] = GetCharacterFor(board.ContentsOf(0, 2));
        symbols[1, 0] = GetCharacterFor(board.ContentsOf(1, 0));
        symbols[1, 1] = GetCharacterFor(board.ContentsOf(1, 1));
        symbols[1, 2] = GetCharacterFor(board.ContentsOf(1, 2));
        symbols[2, 0] = GetCharacterFor(board.ContentsOf(2, 0));
        symbols[2, 1] = GetCharacterFor(board.ContentsOf(2, 1));
        symbols[2, 2] = GetCharacterFor(board.ContentsOf(2, 2));

        Console.WriteLine($" {symbols[0, 0]} | {symbols[0, 1]} | {symbols[0, 2]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {symbols[1, 0]} | {symbols[1, 1]} | {symbols[1, 2]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {symbols[2, 0]} | {symbols[2, 1]} | {symbols[2, 2]}");
    }

    private char GetCharacterFor(Cell cell) => cell switch { Cell.X => 'X', Cell.O => 'O', Cell.Empty => ' ' };
}

class Player
{
    public Cell Symbol { get; }
    public Player(Cell symbol)
    {
        Symbol = symbol;
    }

    public Square PickSquare(Board board)
    {
        while (true)
        {
            Console.Write("What square do you want to play in? ");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();

            Square choice = key switch
            {
                ConsoleKey.NumPad7 => new Square(0, 0),
                ConsoleKey.NumPad8 => new Square(0, 1),
                ConsoleKey.NumPad9 => new Square(0, 2),
                ConsoleKey.NumPad4 => new Square(1, 0),
                ConsoleKey.NumPad5 => new Square(1, 1),
                ConsoleKey.NumPad6 => new Square(1, 2),
                ConsoleKey.NumPad1 => new Square(2, 0),
                ConsoleKey.NumPad2 => new Square(2, 1),
                ConsoleKey.NumPad3 => new Square(2, 2)
            };

            if(board.IsEmpty(choice.Row, choice.Column))
                return choice;            
            else
                Console.WriteLine("That square is already taken.");
        }
    }
}

public class Square
{
    public int Row { get; }
    public int Column { get; }

    public Square(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

// creates an array of type Cell enum 
public class Board
{
    private readonly Cell[,] _cells = new Cell[3, 3];
    public Cell ContentsOf(int  row, int column) => _cells[row, column];
    public void FillCell(int row, int column, Cell value) => _cells[row, column] = value;
    public bool IsEmpty(int row, int column) => _cells[row, column] == Cell.Empty;
}

public enum Cell { Empty, X, O }