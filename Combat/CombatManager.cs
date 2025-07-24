using Archuniverse.Characters;

namespace Archuniverse.Combat
{
    public class CombatManager : Base, ITickable
    {
        public List<RealtimeCombat> ActiveCombats = [];
        public List<RealtimeCombat> CompletedCombats = [];
        private float _elapsedTime = 0f;

        public CombatManager()
        {
            GameLoop.Instance.RegisterTickable(this);
        }

        public RealtimeCombat NewCombat(Character firstAttacker, Character firstDefender)
        {
            RealtimeCombat newCombat;
            newCombat = new RealtimeCombat(firstAttacker, firstDefender);
            ActiveCombats.Add(newCombat);
            return newCombat;
        }

        public void Update()
        {
            foreach (RealtimeCombat combat in ActiveCombats.ToList())
            {
                if (combat.IsFightOver)
                {
                    ActiveCombats.Remove(combat);
                    CompletedCombats.Add(combat);
                }
            }
        }

        public void Tick(float deltaTime)
        {
            _elapsedTime += deltaTime;

            if (_elapsedTime >= 1.0f)
            {
                _elapsedTime -= 1.0f;
                Update();
            }
        }
    }
}