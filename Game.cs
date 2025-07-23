using Archuniverse.Items;
using Archuniverse.Characters;

namespace Archuniverse
{
    public enum Result
    {
        InsufficientGold,       // Not enough gold
        Success,                // Process completed successfuly
        InventoryFull,          // Inventory is at max capacity
        ItemAlreadyOwned,       // Item is alredy owned (Same instance)
        ItemNotInInventory,     // Item is not in inventory
        ItemNotOwned,           // Item owner is different
        InsufficientLevel,      // Not enough level to take some action
    }

    public class Game
    {

    }
}
