using Archuniverse.Characters;

namespace Archuniverse
{
    public class Combat : Base
    {
        public Character Fighter1 { get; }
        public Character Fighter2 { get; }
        public bool IsFightOver { get; set; } = false;

        public Combat(Character firstAttacker, Character firstDefender)
        {
            Fighter1 = firstAttacker;
            Fighter2 = firstDefender;
        }

        public Character Fight()
        {
            Character attacker = Fighter1;
            Character defender = Fighter2;


            while (!attacker.IsDead && !defender.IsDead)
            {
                int attack = attacker.CalculateTotalAttack();
                int defence = defender.CalculateTotalDefence();
                int damage = Math.Max(0, attack - defence);


                defender.Health -= damage;

                if (defender.IsDead)
                {
                    IsFightOver = true;
                    return attacker;
                }

                (attacker, defender) = (defender, attacker);
            }

            IsFightOver = true;
            return attacker;
        }
    }
}
