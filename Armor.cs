
namespace Archuniverse
{
    public class Armor : Item
    {
        public Armor(string name, Grade grade, int worth, int defenceBoost) 
            : base(name, Type.Armor, grade, worth)
        {
            DefenceBoost = defenceBoost;
        }


        public int DefenceBoost{ get; set; }

        public override void Equip()
        {
            if (Owner != null)
            {
                if (!Owner.Inventory.Contains(this))
                    return;


                if (Owner.EquippedArmor != null)
                {
                    Owner.Inventory.Add(Owner.EquippedArmor);
                }

                Owner.EquippedArmor = this;
                Owner.Inventory.Remove(this);
            }
        }

        public override void Unequip()
        {
            if (Owner != null)
            {
                if (Owner.Inventory.Contains(this) && Owner.EquippedArmor != this)
                    return;

                Owner.EquippedArmor = null;
                Owner.Inventory.Add(this);
            }
        }

    }
}
