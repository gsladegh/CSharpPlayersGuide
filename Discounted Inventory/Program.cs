/*
 *  Challenge Buying Inventory 100 XP
 *  
    It is time to resupply. A nearby outfitter shop has the supplies you need but is so disorganized that they 
    cannot sell things to you. “Can’t sell if I can’t find the price list,” Tortuga, the owner, tells you as he turns 
    over and attempts to go back to sleep in his reclining chair in the corner. 

    There’s a simple solution: use your programming powers to build something to report the prices of 
    various pieces of equipment based on the user’s selection:

    The following items are available:
    1 – Rope
    2 – Torches
    3 – Climbing Equipment
    4 – Clean Water
    5 – Machete
    6 – Canoe
    7 – Food Supplies
    What number do you want to see the price of? 2
    Torches cost 15 gold. 

    You search around the shop and find ledgers showing the prices for these items: Rope: 10 gold, Torches: 
    16 gold, Climbing Equipment: 24 gold, Clean Water: 2 gold, Machete: 20 gold, Canoe: 200 gold, Food 
    Supplies: 2 gold.

    Objectives:
    • Build a program that will show the menu illustrated above.
    • Ask the user to enter a number from the menu.
    • Using the information above, use a switch (either type) to show the item’s cost.
 */

/*
 *  Challenge Discounted Inventory 50 XP
 *  
    After sorting through Tortuga’s outfitter shop and making it viable again, Tortuga realizes you’ve put him 
    back in business. He wants to repay the favor by giving you a 50% discount on anything you buy from 
    him, and he wants you to modify your program to reflect that.

    After asking the user for a number, the program should also ask for their name. If the name supplied is 
    your name, cut the price in half before reporting it to the user.

    Objectives:
    • Modify your program from before to also ask the user for their name.
    • If their name equals your name, divide the cost in half.
 */

Console.WriteLine("The following items are available: ");
Console.WriteLine("1 – Rope");
Console.WriteLine("2 – Torches");
Console.WriteLine("3 – Climbing Equipment");
Console.WriteLine("4 – Clean Water");
Console.WriteLine("5 – Machete");
Console.WriteLine("6 – Canoe");
Console.WriteLine("7 – Food Supplies");
Console.Write("Who am I talking to? ");
string name = Console.ReadLine();
Console.Write("What number do you want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

bool discount = name == "Grant";

switch (choice)
{
    case 1:
        if (discount)
        {
            Console.WriteLine("Rope costs 5 gold");
        }
        else
            Console.WriteLine("Rope costs 10 gold.");
        break;
    case 2:
        if (discount)
        {
            Console.WriteLine("Rope costs 8 gold");
        }
        else
            Console.WriteLine("Torches cost 16 gold.");
        break;
    case 3:
        if (discount)
        {
            Console.WriteLine("Rope costs 12 gold");
        }
        else
            Console.WriteLine("Climbing equipment costs 24 gold.");
        break;
    case 4:
        if (discount)
        {
            Console.WriteLine("Rope costs 1 gold");
        }
        else
            Console.WriteLine("Clean Water costs 2 gold.");
        break;
    case 5:
        if (discount)
        {
            Console.WriteLine("Rope costs 10 gold");
        }
        else
            Console.WriteLine("Machete costs 20 gold.");
        break;
    case 6:
        if (discount)
        {
            Console.WriteLine("Rope costs 100 gold");
        }
        else
            Console.WriteLine("Canoe costs 200 gold.");
        break;
    case 7:
        if (discount)
        {
            Console.WriteLine("Rope costs 1 gold");
        }
        else
            Console.WriteLine("Food Supplies cost 2 gold.");
        break;
    default:
        Console.WriteLine("That ain't on the menu");
        break;
}
