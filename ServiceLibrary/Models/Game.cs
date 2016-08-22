using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary.Models
{
    [DataContract, Serializable]
    public class Game
    {
        [DataMember]
        private static int _created = 0;
        [DataMember]
        public int Id;
        [DataMember]
        private string _playerOne;
        [DataMember]
        private string _playerTwo;

        public Game(string username)
        {
            this._playerOne = username;
            Id = _created;
            _created++;
        }

        public void AddPlayerToGame(string username)
        {
            if (_playerTwo == null)
            {
                _playerTwo = username;
            }
        }

        public string PlayerOne
        {
            get { return _playerOne; }
            set { _playerOne = value; }
        }

        public string PlayerTwo
        {
            get { return _playerTwo; }
            set { _playerTwo = value; }
        }

        public override string ToString()
        {
            return "Game id = " + Id + "\t Player one: " + _playerOne + "\t Player two: " + _playerTwo;
        }
    }
}
