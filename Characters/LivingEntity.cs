
namespace Archuniverse.Characters
{
    public class LivingEntity : Base, ITickable
    {
        public string Name { get; set; }
        public int Health
        {
            get => _health;
            set => _health = Math.Clamp(value, 0, MaxHealth);
        }
        public int Mana
        {
            get => _mana;
            set => _mana = Math.Clamp(value, 0, MaxMana);
        }
        public int Stamina
        {
            get => _stamina;
            set => _stamina = Math.Clamp(value, 0, MaxStamina);
        }
        public int MaxHealth { get; set; } = 100;
        public int MaxMana { get; set; } = 100;
        public int MaxStamina { get; set; } = 100;
        public int HealthRegeneration { get; set; } = 1;
        public int ManaRegeneration { get; set; } = 1;
        public int StaminaRegeneration { get; set; } = 1;

        public int BaseAttack { get; set; } = 10;
        public int BaseDefence { get; set; } = 10;

        public int Xp { get; set; }
        public int Level { get; set; }
        public double Speed { get; set; } = 1.0;
        public double X { get; set; } = 0.0;
        public double Y { get; set; } = 0.0;
        public double Z { get; set; } = 0.0;

        public bool IsDead => Health <= 0;
        public bool IsAlive => !IsDead;
        public bool IsAtFullHealth => Health == MaxHealth;
        public bool IsWounded => Health < MaxHealth && Health > 0;
        public SkillTree Skills { get; set; }

        private int _health;
        private int _mana;
        private int _stamina;


        public LivingEntity(string name, int health, int mana, int stamina, int xp, 
            int level, double speed, int baseAttack, int baseDefence)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Stamina = stamina;
            Xp = xp;
            Level = level;
            Speed = speed;
            BaseAttack = baseAttack;
            BaseDefence = baseDefence;
            Skills = new(this);

            LevelUpBasedOnXp();
        }


        public virtual void RegenerateHealth()
        {
            Health += HealthRegeneration;
        }
        public virtual void RegenerateMana()
        {
            Mana += ManaRegeneration;
        }
        public virtual void RegenerateStamina()
        {
            Stamina += StaminaRegeneration;
        }
        public virtual void RegenerateVitals()
        {
            RegenerateHealth();
            RegenerateMana();
            RegenerateStamina();
        }

        public virtual int CalculateTotalAttack()
        {
            return BaseAttack;
        }

        public virtual int CalculateTotalDefence()
        {
            return BaseDefence;
        }
        public void AddXp(int amount)
        {
            Xp += amount;
            LevelUpBasedOnXp();
        }
        public void LevelUpBasedOnXp()
        {
            while (Xp >= XpRequiredForLevel(Level + 1))
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Level++;
            Skills.GainSkillPoint();
        }

        private static int XpRequiredForLevel(int level)
        {
            return 100 * level * level;
        }


        // Time related stuff here
        public void Tick(float deltaTime)
        {
            _regenTimer += deltaTime;
            if (_regenTimer >= 1.0f)
            {
                RegenerateVitals();
                _regenTimer = 0f;
            }

            // tick the skill tree if needed in future
        }

        private float _regenTimer = 0f;
    }
}
