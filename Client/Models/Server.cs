using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

namespace Client.Models
{
    public class Server:IService
    {
        private IService service;

        public Server(InstanceContext context)
        {
            DuplexChannelFactory<IService> channel = new DuplexChannelFactory<IService>(context, "client_endpoint");
            service = channel.CreateChannel();
        }

        public void Login(string username, string password)
        {
            service.Login(username,password);
        }

        public void Register(string username, string password)
        {
            service.Register(username,password);
        }

        public void GetAvailableGames()
        {
            service.GetAvailableGames();
        }
    
        public void GetAllGames()
        {
            service.GetAllGames();
        }

        public void JoinGame(int id, string username)
        {
            service.JoinGame(id, username);
        }

        public void LeaveGame(int id, string username)
        {
            service.LeaveGame(id,username);
        }

        public void CreateNewGame(string username)
        {
            service.CreateNewGame(username);
        }
    }
}
