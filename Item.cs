namespace Archuniverse
{
    public abstract class Item : Base
    {
        public string ItemName { get; set; }
        public Type ItemType { get; set; }
        public Grade ItemGrade { get; set; }
        public int Worth { get; set; }
        public Character? Owner { get; set; }

        public Item(string name, Type type, Grade grade, int worth)
        {
            ItemName = name;
            ItemType = type;
            ItemGrade = grade;
            Worth = worth;
        }

        public enum Type
        {
            Ware, Food, Weapon, Armor, Potion
        }

        public enum Grade
        {
            Ordinary, Common, Uncommon, Rare, Saint, Heroic, King, Legendary, God
        }

        public virtual void Use()
        {

        }

        public virtual void Equip()
        {

        }

        public virtual void Unequip()
        {
            
        }
    }
}
