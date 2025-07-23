namespace Archuniverse.Items
{
    public class EnhancedArmor : ArmorSpecialEffect
    {
        public override void Effect(Armor armor)
        {
            armor.AdditionalDefence += armor.DefenceValue * 50 / 100;
        }
    }

    public class Aggressiveness : WeaponSpecialEffect
    {
        public override void Effect(Weapon weapon)
        {
            weapon.AdditionalAttack += weapon.AttackValue * 50 / 100;
        }
    }

    public class GenderCurse : WareSpecialEffect
    {
        public override void Effect(Ware ware)
        {
            if (ware.Owner.Gender == Character.Sex.Male)
            {
                ware.Owner.Gender = Character.Sex.Female;
            }

            ware.Owner.Gender = Character.Sex.Male;
        }
    }
}
