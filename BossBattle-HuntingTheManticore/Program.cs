/*
 *  Boss Battle Hunting the Manticore 250 XP
 *  
    The Uncoded One’s airship, the Manticore, has begun an all-out attack on the city of Consolas. It must be 
    destroyed, or the city will fall. Only by combining Mylara’s prototype, Skorin’s cannon, and your 
    programming skills will you have a chance to win this fight. You must build a program that allows one 
    user —the pilot of the Manticore— to enter the airship’s range from the city and a second user—the city’s 
    defenses—to attempt to find what distance the airship is at and destroy it before it can lay waste to the 
    town. 

    The first user begins by secretly establishing how far the Manticore is from the city, in the range 0 to 100. 
    The program then allows a second player to repeatedly attempt to destroy the airship by picking the 
    range to target until either the city of Consolas or the Manticore is destroyed. In each attempt, the player 
    is told if they overshot (too far), fell short (not far enough), or hit the Manticore. The damage dealt to the 
    Manticore depends on the turn number. For most turns, 1 point of damage is dealt. But if the turn number 
    is a multiple of 3, a fire blast deals 3 points of damage; a multiple of 5, an electric blast deals 3 points of 
    damage, and if it is a multiple of both 3 and 5, a mighty fire-electric blast deals 10 points of damage. The 
    Manticore is destroyed after taking 10 points of damage. 

    However, if the Manticore survives a turn, it will deal a guaranteed 1 point of damage to the city of 
    Consolas. The city can only take 15 points of damage before being annihilated. 

    Before a round begins, the user should see the current status: the current round number, the city’s health, 
    and the Manticore’s health.

    A sample run of the program is shown below. The first player gets a chance to place the Manticore: 

    Player 1, how far away from the city do you want to station the Manticore? 32
    At this point, the display is cleared, and the second player gets their chance:

    Player 2, it is your turn.
    -----------------------------------------------------------
    STATUS: Round: 1 City: 15/15 Manticore: 10/10
    The cannon is expected to deal 1 damage this round.
    Enter desired cannon range: 50
    That round OVERSHOT the target.
    -----------------------------------------------------------
    STATUS: Round: 2 City: 14/15 Manticore: 10/10
    The cannon is expected to deal 1 damage this round.
    Enter desired cannon range: 25
    That round FELL SHORT of the target.
    -----------------------------------------------------------
    STATUS: Round: 3 City: 13/15 Manticore: 10/10
    The cannon is expected to deal 3 damage this round.
    Enter desired cannon range: 32
    That round was a DIRECT HIT!
    -----------------------------------------------------------
    STATUS: Round: 4 City: 12/15 Manticore: 7/10
    The cannon is expected to deal 1 damage this round.
    Enter desired cannon range: 32
    That round was a DIRECT HIT!
    -----------------------------------------------------------
    STATUS: Round: 5 City: 11/15 Manticore: 6/10
    The cannon is expected to deal 3 damage this round.
    Enter desired cannon range: 32
    That round was a DIRECT HIT!
    -----------------------------------------------------------
    STATUS: Round: 6 City: 10/15 Manticore: 3/10
    The cannon is expected to deal 3 damage this round.
    Enter desired cannon range: 32
    That round was a DIRECT HIT!
    The Manticore has been destroyed! The city of Consolas has been saved!
 
    Objectives:
    • Establish the game’s starting state: the Manticore begins with 10 health points and the city with 15. 
    The game starts at round 1.
    • Ask the first player to choose the Manticore’s distance from the city (0 to 100). Clear the screen 
    afterward.
    • Run the game in a loop until either the Manticore’s or city’s health reaches 0.
    • Before the second player’s turn, display the round number, the city’s health, and the Manticore’s 
    health. 
    • Compute how much damage the cannon will deal this round: 10 points if the round number is a 
    multiple of both 3 and 5, 3 if it is a multiple of 3 or 5 (but not both), and 1 otherwise. Display this to 
    the player.
    • Get a target range from the second player, and resolve its effect. Tell the user if they overshot (too 
    far), fell short, or hit the Manticore. If it was a hit, reduce the Manticore’s health by the expected 
    amount.
    • If the Manticore is still alive, reduce the city’s health by 1.
    • Advance to the next round.
    • When the Manticore or the city’s health reaches 0, end the game and display the outcome.
    • Use different colors for different types of messages.
    • Note: This is the largest program you have made so far. Expect it to take some time! 
    • Note: Use methods to focus on solving one problem at a time.
    • Note: This version requires two players, but in the future, we will modify it to allow the computer 
    to randomly place the Manticore so that it can be a single-player game
 */

using System.Threading.Channels;

int consolasCityHealth = 15;
int manticoreHealth = 10;
int round = 1;

// Player 1 establishes where the manticore is
int manticorePosition = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore?", 0, 100);

// Player 2 fights for their life
Console.Clear();
Console.WriteLine("Player 2, it is your turn.");

while (manticoreHealth > 0 && consolasCityHealth > 0)
{
    // display status for the round.
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("------------------------------------------------");
    DisplayStatus(round, consolasCityHealth, manticoreHealth);

    // Display the amount of damage expected on a hit.
    int possibleCannonDamage = GetPotentialCannonDamage(round);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"The cannon is expected to deal {possibleCannonDamage} damage this round.");

    // Get target from plyer.
    Console.ForegroundColor = ConsoleColor.White;
    int cannonRange = AskForNumber("Enter desired cannon range: ");

    // Display the outcome of the number.
    Console.ForegroundColor = ConsoleColor.Magenta;
    GetCannonResult(cannonRange);

    // Deal damage to the Manticore if it was a hit
    if(cannonRange == manticorePosition) manticoreHealth -= possibleCannonDamage;

    // Deal damage to the city of the Manticore is still alive
    if (manticoreHealth > 0) consolasCityHealth--;    

    round++;    
}

bool won = consolasCityHealth > 0;
DisplayWinOrLose(won);

void DisplayWinOrLose(bool won)
{
    if (won)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed!  The city of Consolas has been saved!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("LOSER!!! You allowed the city of Consolas to be destroyed!");
    }
    
}


// Gets a number from the user, askin the prompt supplied by 'text'.
int AskForNumber(string text)
{
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.Cyan;
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

// Gets a number from the user and ensures it is in he given range.
int AskForNumberInRange(string text, int min, int max)
{
    while(true)
    {
        int number = AskForNumber(text);
        if(number >= min && number <= max)
            return number;
    }
}

void DisplayStatus(int round, int cityHealth, int manticoreHealth) => Console.WriteLine($"STATUS: Round: {round}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");

int GetPotentialCannonDamage(int round)
{
    if (round % 3 == 0 && round % 5 == 0) return 10;
    else if (round % 3 == 0) return 3;
    else if (round % 5 == 0) return 3;
    return 1;
}

void GetCannonResult(int cannonRange)
{
    if (cannonRange > manticorePosition)
    {
        Console.WriteLine("That round OVERSHOT the target."); 
    }
    else if (cannonRange < manticorePosition)
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }
    else
    {
        Console.WriteLine("That round was a DIRECT HIT!");
    }
}
