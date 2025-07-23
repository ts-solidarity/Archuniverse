
namespace Archuniverse.Items
{
    public interface ISpecialEffect
    {
        void Apply(Item item);
    }

    public abstract class ArmorSpecialEffect : ISpecialEffect
    {
        public void Apply(Item item)
        {
            if (item is Armor armor && armor.Owner != null && armor.Equipped)
            {
                Effect(armor);
            }
        }

        public abstract void Effect(Armor armor);
    }

    public abstract class WeaponSpecialEffect : ISpecialEffect
    {
        public void Apply(Item item)
        {
            if (item is Weapon weapon && weapon.Owner != null && weapon.Equipped)
            {
                Effect(weapon);
            }
        }

        public abstract void Effect(Weapon weapon);
    }

    public abstract class WareSpecialEffect : ISpecialEffect
    {
        public void Apply(Item item)
        {
            if (item is Ware ware && ware.Owner != null && ware.Owner?.Inventory.Contains(item) == true)
            {
                Effect(ware);
            }
        }

        public abstract void Effect(Ware ware);
    }

    public abstract class PotionSpecialEffect : ISpecialEffect
    {
        public void Apply(Item item)
        {
            if (item is Potion potion && potion.Used == true && potion.InEffect)
            {
                Effect(potion);
            }
        }

        public abstract void Effect(Potion potion);
    }
}
