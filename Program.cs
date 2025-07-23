using Archuniverse.Characters;
using Archuniverse.Items;

namespace Archuniverse
{
    internal class Program
    {
        static void Main()
        {

            Character Izroth = new("Izroth", Character.Sex.Male, 100, 70, 140, 2000, 0, 1);
            Character Lila = new("Lila", Character.Sex.Female, 80, 200, 90, 1500, 0, 1);

            Armor TurtoiseArmor = new("Turtoise Armor", Item.Grade.Rare, 10000, 50);
            Weapon EternalSword = new("Eternal Sword", Item.Grade.Heroic, 50000, 100, 20);

            Armor MermoiseArmor = new("Mermoise Armor", Item.Grade.King, 20000, 60);
            Weapon LostKingsSword = new("Lost King's Sword", Item.Grade.Legendary, 60000, 100, 30);


            Izroth.AddItem(TurtoiseArmor);
            Lila.AddItem(EternalSword);

            Izroth.Equip(TurtoiseArmor);
            Lila.Equip(EternalSword);


            Izroth.AddItem(LostKingsSword);
            Lila.AddItem(MermoiseArmor);

            Izroth.Equip(LostKingsSword);
            Lila.Equip(MermoiseArmor);

            CombatManager combatManager = new();

            combatManager.NewCombat(Lila, Izroth);
            combatManager.FinishAllCombats();

            Console.WriteLine($"{Izroth.Name} is {(Izroth.IsDead? "dead" : "alive")}.");
            Console.WriteLine($"{Lila.Name} is {(Lila.IsDead ? "dead" : "alive")}.");

            Console.WriteLine($"{Izroth.Name}'s Health: {Izroth.Health}");
            Console.WriteLine($"{Lila.Name}'s Health: {Lila.Health}");


        }
    }
}
