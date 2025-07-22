namespace Archuniverse
{
    public class Ware : Item
    {
        public Ware(string name, Grade grade, int worth) 
            : base(name, Type.Ware, grade, worth)
        {
            
        }
    }
}
