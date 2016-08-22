namespace Client.Models
{
    class PoorManShip:Ship
    {
        public PoorManShip(int id) : base(id)
        {
            this.Length = 1;
        }
    }
}
