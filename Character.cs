
using Archuniverse.Items;

namespace Archuniverse
{
    public class Character : Base
    {
        public string Name { get; set; }
        public Sex Gender { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Stamina { get; set; }
        public int Gold { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public List<Item> Inventory { get; set; } = [];
        public Weapon? EquippedWeapon { get; set; }
        public Armor? EquippedArmor { get; set; }
        public int InventoryCapacity { get; set; } = 30;

        public enum Sex
        {
            Female, Male
        }

        public enum Result
        {
            InsufficientGold,       // Not enough gold
            Success,                // Process completed successfuly
            InventoryFull,          // Inventory is at max capacity
            ItemAlreadyOwned,       // Item is alredy owned (Same instance)
            ItemNotInInventory,     // Item is not in inventory
            ItemNotOwned,           // Item owner is different
        }

        public Character(string name, Sex gender, int health, int mana, int stamina, int gold, int xp, int level)
        {
            Name = name;
            Gender = gender;
            Health = health;
            Mana = mana;
            Stamina = stamina;
            Gold = gold;
            Xp = xp;
            Level = level;
        }

        public Result Use(Item item)
        {
            if (item.Owner != this)
                return Result.ItemNotOwned;
            if (!Inventory.Contains(item))
                return Result.ItemNotInInventory;

            item.Use();
            return Result.Success;
        }

        public Result Equip(Item item)
        {
            if (item.Owner != this)
                return Result.ItemNotOwned;
            if (!Inventory.Contains(item))
                return Result.ItemNotInInventory;

            item.Equip();
            return Result.Success;
        }

        public Result Unequip(Item item)
        {
            if (item.Owner != this)
                return Result.ItemNotOwned;

            item.Unequip();
            return Result.Success;
        }

        public Result AddItem(Item item)
        {
            if (Inventory.Contains(item))
                return Result.ItemAlreadyOwned;
            if (Inventory.Count + 1 > InventoryCapacity)
                return Result.InventoryFull;

            Inventory.Add(item);
            item.Owner = this;
            return Result.Success;
        }

        public Result RemoveItem(Item item)
        {
            if (item.Owner != this)
                return Result.ItemNotOwned;
            if (!Inventory.Contains(item))
                return Result.ItemNotInInventory;

            Inventory.Remove(item);
            item.Owner = null;
            return Result.Success;
        }

        public Result TransferItem(Item item, Character other)
        {
            if (item.Owner != this)
                return Result.ItemNotOwned;
            if (!Inventory.Contains(item))
                return Result.ItemNotInInventory;

            Inventory.Remove(item);
            other.AddItem(item);
            return Result.Success;
        }

        public Result TransferGold(int goldAmount, Character other)
        {
            if (Gold - goldAmount < 0)
                return Result.InsufficientGold;

            Gold -= goldAmount;
            other.Gold += goldAmount;
            return Result.Success;
        }

        public Result SellItem(Item item, int goldAmount, Character other)
        {
            if (item.Owner != this)
                return Result.ItemNotOwned;
            if (other.Gold - goldAmount < 0)
                return Result.InsufficientGold;
            if (!Inventory.Contains(item))
                return Result.ItemNotInInventory;

            Inventory.Remove(item);
            other.AddItem(item);
            other.TransferGold(goldAmount, this);
            return Result.Success;
        }

        public Result BuyItem(Item item, int goldAmount, Character other)
        {
            if (item.Owner != other)
                return Result.ItemNotOwned;
            if (Gold - goldAmount < 0)
                return Result.InsufficientGold;
            if (!other.Inventory.Contains(item))
                return Result.ItemNotInInventory;

            other.Inventory.Remove(item);
            AddItem(item);
            TransferGold(goldAmount, other);
            return Result.Success;
        }

        public void AddXp(int amount)
        {
            Xp += amount;

            while (Xp >= XpRequiredForLevel(Level + 1))
            {
                Level++;
            }
        }

        private static int XpRequiredForLevel(int level)
        {
            return 100 * level * level;
        }

    }
}
