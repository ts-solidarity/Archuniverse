namespace Archuniverse
{
    internal class Program
    {
        static void Main()
        {

            Character Izroth = new("Izroth", Character.Sex.Male, 100, 70, 140, 2000, 0, 1);
            Character Lila = new("Lila", Character.Sex.Female, 80, 200, 90, 1500, 0, 1);

            Armor TurtoiseArmor = new("Turtoise Armor", Item.Grade.Rare, 10000, 50);
            Weapon EternalSword = new("Eternal Sword", Item.Grade.Heroic, 50000, 80);

            Izroth.AddItem(TurtoiseArmor);
            Lila.AddItem(EternalSword);

            Izroth.Equip(TurtoiseArmor);
            Lila.Equip(EternalSword);

            Izroth.Unequip(TurtoiseArmor);
            Lila.BuyItem(TurtoiseArmor, 1000, Izroth);

            Lila.Equip(TurtoiseArmor);
            
        }
    }
}
