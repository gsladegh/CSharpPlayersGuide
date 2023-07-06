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

void DisplayPackContents(Pack pack)
{
    Console.WriteLine("Current Contents of Your Pack");
    Console.WriteLine($"Items: {pack._currentNoItems} out of {pack._inventoryItems.Length}");
    Console.WriteLine($"Weight: {pack._currentWeight} out of {pack._maxWeight}");
    Console.WriteLine($"Volume: {pack._currentVolume} out of {pack._maxVolume}");
    Console.WriteLine();
}

bool AddItemToPack(Pack pack)
{
    Console.WriteLine("Choose From the Following Menu to add item to pack");
    Console.WriteLine("1 - Arrow");
    Console.WriteLine("2 - Bow");
    Console.WriteLine("3 - Rope");
    Console.WriteLine("3 - Water");
    Console.WriteLine("5 - Food");
    Console.WriteLine("6 - Sword");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {        
        case 1:
            if (pack.IsUnderLimits(new Arrow()))
                pack.Add(new Arrow());
            break;
        case 2:
            if (pack.IsUnderLimits(new Bow()))
                pack.Add(new Bow());
            break;
        case 3:
            if (pack.IsUnderLimits(new Rope()))
                pack.Add(new Rope());
            break;
        case 4:
            if (pack.IsUnderLimits(new Water()))
                pack.Add(new Water());
            break;
        case 5:
            if (pack.IsUnderLimits(new Food()))
                pack.Add(new Food());
            break;
        case 6:
            if (pack.IsUnderLimits(new Sword()))
                pack.Add(new Sword());
            break;
        default:
            return false;            
    }
    return true;

}

public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base((float)0.1, (float)0.05) { }
}

public class Bow : InventoryItem
{
    public Bow() : base((float) 1.0, (float) 0.4) { } 
}

public class Rope : InventoryItem
{
    public Rope() : base(1, (float) 1.5) { }
}

public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
}

public class Food : InventoryItem
{
    public Food() : base(1, (float)0.5) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
}

public class Pack
{
    public InventoryItem[] _inventoryItems { get; set; }
    public float _maxWeight { get; set; }
    public float _maxVolume { get; set; }

    public float _currentWeight = 0;
    public float _currentVolume = 0;
    public int _currentNoItems = 0;
    

    public Pack(int numberOfItems, float maxWeight, float maxVolume)
    {
        _inventoryItems = new InventoryItem[numberOfItems];
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;        
    }

    public bool Add(InventoryItem item)
    {
        if(IsUnderLimits(item))
        {
            _inventoryItems[_currentNoItems] = item;
            _currentNoItems++;
            _currentVolume += item.Volume;
            _currentWeight += item.Weight;
            return true;
        }
        return false;            
    }

    public bool IsUnderLimits(InventoryItem item)
    {
        return item.Weight + _currentWeight < _maxWeight && item.Volume + _currentVolume < _maxVolume && _currentNoItems < _inventoryItems.Length;
    }

    public bool IsFull() => _currentWeight == _maxWeight || _currentVolume == _maxVolume || _currentNoItems == _inventoryItems.Length;
}