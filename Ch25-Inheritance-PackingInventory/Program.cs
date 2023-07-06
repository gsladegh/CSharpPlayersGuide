/*
 *  Challenge Packing Inventory 150 XP
 * 
    You know you have a long, dangerous journey ahead of you to travel to and repair the Fountain of 
    Objects. You decide to build some classes and objects to manage your inventory to prepare for the trip. 
    You decide to create a Pack class to help in holding your items. Each pack has three limits: the total 
    number of items it can hold, the weight it can carry, and the volume it can hold. Each item has a weight 
    and volume, and you must not overload a pack by adding too many items, too much weight, or too much 
    volume.

    There are many item types that you might add to your inventory, each their own class in the inventory 
    system. 
        (1) An arrow has a weight of 0.1 and a volume of 0.05. 
        (2) A bow has a weight of 1 and a volume of 4.
        (3) Rope has a weight of 1 and a volume of 1.5.
        (4) Water has a weight of 2 and a volume of 3. 
        (5) Food rations have a weight of 1 and a volume of 0.5. 
        (6) A sword has a weight of 5 and a volume of 3.

    Objectives:
    •   Create an InventoryItem class that represents any of the different item types. This class must 
        represent the item’s weight and volume, which it needs at creation time (constructor). 
    •   Create derived classes for each of the types of items above. Each class should pass the correct weight 
        and volume to the base class constructor but should be creatable themselves with a parameterless 
        constructor (for example, new Rope() or new Sword()).
    •   Build a Pack class that can store an array of items. The total number of items, the maximum weight, 
        and the maximum volume are provided at creation time and cannot change afterward.
    •   Make a public bool Add(InventoryItem item) method to Pack that allows you to add items 
        of any type to the pack’s contents.This method should fail (return false and not modify the pack’s 
        fields) if adding the item would cause it to exceed the pack’s item, weight, or volume limit.
    •   Add properties to Pack that allow it to report the current item count, weight, and volume, and the
        limits of each.
    •   Create a program that creates a new pack and then allow the user to add (or attempt to add) items 
        chosen from a menu
 */

Pack myPack = new Pack(5, 10, 10);

while(!myPack.IsFull())
{
    DisplayPackContents(myPack);
    if (AddItemToPack(myPack))
        Console.WriteLine("Added Item!");
    else Console.WriteLine("Failed to Add Item!");
}
Console.WriteLine("Pack is FULL!");

void DisplayPackContents(Pack pack)
{
    Console.WriteLine("Current Contents of Your Pack");
    Console.WriteLine($"Items: {pack.CurrentNoItems} out of {pack._inventoryItems.Length}");
    Console.WriteLine($"Weight: {pack.CurrentWeight} out of {pack.MaxWeight}");
    Console.WriteLine($"Volume: {pack.CurrentVolume} out of {pack.MaxVolume}");
    Console.WriteLine();
}

bool AddItemToPack(Pack pack)
{
    Console.WriteLine("Choose from the menu to add a new item to pack");
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
        6 => new Sword()
    };

    if(pack.IsUnderLimits(newItem))
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

public class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
public class Bow : InventoryItem { public Bow() : base( 1, 4) { } }
public class Rope : InventoryItem { public Rope() : base(1, 1.5f) { } }
public class Water : InventoryItem { public Water() : base(2, 3) { } }
public class Food : InventoryItem { public Food() : base(1, 0.5f) { } }
public class Sword : InventoryItem { public Sword() : base(5, 3) { } }

