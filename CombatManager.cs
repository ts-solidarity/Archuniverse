using Archuniverse.Characters;

namespace Archuniverse
{
    public class CombatManager : Base
    {

        public List<Combat> activeCombats = [];
        public List<Combat> completedCombats = [];


        public CombatManager() 
        {
            
        }

        public Combat NewCombat(Character firstAttacker, Character firstDefender)
        {
            Combat newCombat = new Combat(firstAttacker, firstDefender);
            activeCombats.Add(newCombat);
            return newCombat;
        }

        public void FinishAllCombats()
        {
            foreach (var combat in activeCombats.ToList())
            {
                combat.Fight();
                activeCombats.Remove(combat);
                completedCombats.Add(combat);
            }
        }


    }
}
