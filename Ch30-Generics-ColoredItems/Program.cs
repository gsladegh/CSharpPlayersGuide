/*
 *  Challenge Colored Items 100 XP
 *  
    You have a sword, a bow, and an axe in front of you, defined like this:

    public class Sword { }
    public class Bow { }
    public class Axe { }

    You want to associate a color with these items (or any item type). You could make ColoredSword
    derived from Sword that adds a Color property, but doing this for all three item types will be 
    painstaking. Instead, you define a new generic ColoredItem class that does this for any item.

    Objectives:
    • Put the three class definitions above into a new project.

    • Define a generic class to represent a colored item. It must have properties for the item itself (generic 
    in type) and a ConsoleColor associated with it. 

    • Add a void Display() method to your colored item type that changes the console’s foreground 
    color to the item’s color and displays the item in that color. (Hint: It is sufficient to just call 
    ToString() on the item to get a text representation.)

    • In your main method, create a new colored item containing a blue sword, a red bow, and a green axe. 
    Display all three items to see each item displayed in its color.

 */


ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.DarkYellow);

sword.Display();
bow.Display();
axe.Display();

public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<TItem>
{
    public ConsoleColor ConsoleColor { get; set; }

    public TItem Item { get; set; }

    public ColoredItem(TItem item, ConsoleColor color)
    {
        Item = item;
        ConsoleColor = color;
    }

    public void Display()
    {
        Console.ForegroundColor = ConsoleColor;
        Console.WriteLine(Item);
    }
} 