using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models;
using ServiceLibrary;

namespace Client.Models
{
    public class CallbackService : ICallbackService
    {
        public bool Authenticated { get; internal set; }

        public List<Game> Games { get; internal set; }

        public bool GameStarted { get; internal set; }

        public void GetAvailableGames(List<Game> games)
        {
            this.Games = games;
        }

        public void GetAllGames(List<Game> games)
        {
            this.Games = games;
        }

        public void Login(bool correct)
        {
            this.Authenticated = correct;
        }

        public void StartGame()
        {
            GameStarted = true;
        }
    }
}
