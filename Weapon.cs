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
                Owner.EquipWeapon(this);
            }
        }

        public int AttackValue { get; set; }
    }
}
