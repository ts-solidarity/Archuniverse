using Archuniverse.Characters;

namespace Archuniverse.Combat
{
    public class Combat : Base, ITickable
    {
        public Character Fighter1 { get; set; }
        public Character Fighter2 { get; set; }
        public bool IsFightOver => Fighter1.IsDead || Fighter2.IsDead;
        public List<Damage> Damages { get; set; } = [];
        private float _elapsedTime = 0f;

        public Combat(Character fighter1, Character fighter2)
        {
            Fighter1 = fighter1;
            Fighter2 = fighter2;
            GameLoop.Instance.RegisterTickable(this);
        }

        public void Fight(Character attacker, Character defender)
        {
            (FightType attackType, int attackAmount) = attacker.CalculateAttack();
            (FightType defenceType, int defenceAmount) = defender.CalculateDefence();

            if (attacker.Drain(attackType) == Result.Success)
            {
                if (defender.Drain(defenceType) == Result.Success)
                {
                    int damageAmount = Math.Max(0, attackAmount - defenceAmount);
                    Damage damage = new(attackType, damageAmount, defender);
                    Damages.Add(damage);
                }

                else
                {
                    int damageAmount = attackAmount;
                    Damage damage = new(attackType, damageAmount, defender);
                    Damages.Add(damage);
                }
            }
        }

        public void Tick(float deltaTime)
        {
            _elapsedTime += deltaTime;

            if (IsFightOver)
            {
                GameLoop.Instance.UnregisterTickable(this);
                _elapsedTime = 0f;

                if (Fighter1.IsDead)
                    GameLoop.Instance.UnregisterTickable(Fighter1);
                else
                    GameLoop.Instance.UnregisterTickable(Fighter2);

                    return;
            }


            if (_elapsedTime >= 1.0f)
            {
                _elapsedTime -= 1.0f;
                Fight(Fighter1, Fighter2);
                (Fighter1, Fighter2) = (Fighter2, Fighter1);
            }

        }

    }
}
