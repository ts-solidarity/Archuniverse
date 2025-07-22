
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

        public enum Sex
        {
            Female, Male
        }

        public enum TransferResult
        {
            InsufficientGold, ItemIsNotOwned, Success
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

        public void Use(Item item)
        {
            if (!Inventory.Contains(item) || item.Owner != this)
                return;

            item.Use();
        }


        public void Equip(Item item)
        {
            if (!Inventory.Contains(item) || item.Owner != this)
                return;

            item.Equip();
        }

        public void Unequip(Item item)
        {
            if (Inventory.Contains(item) || item.Owner != this)
                return;

            item.Unequip();
        }

        public void AddItem(Item item)
        {
            if (Inventory.Contains(item))
                return;

            Inventory.Add(item);
            item.Owner = this;
        }

        public void RemoveItem(Item item)
        {
            if (!Inventory.Contains(item))
                return;

            Inventory.Remove(item);
            item.Owner = null;
        }

        public TransferResult TransferItem(Item item, Character other)
        {
            if (!Inventory.Contains(item))
                return TransferResult.ItemIsNotOwned;

            Inventory.Remove(item);
            other.AddItem(item);
            return TransferResult.Success;
        }

        public TransferResult TransferGold(int goldAmount, Character other)
        {
            if (Gold - goldAmount < 0)
                return TransferResult.InsufficientGold;

            Gold -= goldAmount;
            other.Gold += goldAmount;
            return TransferResult.Success;
        }

        public TransferResult SellItem(Item item, int goldAmount, Character other)
        {
            if (other.Gold - goldAmount < 0)
                return TransferResult.InsufficientGold;

            if (!Inventory.Contains(item))
                return TransferResult.ItemIsNotOwned;

            Inventory.Remove(item);
            other.AddItem(item);
            other.TransferGold(goldAmount, this);
            return TransferResult.Success;
        }

        public TransferResult BuyItem(Item item, int goldAmount, Character other)
        {
            if (Gold - goldAmount < 0)
                return TransferResult.InsufficientGold;

            if (!other.Inventory.Contains(item))
                return TransferResult.ItemIsNotOwned;

            other.Inventory.Remove(item);
            AddItem(item);
            TransferGold(goldAmount, other);
            return TransferResult.Success;
        }

    }
}
