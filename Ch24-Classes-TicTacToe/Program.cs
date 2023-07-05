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

class TicTacToeGame
{
    TicTacToeGameBoard _board = new TicTacToeGameBoard();
    Player p1 = new Player(); // Will be X
    Player p2 = new Player(); // Will be O    
    private int numberOfTurns = 1;
    
    public void PlayGame()
    {
        int arrayPosition;
        string currentPlayer;

        while (!_board.DidSomeoneWin())
        {
            if (numberOfTurns % 2 == 0) 
            {
                currentPlayer = "O";
            }
            else
            {
                currentPlayer = "X";
            }

            Console.WriteLine($"It is {currentPlayer}'s turn");
            _board.PrintBoard();
            Console.Write("What square do you want to play in? ");
            arrayPosition = Convert.ToInt32(Console.ReadLine());
            
            _board.UpdateBoard(arrayPosition, currentPlayer);

            numberOfTurns++;
        }
    }

    public void MakeMove(int arrayPosition, string XorO)
    {

    }
}

public class TicTacToeGameBoard
{
    private string[] _boardArray;    

    public TicTacToeGameBoard()
    {
        _boardArray = new string[9];
        int position = 1;
        /* for (int i = 0; i < _boardArray.Length; i++)
        {
            _boardArray[i] = position.ToString();
            position++;
        } */
    }

    public void UpdateBoard(int arrayPosition, string XorO)
    {
        _boardArray[arrayPosition - 1] = XorO;
    }

    public void PrintBoard()
    {
        Console.WriteLine($" {_boardArray[6]} | {_boardArray[7]} | {_boardArray[8]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {_boardArray[3]} | {_boardArray[4]} | {_boardArray[5]}");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {_boardArray[0]} | {_boardArray[1]} | {_boardArray[2]}");
    }

    public bool DidSomeoneWin()
    {
        // Horizontal Win Condition
        // -- X's Have it
        if (_boardArray[6] == "X" && _boardArray[7] == "X" && _boardArray[8] == "X")
            return true;
        if (_boardArray[3] == "X" && _boardArray[4] == "X" && _boardArray[5] == "X")
            return true;
        if (_boardArray[0] == "X" && _boardArray[1] == "X" && _boardArray[2] == "X")
            return true;
        // -- O's Have it
        if (_boardArray[6] == "O" && _boardArray[7] == "O" && _boardArray[8] == "O")
            return true;
        if (_boardArray[3] == "O" && _boardArray[4] == "O" && _boardArray[5] == "O")
            return true;
        if (_boardArray[0] == "O" && _boardArray[1] == "O" && _boardArray[2] == "O")
            return true;

        // Diagonal Win Condition
        // -- X's Have it
        if (_boardArray[0] == "X" && _boardArray[4] == "X" && _boardArray[8] == "X")
            return true;
        if (_boardArray[6] == "X" && _boardArray[4] == "X" && _boardArray[2] == "X")
            return true;
        // -- O's Have it
        if (_boardArray[0] == "O" && _boardArray[4] == "O" && _boardArray[8] == "O")
            return true;
        if (_boardArray[6] == "O" && _boardArray[4] == "O" && _boardArray[2] == "O")
            return true;

        return false;
    }
}

class Player
{

}