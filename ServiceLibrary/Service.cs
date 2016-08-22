using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ServiceLibrary.Models;

namespace ServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private ICallbackService callback {
            get { return OperationContext.Current.GetCallbackChannel<ICallbackService>(); }
        }


        private List<Game> _games = new List<Game>(10);

        public void Login(string username, string password)
        {
            bool correct = UserAdapter.CredentialsCorrect(username, password);
            if (correct)
            {
                callback.Login(true);
            }
            else
            {
                callback.Login(false);
            }
        }

        public void Register(string username, string password)
        {
            UserAdapter.Register(username, password);
        }

        public void GetAvailableGames()
        {
            List<Game> availableGames = new List<Game>(10);
            availableGames.AddRange(_games.Where(VARIABLE => VARIABLE.PlayerTwo == null));
            callback.GetAvailableGames(availableGames);
        }

        public void GetAllGames()
        {
            List<Game> allGames = new List<Game>(10);
            allGames.AddRange(_games);
            callback.GetAllGames(allGames);
        }

        public void JoinGame(int id, string username)
        {
            List<Game> availableGames = new List<Game>(10);
            availableGames.AddRange(_games.Where(VARIABLE => VARIABLE.PlayerTwo == null));

            foreach (var VARIABLE in availableGames)
            {
                if (VARIABLE.Id == id)
                {
                    VARIABLE.AddPlayerToGame(username);
                }
            }
        }

        public void LeaveGame(int id, string username)
        {
            throw new NotImplementedException();
        }

        public void CreateNewGame(string username)
        {
            _games.Add(new Game(username));
        }
    }
}
