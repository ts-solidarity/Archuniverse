namespace Archuniverse
{
    public class Food : Item
    {
        public Food(string name, Grade grade, int worth, int healthBoost) 
            : base(name, Type.Food, grade, worth)
        {
            HealthBoost = healthBoost;
        }

        public int HealthBoost { get; set; }

        public override void Use()
        {
            if (Owner?.Inventory.Contains(this) == true)
            {
                Owner.Health += HealthBoost;
                Owner.Inventory.Remove(this);
            }
        }

    }
}
