namespace Client.Models
{
    public class Cruiser : Ship
    {
        public Cruiser(int id) : base(id)
        {
            this.Length = 4;
        }

        public override string ToString()
        {
            return "Cruiser";
        }
    }
}
