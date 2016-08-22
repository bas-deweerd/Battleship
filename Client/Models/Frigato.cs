namespace Client.Models
{
    public class Frigato : Ship
    {
        public Frigato(int id) : base(id)
        {
            this.Length = 3;
        }

        public override string ToString()
        {
            return "Frigato";
        }
    }
}
