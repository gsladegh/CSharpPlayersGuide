/*
 *  Challenge Arrow Factories 100 XP
 *  
    Vin Fletcher sometimes makes custom-ordered arrows, but these are rare. Most of the time, he sells one 
    of the following standard arrows:

    • The Elite Arrow, made from a steel arrowhead, plastic fletching, and a 95 cm shaft.
    • The Beginner Arrow, made from a wood arrowhead, goose feathers, and a 75 cm shaft.
    • The Marksman Arrow, made from a steel arrowhead, goose feathers, and a 65 cm shaft.

    You can make static methods to make these specific variations of arrows easy.

    Objectives:

    • Modify your Arrow class one final time to include static methods of the form public static 
    Arrow CreateEliteArrow() { ... } for each of the three above arrow types.

    • Modify the program to allow users to choose one of these pre-defined types or a custom arrow. If 
    they select one of the predefined styles, produce an Arrow instance using one of the new static 
    methods. If they choose to make a custom arrow, use your earlier code to get their custom data 
    about the desired arrow
 */

Console.WriteLine("Hi, I'm Vin Fletcher, the best arrow maker around.  Tell me what kind of arrow you want!");
Arrow arrow = GetArrow();
Console.WriteLine($"The cost for the arrow will be {arrow.GetTotalCost()} gold. A fair price any way you swing it.");

Arrow GetArrow()
{
    Console.Write("Which service are you interested in? Standard or Custom? ");
    string choice = Console.ReadLine();
    return choice switch
    {
        "Standard" => GetStandardArrow(),
        "Custom" => GetCustomArrow(),
        _ => Arrow.CreateBeginnerArrow()
    };
}

Arrow GetStandardArrow() 
{
    Console.Write("Which standard arrow? (Beginner, Elite, or Marksman) ");
    string choice = Console.ReadLine();
    return choice switch
    {
        "Beginner" => Arrow.CreateBeginnerArrow(),
        "Elite" => Arrow.CreateEliteArrow(),
        "Marksman" => Arrow.CreateMarksmanArrow(),
        _ => Arrow.CreateBeginnerArrow()
    };    
}

Arrow GetCustomArrow()
{    
    int length = AskForRange("How long (cm) do you want your arrow shaft to be?: ", 60, 100);
    ArrowHead arrowHead = GetArrowHead();
    Fletching fletching = GetFletching();
    return new Arrow(arrowHead, length, fletching);
}

Fletching GetFletching()
{
    Console.Write("What kind of fletching do you want (plastic, goose feathers or turkey feathers)? ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "goose feathers" => Fletching.GooseFeathers,
        "turkey features" => Fletching.TurkeyFeathers,
        _ => Fletching.Plastic
    };
}

ArrowHead GetArrowHead()
{
    Console.Write("Do you want a steel, wood or obsidian arrowhead? ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => ArrowHead.Steel,
        "wood" => ArrowHead.Wood,
        "obsidian" => ArrowHead.Obsidian,
        _ => ArrowHead.Wood
    };
}

int AskForRange(string text, int min, int max)
{
    do
    {
        int length = AskForNumber(text);
        if (length >= min && length <= max) return length;
    }
    while (true);
}

int AskForNumber(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

public class Arrow
{
    private ArrowHead _arrowHead { get; }
    private int _shaftLength { get; }
    private Fletching _fletching { get; }

    public Arrow()
    {

    }

    public Arrow(ArrowHead arrowHead, int shaftLength, Fletching fletching)
    {
        _arrowHead = arrowHead;
        _shaftLength = shaftLength;
        _fletching = fletching;
    }

    public float GetTotalCost()
    {
        return (float)(_shaftLength * .05) + GetArrowHeadCost() + GetFletchingCost();
    }

    public int GetArrowHeadCost()
    {
        // For arrowheads, steel costs 10 gold, wood costs 3 gold, and obsidian costs 5 gold.
        return _arrowHead switch
        {
            ArrowHead.Steel => 10,
            ArrowHead.Wood => 3,
            ArrowHead.Obsidian => 5
        };
    }

    public int GetFletchingCost()
    {
        // For fletching, plastic costs 10 gold, turkey feathers cost 5 gold, and goose feathers cost 3 gold
        return _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };
    }

    public static Arrow CreateEliteArrow() => new Arrow(ArrowHead.Steel, 95, Fletching.Plastic);

    public static Arrow CreateBeginnerArrow() => new Arrow(ArrowHead.Wood, 75, Fletching.GooseFeathers);

    public static Arrow CreateMarksmanArrow() => new Arrow(ArrowHead.Steel, 65, Fletching.GooseFeathers);
    
}

public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
public enum ArrowHead { Steel, Wood, Obsidian }