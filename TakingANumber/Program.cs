/*
 *  Challenge Taking a Number 100 XP
 *  
    Many previous tasks have required getting a number from a user. To save time writing this code 
    repeatedly, you have decided to make a method to do this common task.

    Objectives:

    • Make a method with the signature int AskForNumber(string text). Display the text
    parameter in the console window, get a response from the user, convert it to an int, and return it. 
    This might look like this: int result = AskForNumber("What is the airspeed velocity 
    of an unladen swallow?");. 

    • Make a method with the signature int AskForNumberInRange(string text, int min, int 
    max). Only return if the entered number is between the min and max values. Otherwise, ask again.

    • Place these methods in at least one of your previous programs to improve it
 */

int AskForNumber(string text)
{
    Console.Write(text);    
    return Convert.ToInt32(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{    
    while(true)
    {
        Console.WriteLine($"{text}: {min} - {max}");
        int number = Convert.ToInt32(Console.ReadLine());
        if( number > min &&  number < max )
        {
            Console.WriteLine("YES! Congrats, you got it");
            return number;            
        }
    }
}

AskForNumber("What is John Riggin's Jesey Number?");
AskForNumberInRange("Give me a number in between the following range", 1, 100);