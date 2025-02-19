///Packing inventory
///I will need a InventoryItem class that represents any of the different item types. On creation it needs to represents the items, weight and volume
///Each item should pass the correct weight and volume to the base class and created with no parameters
///Types of items include An arrow with a weight of 0.1 and a volume of 0.05
///A bow with a weight of 1 and a volume of 4.
///A rope with a weight of 1 and a volume of 1.5
///Water with a weight of 2 and volume of 3
///Food with a weight of 1 and a volume of 0.5
///A sword with a weight of 5 and a volume of 3
///I will need a Pack class tha can sotre an array of Items
///There needs to be a public bool Add(Inventory item) method to Pack that allows you to add items it should fail/return false if the max weight/volume is exceeded
///There needs to be properties to Pack that allow it to report current items count, weight and volume as well as the limits to each
///Then I need to create a program that creates a new pack and then allows the user to add/attempt to add items chosen from a menu

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
string menu = @"
1)Arrow weight 0.1 Volume 0.05
2)Bow weight 1 volume 4
3)Rope weight 1 volume 1.5
4)Water weight 2 volume 3
5)Food weight 1 volume 0.5
6)Sword weight 5 volume 3
";
Pack pack = new Pack();
while(pack.isFull() == false)
{
    Console.Clear();
    Console.WriteLine("What whould you like to add to your pack?");
    Console.WriteLine($"Your pack can now hold {pack.maxWeight - pack.CurrentWeight()} of weight, {pack.maxVolume - pack.CurrentVolume()} of volume, and {pack.maxItems - pack.CurrentItems()} of Items.");
    Console.WriteLine(menu);
    string choice = Console.ReadLine();
    switch(choice)
    {
        case "1":
        case "Arrow":
        pack.Add(new Arrow());
        break;
        case "2":
        case "Bow":
        pack.Add(new Bow());
        break;
        case "3":
        case "Rope":
        pack.Add(new Rope());
        break;
        case "4":
        case "Water":
        pack.Add(new Water());
        break;
        case "5":
        case "Food":
        pack.Add(new Food());
        break;
        case "6":
        case "Sword":
        pack.Add(new Sword());
        break;
    }
}
Console.WriteLine("Your pack is now full of");
pack.DisplayItems();

class Arrow : InventoryItem
{
    public Arrow()
    {
        Name = "Arrow";
        Weight = 0.1;
        Volume = 0.05;
    }
}

class Bow : InventoryItem
{
    public Bow()
    {
        Name = "Bow";
        Weight = 1;
        Volume = 4;
    }
}

class Rope : InventoryItem
{
    public Rope()
    {
        Name = "Rope";
        Weight = 1;
        Volume = 1.5;
    }
}

class Water : InventoryItem
{
    public Water()
    {
        Name = "Water";
        Weight = 2;
        Volume = 3;
    }
}

class Sword : InventoryItem
{
    public Sword()
    {
        Name = "Sword";
        Weight = 5;
        Volume = 3;
    }
}

class Food : InventoryItem
{
    public Food()
    {
        Name = "Food";
        Weight = 1;
        Volume = 0.5;
    }
}
class InventoryItem
{
    public string Name{get; set;}
    public double Weight{get; protected set;}
    public double Volume{get; protected set;}

    public InventoryItem()
    {
        Name = "InventoryItem";
    }

    public InventoryItem(string name)
    {
        Name = name;
    }
}


class Pack
{
    public double maxWeight{get; set;}
    public double maxVolume{get; set;}
    public int maxItems{get; set;}
    public List<InventoryItem> Store = new List<InventoryItem>();

    public Pack()
    {
        maxItems = 15;
        maxVolume = 30;
        maxWeight = 25;
    }

    public double CurrentWeight()
    {
        double weight = 0;
        foreach(InventoryItem item in Store)
        {
            weight = weight + item.Weight;
        }
        return weight;
    }

    public double CurrentVolume()
    {
        double volume = 0;
        foreach(InventoryItem item in Store)
        {
            volume = volume + item.Volume;
        }
        return volume;
    }

    public int CurrentItems()
    {
        int Items = 0;
        foreach(InventoryItem it in Store)
        {
            Items ++;
        }
        return Items;
    }

    public void Add(InventoryItem item)
    {
        if(CanAdd(item) == true)
        {
            Store.Add(item);
        }else
        {
            Console.WriteLine("That item cannot fit in the pack");
        }
    }

    public bool CanAdd(InventoryItem item)
    {
        if(CurrentWeight() + item.Weight > maxWeight)
        {
            return false;
        }

        if(CurrentVolume() + item.Volume > maxVolume)
        {
            return false;
        }

        if(CurrentItems() + 1 > maxItems)
        {
            return false;
        }
        return true;
    }

    public bool isFull()
    {
        if(maxItems - CurrentItems() == 0)
        {
            return true;
        }

        if(maxVolume - CurrentVolume() == 0)
        {
            return true;
        }

        if(maxWeight - CurrentWeight() == 0)
        {
            return true;
        }

        return false;
    }

    public void DisplayItems()
    {
        int arrowCount = 0;
        int bowCount = 0;
        int ropeCount = 0;
        int waterCount = 0;
        int foodCount = 0;
        int swordCount = 0;
        foreach(InventoryItem item in Store)
        {
            if(item.Name == "Arrow")
            {
                arrowCount ++;
            }
            if(item.Name == "Bow")
            {
                bowCount++;
            }
            if(item.Name == "Rope")
            {
                ropeCount++;
            }
            if(item.Name == "Water")
            {
                waterCount ++;
            }
            if(item.Name == "Food")
            {
                foodCount ++;
            }
            if(item.Name == "Sword")
            {
                swordCount ++;
            }
        }
        if(arrowCount > 0)
        {
            Console.WriteLine($"Arrow {arrowCount}");
        }
        if(bowCount > 0)
        {
            Console.WriteLine($"Bow {bowCount}");
        }
        if(ropeCount > 0)
        {
            Console.WriteLine($"Rope {ropeCount}");
        }
        if(waterCount > 0)
        {
            Console.WriteLine($"Water {waterCount}");
        }
        if(foodCount > 0)
        {
            Console.WriteLine($"Food {foodCount}");
        }
        if(swordCount > 0)
        {
            Console.WriteLine($"Sword {swordCount}");
        }
    }
}