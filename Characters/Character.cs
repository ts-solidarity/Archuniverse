using Archuniverse.Items;

namespace Archuniverse.Characters
{
    public class Character : LivingEntity
    {
        public Sex Gender { get; set; }
        public int Gold { get; set; }
        public List<Item> Inventory { get; set; } = [];
        public Weapon? EquippedWeapon { get; set; }
        public Armor? EquippedArmor { get; set; }
        public int InventoryCapacity { get; set; } = 30;


        public enum Sex
        {
            Female, Male
        }

        public Character(string name, Sex gender, int health, int mana, int stamina, int gold, int xp, 
            int level, double speed, int baseAttack, int baseDefence)
            : base(name, health, mana, stamina, xp, level, speed, baseAttack, baseDefence)
        {
            Gender = gender;
            Gold = gold;
        }

        public override int CalculateTotalAttack()
        {
            return base.CalculateTotalAttack() + ((EquippedWeapon != null) ? EquippedWeapon.CalculateTotalAttack() : 0);
        }

        public override int CalculateTotalDefence()
        {
            return base.CalculateTotalDefence() + ((EquippedArmor != null) ? EquippedArmor.CalculateTotalDefence() : 0);
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
            if (IsInventoryFull())
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
            if (other.IsInventoryFull())
                return Result.InventoryFull;

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

        public bool IsInventoryFull()
        {
            return Inventory.Count >= InventoryCapacity;
        }
    }
}
