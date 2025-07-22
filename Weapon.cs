namespace Archuniverse
{
    public class Weapon : Item
    {
        public Weapon(string name, Grade grade, int worth, int attackValue) 
            : base(name, Type.Weapon, grade, worth)
        {
            AttackValue = attackValue;
        }

        public override void Equip()
        {
            if (Owner != null)
            {
                if (!Owner.Inventory.Contains(this))
                    return;


                if (Owner.EquippedWeapon != null)
                {
                    Owner.Inventory.Add(Owner.EquippedWeapon);
                }

                Owner.EquippedWeapon = this;
                Owner.Inventory.Remove(this);
            }
        }

        public override void Unequip()
        {
            if (Owner != null)
            {
                if (Owner.Inventory.Contains(this) && Owner.EquippedWeapon != this)
                    return;

                Owner.EquippedArmor = null;
                Owner.Inventory.Add(this);
            }
        }

        public int AttackValue { get; set; }
    }
}
