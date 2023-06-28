/*
 *  Challenge The Properties of Arrows 100 XP
 *  
    Vin Fletcher once again has run to catch up to you for help with his arrows. “My apologies, Programmer! 
    This will be the last time I bother you. My cousin, Flynn Vetcher, is the only other arrow maker in the 
    area. He doesn’t care for his craft and makes wildly dangerous and overpriced arrows. But people keep 
    buying them because they think my GetLength() methods are harder to work with than his public     
 
    _length fields.I don’t want to give up the protections we just gave these arrows, but I remembered you 
    saying something about properties.Maybe you could use those to make my arrows easier to work with?”

    Objectives:
    • Modify your Arrow class to use properties instead of GetX and SetX methods.
    • Ensure the whole program can still run, and Vin can keep creating arrows with i
 */
Console.WriteLine("Hi, I'm Vin Fletcher, the best arrow maker around.  Tell me what kind of arrow you want!");
Arrow arrow = GetArrow();
Console.WriteLine($"The cost for the arrow will be {arrow.GetTotalCost()} gold. A fair price any way you swing it.");


Arrow GetArrow()
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


}

public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
public enum ArrowHead { Steel, Wood, Obsidian }