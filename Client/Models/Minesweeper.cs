namespace Client.Models
{
    public class Minesweeper : Ship
    {
        public Minesweeper(int id) : base(id)
        {
            this.Length = 2;
        }

        public override string ToString()
        {
            return "Minesweeper";
        }
    }
}
