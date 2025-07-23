using Archuniverse.Characters;
using Archuniverse.Items;

namespace Archuniverse
{
    internal class Program
    {
        static void Main()
        {

            // Creating characters and items, adding them to their inventory and equipping them
            Character Izroth = new("Izroth", Character.Sex.Male, 100, 70, 140, 2000, 0, 1, 1.0, 20, 20);
            Character Lila = new("Lila", Character.Sex.Female, 80, 200, 90, 1500, 0, 1, 1.0, 15, 30);

            Armor TurtoiseArmor = new("Turtoise Armor", Item.Grade.Rare, 10000, 50);
            Weapon LostKingsSword = new("Lost King's Sword", Item.Grade.Legendary, 60000, 100, 30);

            Armor MermoiseArmor = new("Mermoise Armor", Item.Grade.King, 20000, 60);
            Weapon EternalSword = new("Eternal Sword", Item.Grade.Heroic, 50000, 100, 20);

            LostKingsSword.AddSpecialEffect(new Aggressiveness(50));


            Izroth.AddItem(TurtoiseArmor);
            Izroth.AddItem(LostKingsSword);

            Izroth.Equip(TurtoiseArmor);
            Izroth.Equip(LostKingsSword);

            Lila.AddItem(EternalSword);
            Lila.AddItem(MermoiseArmor);

            Lila.Equip(EternalSword);
            Lila.Equip(MermoiseArmor);


            // Leveling up to check out skills
            Izroth.AddXp(10000);
            Lila.AddXp(10000);

            Izroth.Skills.UnlockSkill("Carrier");
            Lila.Skills.UnlockSkill("Iron Body");


            // Combat begins
            CombatManager combatManager = new();

            combatManager.NewCombat(Lila, Izroth);<
            combatManager.FinishAllCombats();

            Console.WriteLine($"{Izroth.Name} is {(Izroth.IsDead? "dead" : "alive")}.");
            Console.WriteLine($"{Lila.Name} is {(Lila.IsDead ? "dead" : "alive")}.");

            Console.WriteLine($"{Izroth.Name}'s Health: {Izroth.Health}");
            Console.WriteLine($"{Lila.Name}'s Health: {Lila.Health}");


        }
    }
}
