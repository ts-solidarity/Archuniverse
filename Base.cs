namespace Archuniverse
{
    public class Base
    {
        public Guid UniqueId {  get; private set; }

        public Base()
        {
            UniqueId = Guid.NewGuid();
        }
    }
}
