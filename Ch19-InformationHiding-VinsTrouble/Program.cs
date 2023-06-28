/*
 *  Challenge Vin’s Trouble 50 XP
 *  
    “Master Programmer!” Vin Fletcher shouts at you as he races to catch up to you. “I have a problem. I 
    created an arrow for a young man who took it and changed its length to be half as long as I had designed. 
    It no longer fit in his bow correctly and misfired. It sliced his hand pretty bad. He’ll survive, but is there 
    any way we can make sure somebody doesn’t change an arrow’s length when they walk away from my 
    shop? I don’t want to be the cause of such self-inflicted pain.” With your knowledge of information hiding, 
    you know you can help. 

    Objectives:
    • Modify your Arrow class to have private instead of public fields. 
    • Add in getter methods for each of the fields that you have
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
    private ArrowHead _arrowHead;
    private int _shaftLength;
    private Fletching _fletching;

    public Arrow()
    {

    }

    public Arrow(ArrowHead arrowHead, int shaftLength, Fletching fletching)
    {
        _arrowHead = arrowHead;
        _shaftLength = shaftLength;
        _fletching = fletching;
    }

    public ArrowHead GetArrowHead() => _arrowHead;
    public int GetShaftLength() => _shaftLength;
    public Fletching GetFletching() => _fletching;

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