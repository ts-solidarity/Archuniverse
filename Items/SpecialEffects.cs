using Archuniverse.Characters;

namespace Archuniverse.Items
{
    public class Solidness : ArmorSpecialEffect
    {
        
        public int DefenceBoostPercentage { get; set; } = 10;
        
        
        public Solidness(int defenceBoostPercentage) 
        {
            DefenceBoostPercentage = defenceBoostPercentage;
        }

        public override void Effect(Armor armor)
        {
            armor.AdditionalDefence += armor.DefenceValue * DefenceBoostPercentage / 100;
        }

        public override void Revert(Armor armor)
        {
            armor.AdditionalDefence -= armor.DefenceValue * DefenceBoostPercentage / 100;
        }

    }

    public class Aggressiveness : WeaponSpecialEffect
    {
        public int AttackBoostPercentage { get; set; } = 10;

        public Aggressiveness(int attackBoostPercentage)
        {
            AttackBoostPercentage = attackBoostPercentage;
        }

        public override void Effect(Weapon weapon)
        {
            weapon.AdditionalAttack += weapon.AttackValue * AttackBoostPercentage / 100;
        }
        public override void Revert(Weapon weapon)
        {
            weapon.AdditionalAttack += weapon.AttackValue * AttackBoostPercentage / 100;
        }
    }

    public class GenderCurse : WareSpecialEffect
    {
        public override void Effect(Ware ware)
        {
            if (ware.Owner.Gender == Character.Sex.Male)
            {
                ware.Owner.Gender = Character.Sex.Female;
                return;
            }

            ware.Owner.Gender = Character.Sex.Male;
        }

        public override void Revert(Ware ware)
        {
            if (ware.Owner.Gender == Character.Sex.Male)
            {
                ware.Owner.Gender = Character.Sex.Female;
                return;
            }

            ware.Owner.Gender = Character.Sex.Male;
        }
    }
}
