
namespace Archuniverse
{
    public class Potion : Item
    {
        public Potion(string name, Grade grade, int worth,
            int healthBoost, int manaBoost, int staminaBoost) 
            : base(name, Type.Potion, grade, worth)
        {
            HealthBoost = healthBoost;
            ManaBoost = manaBoost;
            StaminaBoost = staminaBoost;
        }

        public int HealthBoost { get; set; }
        public int ManaBoost { get; set; }
        public int StaminaBoost { get; set; }


        public override void Use()
        {
            if (Owner?.Inventory.Contains(this) == true)
            {
                Owner.Health += HealthBoost;
                Owner.Mana += ManaBoost;
                Owner.Stamina += StaminaBoost;

                Owner.Inventory.Remove(this);
            }
        }

    }
}
