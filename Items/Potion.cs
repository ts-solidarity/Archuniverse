
namespace Archuniverse.Items
{
    public class Potion : Item, ITickable
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
        
        private float _elapsedTime = 0f;


        public override void Use()
        {
            if (Owner?.Inventory.Contains(this) == true)
            {
                Owner.Health += HealthBoost;
                Owner.Mana += ManaBoost;
                Owner.Stamina += StaminaBoost;
                ApplySpecialEffects();

                InEffect = true;
                Used = true;


                Owner.Inventory.Remove(this);
                GameLoop.Instance.RegisterTickable(this);
            }
        }

        public void Tick(float deltaTime)
        {
            if (!InEffect) return;

            _elapsedTime += deltaTime;
            if (_elapsedTime >= EffectTime)
            {
                InEffect = false;

                if (Owner != null)
                    RevertSpecialEffects();
                
                GameLoop.Instance.UnregisterTickable(this);
            }
        }
    }
}
