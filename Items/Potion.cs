
namespace Archuniverse.Items
{
    public class Potion : Item
    {
        public Potion(string name, Grade grade, int worth,
            int healthBoost, int manaBoost, int staminaBoost,
            int effectTime) 
            : base(name, Type.Potion, grade, worth)
        {
            HealthBoost = healthBoost;
            ManaBoost = manaBoost;
            StaminaBoost = staminaBoost;
            EffectTime = effectTime;
        }

        public int HealthBoost { get; set; }
        public int ManaBoost { get; set; }
        public int StaminaBoost { get; set; }
        public int EffectTime { get; set; }
        public bool InEffect { get; set; } = false;

        public override void Use()
        {
            if (Owner?.Inventory.Contains(this) == true)
            {
                Owner.Health += HealthBoost;
                Owner.Mana += ManaBoost;
                Owner.Stamina += StaminaBoost;
                ApplySpecialEffects();

                InEffect = true;
                StartCountdown();

                Owner.Inventory.Remove(this);
            }
        }

        public void StartCountdown()
        {

        }
    }
}
