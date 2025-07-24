using Archuniverse.Items;
using Archuniverse.Characters;
using Archuniverse.Combat;

namespace Archuniverse
{
    public class Game
    {
        public CombatManager CombatManager { get; set; }

        public Game()
        {
            CombatManager = new CombatManager();
        }
    }
}