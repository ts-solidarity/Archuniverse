
namespace Archuniverse
{
    public class Character : Base
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Stamina { get; set; }
        public int Gold { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public List<Item> Inventory { get; set; } = [];
        public Weapon? EquippedWeapon { get; set; }
        public Armor? EquippedArmor { get; set; }



        public Character(string name, int health, int mana, int stamina, int gold, int xp, int level)
        {
            Name = name;
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

        public void TransferItem(Item item, Character other)
        {
            if (!Inventory.Contains(item))
                return;

            Inventory.Remove(item);
            other.AddItem(item);
        }

    }
}
