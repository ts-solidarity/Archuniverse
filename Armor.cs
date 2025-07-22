
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
                Owner.EquipArmor(this);
            }
        }

    }
}
