
namespace Archuniverse.Characters
{
    public class LivingEntity : Base
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

        public int BaseAttack { get; set; } = 10;
        public int BaseDefence { get; set; } = 10;

        public int Xp { get; set; }
        public int Level { get; set; }

        public bool IsDead => Health <= 0;
        public bool IsAlive => !IsDead;
        public bool IsAtFullHealth => Health == MaxHealth;
        public bool IsWounded => Health < MaxHealth && Health > 0;


        private int _health;
        private int _mana;
        private int _stamina;


        public LivingEntity(string name, int health, int mana, int stamina, int xp, int level)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Stamina = stamina;
            Xp = xp;
            Level = level;

            LevelUpBasedOnXp();
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
                Level++;
            }
        }

        private static int XpRequiredForLevel(int level)
        {
            return 100 * level * level;
        }
    }
}
