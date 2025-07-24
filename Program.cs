using Archuniverse.Characters;
using Archuniverse.Combat;
using Archuniverse.Items;

namespace Archuniverse
{
    internal class Program
    {
        static void Main()
        {
            
            // TODO
            // Living Manager
            // Item Manager
            // Arrange skills for characters only
            

            Game game = new Game();


            // Creating characters and items, adding them to their inventory and equipping them
            Character Izroth = new("Izroth", Character.Sex.Male, 100, 100, 100, 2000, 0, 1, 1.0f, 20, 20);
            Character Lila = new("Lila", Character.Sex.Female, 100, 100, 100, 1500, 0, 1, 1.0f, 15, 30);

            Armor OrdinaryArmor1 = new("Ordinary Armor", Item.Grade.Ordinary, 100, 15);
            Weapon OrdinaryWeapon1 = new("Ordinary Weapon", Item.Grade.Ordinary, 100, 35, 5);

            Armor OrdinaryArmor2 = new("Ordinary Armor", Item.Grade.Ordinary, 100, 15);
            Weapon OrdinaryWeapon2 = new("Ordinary Weapon", Item.Grade.Ordinary, 100, 35, 5);


            Izroth.AddAndEquipItem(OrdinaryArmor1);
            Izroth.AddAndEquipItem(OrdinaryWeapon1);
            
            Lila.AddAndEquipItem(OrdinaryArmor2);
            Lila.AddAndEquipItem(OrdinaryWeapon2);

            game.CombatManager.NewCombat(Izroth, Lila);


            Task.Run(() => GameLoop.Instance.Run());

            while (true)
            {
                Console.WriteLine("*********************");
                Izroth.Print();
                Lila.Print();
                Thread.Sleep(1000); // print every second
            }

        }
    }
}
