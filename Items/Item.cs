
using Archuniverse.Characters;

namespace Archuniverse.Items
{
    public abstract class Item : Base
    {
        public string ItemName { get; set; }
        public Type ItemType { get; set; }
        public Grade ItemGrade { get; set; }
        public int Worth { get; set; }
        public Character? Owner { get; set; }
        public bool Equipped { get; set; } = false;
        public bool Used { get; set; } = false;
        public int AttackValue { get; set; } = 0;
        public int DefenceValue { get; set; } = 0;
        private readonly List<ISpecialEffect> _specialEffects  = [];

        public Item(string name, Type type, Grade grade, int worth)
        {
            ItemName = name;
            ItemType = type;
            ItemGrade = grade;
            Worth = worth;
        }

        public Item(string name, Type type, Grade grade, int worth, List<ISpecialEffect> specialEffects)
        {
            ItemName = name;
            ItemType = type;
            ItemGrade = grade;
            Worth = worth;
            _specialEffects = specialEffects;
        }

        public Item(string name, Type type, Grade grade, int worth, int attackValue, int defenceValue)
        {
            ItemName = name;
            ItemType = type;
            ItemGrade = grade;
            Worth = worth;
            AttackValue = attackValue;
            DefenceValue = defenceValue;
        }

        public Item(string name, Type type, Grade grade, int worth, 
            int attackValue, int defenceValue, List<ISpecialEffect> specialEffects)
        {
            ItemName = name;
            ItemType = type;
            ItemGrade = grade;
            Worth = worth;
            AttackValue = attackValue;
            DefenceValue = defenceValue;
            _specialEffects = specialEffects;
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
    
        public virtual int CalculateTotalDefence()
        {
            return DefenceValue;
        }

        public virtual int CalculateTotalAttack()
        {
            return AttackValue;
        }

        public void AddSpecialEffect(ISpecialEffect effect)
        {
            _specialEffects.Add(effect);
            effect.ApplyEffect(this);
        }

        public void RemoveSpecialEffect(ISpecialEffect effect)
        {
            effect.RevertEffect(this);
            _specialEffects.Remove(effect);
        }

        public void ApplySpecialEffects()
        {
            foreach (var effect in _specialEffects)
            {
                effect.ApplyEffect(this);
            }
        }

        public void RevertSpecialEffects()
        {
            foreach (var effect in _specialEffects)
            {
                effect.RevertEffect(this);
            }
        }

    }
}
