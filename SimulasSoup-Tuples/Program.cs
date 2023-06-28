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

(MealType mealType, MainIngredient mainIngredient, Seasoning seasoning) soup = GetSoup();
Console.WriteLine($"{soup.seasoning} {soup.mainIngredient} {soup.mealType}.");

(MealType, MainIngredient, Seasoning) GetSoup()
{
    MealType type = GetMealType();
    MainIngredient ingredient = GetMainIngredient();
    Seasoning seasoning = GetSeasoning();
    return (type, ingredient, seasoning);
}

MealType GetMealType()
{
    // ask user for the type of meal they'd like
    Console.WriteLine("Hi, welcome to my kitchen! Please pick the type of food you'd like me to prepare.");
    Console.WriteLine("1 - Soup");
    Console.WriteLine("2 - Stew");
    Console.WriteLine("3 - Gumbo");

    int input = Convert.ToInt32(Console.ReadLine());

    return input switch
    {
        1 => MealType.Soup,
        2 => MealType.Stew,
        3 => MealType.Gumbo,
        _ => MealType.Gumbo
    };
}

MainIngredient GetMainIngredient()
{
    // ask user for the type of main ingredient they'd like
    Console.WriteLine("Please pick your main ingredient.");
    Console.WriteLine("1 - Mushrooms");
    Console.WriteLine("2 - Chicken");
    Console.WriteLine("3 - Carrots");
    Console.WriteLine("4 - Potatoes");

    int input = Convert.ToInt32(Console.ReadLine());

    return input switch
    {
        1 => MainIngredient.Mushroom,
        2 => MainIngredient.Chicken,
        3 => MainIngredient.Carrot,
        4 => MainIngredient.Potato,
        _ => MainIngredient.Potato
    };
}

Seasoning GetSeasoning()
{
    // ask user for the type of seasoning they'd like
    Console.WriteLine("Please pick the type of seasoning you want.");
    Console.WriteLine("1 - Spicy");
    Console.WriteLine("2 - Salty");
    Console.WriteLine("3 - Sweet");

    int input = Convert.ToInt32(Console.ReadLine());

    return input switch
    {
        1 => Seasoning.Spicy,
        2 => Seasoning.Salty,
        3 => Seasoning.Sweet,
        _ => Seasoning.Salty
    };
}

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



