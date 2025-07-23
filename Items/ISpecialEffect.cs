
namespace Archuniverse.Items
{
    public interface ISpecialEffect
    {
        void ApplyEffect(Item item);
        void RevertEffect(Item item);
    }



    public abstract class ArmorSpecialEffect : ISpecialEffect
    {
        public void ApplyEffect(Item item)
        {
            if (item is Armor armor && armor.Owner != null && armor.Equipped)
            {
                Effect(armor);
                Applied = true;
            }
        }

        public void RevertEffect(Item item)
        {
            if (item is Armor armor &&  Applied)
            {
                Revert(armor);
            }
        }

        public abstract void Effect(Armor armor);
        public abstract void Revert(Armor armor);
        public bool Applied { get; set; } = false;
    }


    public abstract class WeaponSpecialEffect : ISpecialEffect
    {
        public void ApplyEffect(Item item)
        {
            if (item is Weapon weapon && weapon.Owner != null && weapon.Equipped)
            {
                Effect(weapon);
                Applied = true;
            }
        }

        public void RevertEffect(Item item)
        {
            if (item is Weapon weapon && Applied)
            {
                Revert(weapon);
            }
        }

        public abstract void Effect(Weapon weapon);
        public abstract void Revert(Weapon weapon);
        public bool Applied { get; set; } = false;
    }


    public abstract class WareSpecialEffect : ISpecialEffect
    {
        public void ApplyEffect(Item item)
        {
            if (item is Ware ware && ware.Owner != null && ware.Owner?.Inventory.Contains(item) == true)
            {
                Effect(ware);
                Applied = true;
            }
        }

        public void RevertEffect(Item item)
        {
            if (item is Ware ware && Applied)
            {
                Revert(ware);
            }
        }

        public abstract void Effect(Ware ware);
        public abstract void Revert(Ware ware);
        public bool Applied { get; set; } = false;
    }


    public abstract class PotionSpecialEffect : ISpecialEffect
    {
        public void ApplyEffect(Item item)
        {
            if (item is Potion potion && potion.Used == true && potion.InEffect)
            {
                Effect(potion);
                Applied = true;
            }
        }

        public void RevertEffect(Item item)
        {
            if (item is Potion potion && Applied)
            {
                Revert(potion);
            }
        }

        public abstract void Effect(Potion potion);
        public abstract void Revert(Potion potion);
        public bool Applied { get; set; } = false;
    }
}
