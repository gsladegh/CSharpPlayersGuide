/*
 *  Challenge Labeling Inventory 50 XP
 *  
    You realize that your inventory items are not easy to sort through. If you could make it easy to label all 
    of your inventory items, it would be easier to know what items you have in your pack.
    Modify your inventory program from the previous level as described below.

    Objectives:
    • Override the existing ToString method (from the object base class) on all of your inventory item 
    subclasses to give them a name. For example, new Rope().ToString() should return "Rope". 
        -- note that in doing this, the classes already return the name of the class ... changed
    • Override ToString on the Pack class to display the contents of the pack. If a pack contains water, 
    rope, and two arrows, then calling ToString on that Pack object could look like "Pack 
    containing Water Rope Arrow Arrow". 
    • Before the user chooses the next item to add, display the pack’s current contents via its new 
    ToString method.
 */

Pack myPack = new Pack(5, 10, 10);

while (!myPack.IsFull())
{
    Console.WriteLine("************************************************");
    Console.WriteLine();
    DisplayPackContents(myPack);
    if (AddItemToPack(myPack))
        Console.WriteLine("Added Item!");
    else Console.WriteLine("Failed to Add Item!");
    Console.WriteLine();
    Console.WriteLine("************************************************");
}
Console.WriteLine("Pack is FULL!");
DisplayInventoryNames(myPack);

void DisplayPackContents(Pack pack)
{
    Console.WriteLine("Current Contents of Your Pack");
    Console.WriteLine($"{pack.ToString()}");
    Console.WriteLine($"Items: {pack.CurrentNoItems} out of {pack._inventoryItems.Length}");
    Console.WriteLine($"Weight: {pack.CurrentWeight} out of {pack.MaxWeight}");
    Console.WriteLine($"Volume: {pack.CurrentVolume} out of {pack.MaxVolume}");
    Console.WriteLine();
}

void DisplayInventoryNames(Pack pack)
{
    foreach (var item in pack._inventoryItems)
    {
        Console.WriteLine("Item: " + item.ToString());
    }
}

bool AddItemToPack(Pack pack)
{
    Console.WriteLine("Choose from menu to add a new item to pack");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("3 - Water");
    Console.WriteLine("5 - Food");
    Console.WriteLine("6 - Sword");

    int choice = Convert.ToInt32(Console.ReadLine());

    InventoryItem newItem = choice switch
    {
        1 => new Arrow(),
        2 => new Bow(),
        3 => new Rope(),
        4 => new Water(),
        5 => new Food(),
        6 => new Sword(),
        _ => new Arrow() 
    };

    if (pack.IsUnderLimits(newItem))
    {
        pack.Add(newItem);
        return true;
    }

    return false;
}

public class Pack
{
    public InventoryItem[] _inventoryItems;
    public float MaxWeight { get; }
    public float MaxVolume { get; }

    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }
    public int CurrentNoItems = 0;


    public Pack(int numberOfItems, float maxWeight, float maxVolume)
    {
        _inventoryItems = new InventoryItem[numberOfItems];
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }

    public bool Add(InventoryItem item)
    {
        if (IsUnderLimits(item))
        {
            _inventoryItems[CurrentNoItems] = item;
            CurrentNoItems++;
            CurrentVolume += item.Volume;
            CurrentWeight += item.Weight;
            return true;
        }
        return false;
    }

    public bool IsUnderLimits(InventoryItem item) => item.Weight + CurrentWeight < MaxWeight && item.Volume + CurrentVolume < MaxVolume && CurrentNoItems < _inventoryItems.Length;
    public bool IsFull() => CurrentWeight == MaxWeight || CurrentVolume == MaxVolume || CurrentNoItems == _inventoryItems.Length;
    public override string ToString()
    {
        string packContents = string.Empty;

        if (CurrentNoItems == 0)
            return "Pack is empty.";

        for (int i = 0; i < CurrentNoItems; i++)
        {
            packContents += _inventoryItems[i].ToString() + " ";
        }

        return $"Pack contains {packContents}";
    }
}

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem 
{ 
    public Arrow() : base(0.1f, 0.05f) { }
    public override string ToString()
    {
        return "A ARROW";
    }
}
public class Bow : InventoryItem 
{ 
    public Bow() : base(1, 4) { }
    public override string ToString()
    {
        return "AN BOW!";
    }
}

public class Rope : InventoryItem 
{ 
    public Rope() : base(1, 1.5f) { }
    public override string ToString()
    {
        return "AN ROPE!";
    }
}

public class Water : InventoryItem 
{ 
    public Water() : base(2, 3) { }
    public override string ToString()
    {
        return "AN WATER!";
    }
}
public class Food : InventoryItem 
{ 
    public Food() : base(1, 0.5f) { }
    public override string ToString()
    {
        return "AN FOOD!";
    }
}
public class Sword : InventoryItem 
{ 
    public Sword() : base(5, 3) { } 
}