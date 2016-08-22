namespace Client.Models
{
    public class Turn
    {
        private int _activeplayer=0;
        private Player[] _players = new Player[2];
        public GameModel Model;
 
        public Turn(Player one, Player two) {
            _players[0] = one;
            _players[1] = two;
        }

        public void SwitchTurn()
        {
            _activeplayer = (_activeplayer + 1) % 2;
            _players[_activeplayer].Notify();
            if (_players[0].AllShipsSunk() || _players[1].AllShipsSunk())
            {
                Model.NextPhase();
            }
        }

        public Player GetActivePlayer()
        {
            return _players[_activeplayer];
        }

    }
}
