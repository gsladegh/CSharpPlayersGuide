/*
 * Challenge Simula’s Soup 100 XP
 * 
    Simula is impressed with how you reconstructed the box with an enumeration. When the box opened, 
    you saw a glowing emerald gem inside. You don’t know what it is, but it seems important. Also in the box 
    were three vials of powder labeled HOT, SALTY, and SWEET.

    “Finally! I can make soup again!” Simula says. She casually tosses the small glowing gem to you but is 
    wholly focused on the powders. “You stick around and help me make soup with your programming skills, 
    and I’ll tell you what that gem does.”

    She pulls out a cookpot, knocks the clutter off the table with a quick sweep of her arm, and begins 
    cooking. She says, “I’m the best soup maker in town, and you’re in for a treat. I’ve got recipes for soup, 
    stew, and gumbo. I’ve got mushrooms, chicken, carrots, and potatoes for ingredients. And thanks to you 
    getting that box open, I’ve got seasonings again! Spicy, salty, and sweet seasoning. Pick a recipe, an 
    ingredient, and a seasoning, and I’ll make it. Use your programming skills to help us track what we make.”

    Objectives:
    • Define enumerations for the three variations on food: type (soup, stew, gumbo), main ingredient 
    (mushrooms, chicken, carrots, potatoes), and seasoning (spicy, salty, sweet).

    • Make a tuple variable to represent a soup composed of the three above enumeration types.

    • Let the user pick a type, main ingredient, and seasoning from the allowed choices and fill the tuple 
    with the results. Hint: You could give the user a menu to pick from or simply compare the user’s 
    text input against specific strings to determine which enumeration value represents their choice. 

    • When done, display the contents of the soup tuple variable in a format like “Sweet Chicken Gumbo.” 

    Hint: You don’t need to convert the enumeration value back to a string. Simply displaying an 
    enumeration value with Write or WriteLine will display the name of the enumeration value.) 
 *
 */

(MealType MealType, MainIngredient MainIngredient, Seasoning Seasoning) soup;

// ask user for the type of meal they'd like
Console.WriteLine("Hi, welcome to my kitchen! Please pick the type of food you'd like me to prepare.");
Console.WriteLine("1 - Soup");
Console.WriteLine("2 - Stew");
Console.WriteLine("3 - Gumbo");

int mealChoice = Convert.ToInt32(Console.ReadLine());

switch (mealChoice)
{
    case 1:
        soup.MealType = MealType.Soup;
        break;
    case 2:
        soup.MealType = MealType.Stew;
        break;
    case 3:
        soup.MealType = MealType.Gumbo;
        break;
    default:
        Console.WriteLine("Not a valid choice.  Leftover Gumbo it is!");
        soup.MealType = MealType.Gumbo;
        break;
}

// ask user for the type of main ingredient they'd like
Console.WriteLine("Please pick your main ingredient.");
Console.WriteLine("1 - Mushrooms");
Console.WriteLine("2 - Chicken");
Console.WriteLine("3 - Carrots");
Console.WriteLine("4 - Potatoes");

int ingredientChoice = Convert.ToInt32(Console.ReadLine());

switch (ingredientChoice)
{    
    case 1:
        soup.MainIngredient = MainIngredient.Mushroom;
        break;
    case 2:
        soup.MainIngredient = MainIngredient.Chicken;
        break;
    case 3:
        soup.MainIngredient = MainIngredient.Carrot;
        break;
    case 4:
        soup.MainIngredient = MainIngredient.Potato;
        break;
    default:
        Console.WriteLine("Not a valid choice.  Leftover Potatoes it is!");
        soup.MainIngredient = MainIngredient.Potato;
        break;
}

// ask user for the type of seasoning they'd like
Console.WriteLine("Please pick the type of seasoning you want.");
Console.WriteLine("1 - Spicy");
Console.WriteLine("2 - Salty");
Console.WriteLine("3 - Sweet");

int spiceChoice = Convert.ToInt32(Console.ReadLine());

switch (spiceChoice)
{
    case 1:
        soup.Seasoning = Seasoning.Spicy;
        break;
    case 2:
        soup.Seasoning = Seasoning.Salty;
        break;
    case 3:
        soup.Seasoning = Seasoning.Sweet;
        break;
    default:
        Console.WriteLine("Not a valid choice.  Get ready for a lot of salt!");
        soup.Seasoning = Seasoning.Salty;
        break;
}

Console.WriteLine($"{soup.Seasoning} {soup.MainIngredient} {soup.MealType}.");

enum MealType
{
    Soup,
    Stew,
    Gumbo
}

enum MainIngredient
{
    Mushroom,
    Chicken,
    Carrot,
    Potato
}

enum Seasoning
{
    Spicy,
    Salty,
    Sweet
}



