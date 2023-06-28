/*
 *  Challenge Vin Fletcher’s Arrows 100 XP
 *  
    Vin Fletcher is a skilled arrow maker. He asks for your help building a new class to represent arrows and 
    determine how much he should sell them for. “A tiny fragment of my soul goes into each arrow; I care 
    not for the money; I just need to be able to recoup my costs and get food on the table,” he says.
    
    Each arrow has three parts: the arrowhead (steel, wood, or obsidian), the shaft (a length between 60 and 
    100 cm long), and the fletching (plastic, turkey feathers, or goose feathers).

    His costs are as follows: For arrowheads, steel costs 10 gold, wood costs 3 gold, and obsidian costs 5 gold.
    For fletching, plastic costs 10 gold, turkey feathers cost 5 gold, and goose feathers cost 3 gold. For the 
    shaft, the price depends on the length: 0.05 gold per centimeter.

    Objectives:
    • Define a new Arrow class with fields for arrowhead type, fletching type, and length. (Hint:
    arrowhead types and fletching types might be good enumerations.)
    • Allow a user to pick the arrowhead, fletching type, and length and then create a new Arrow instance. 
    • Add a GetCost method that returns its cost as a float based on the numbers above, and use this 
    to display the arrow’s cost
 */

Console.WriteLine("Hi, I'm Vin Fletcher, the best arrow maker around.  Tell me what kind of arrow you want!");
int length = AskForRange("How long (cm) do you want your arrow shaft to be?: ", 60, 100);
ArrowHead arrowHead = GetArrowHead();
Fletching fletching = GetFletching();

Arrow myArrow = new Arrow(arrowHead, length, fletching);

Console.WriteLine($"The cost for the arrow will be {myArrow.GetTotalCost()}. A fair price any way you swing it.");


Fletching GetFletching()
{
    Console.Write("What kind of fletching do you want? Plastic, goose feathers (goose) or turkey feathers (turkey)? ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "goose" => Fletching.GooseFeathers,
        "turkey" => Fletching.TurkeyFeathers
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
        "obsidian" => ArrowHead.Obsidian
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
    public ArrowHead _arrowHead;
    public int _shaftLength;
    public Fletching _fletching;

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
        return (float)(_shaftLength * .05) + (float) GetArrowHeadCost() + (float) GetFletchingCost();
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

    public float GetFletchingCost()
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