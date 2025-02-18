///Packing inventory
///I will need a InventoryItem class that represents any of the different item types. On creation it needs to represents the items, weight and volume
///Each item should pass the correct weight and volume to the base class and created with no parameters
///Types of items include An arrow with a weight of 0.1 and a volume of 0.05
///A bow with a weight of 1 and a volume of 4.
///A rope with a weight of 1 and a volume of 1.5
///Water with a weight of 2 and volume of 3
///Food with a weight of 1 an d a volume of 0.5
///A sword with a weight of 5 and a volume of 3
///I will need a Pack class tha can sotre an array of Items
///There needs to be a public bool Add(Inventory item) method to Pack that allows you to add items it should fail/return false if the max weight/volume is exceeded
///There needs to be properties to Pack that allow it to report current items count, weight and volume as well as the limits to each
///Then I need to create a program that creates a new pack and then allows the user to add/attempt to add items chosen from a menu

using System.Diagnostics;


class InventoryItem
{

}


class Pack
{


    public bool Add(InventoryItem item)
    {
        //for now
        return true;
    }
}