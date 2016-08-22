namespace Client.Models
{
    public class Battleship : Ship
    {
        public Battleship(int id) : base(id) {
            Length = 5;
        }

        public override string ToString() {
            return "Battleship";
        }
    }
}
