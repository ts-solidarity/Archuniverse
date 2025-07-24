using Archuniverse.Characters;

namespace Archuniverse.Combat
{
    public class CombatManager : Base, ITickable
    {

        public List<Combat> ActiveCombats = [];
        public List<Combat> CompletedCombats = [];
        private float _elapsedTime = 0f;

        public CombatManager() 
        {
            
        }

        public Combat NewCombat(Character firstAttacker, Character firstDefender)
        {
            Combat newCombat = new Combat(firstAttacker, firstDefender);
            ActiveCombats.Add(newCombat);
            return newCombat;
        }

        public void Update()
        {
            foreach (Combat combat in ActiveCombats.ToList())
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
