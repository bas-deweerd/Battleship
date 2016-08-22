using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using ServiceLibrary.Models;

namespace ServiceLibrary
{
    [ServiceContract(SessionMode = SessionMode.Allowed, CallbackContract = typeof(ICallbackService))]
    public interface IService
    {
        [OperationContract(IsOneWay=true)]
        void Login(string username, string password);

        [OperationContract(IsOneWay = true)]
        void Register(string username, string password);

        [OperationContract(IsOneWay = true)]
        void GetAvailableGames();

        [OperationContract(IsOneWay = true)]
        void GetAllGames();

        [OperationContract(IsOneWay = true)]
        void JoinGame(int id, string username);

        [OperationContract(IsOneWay = true)]
        void LeaveGame(int id, string username);

        [OperationContract(IsOneWay = true)]
        void CreateNewGame(string username);
    }
}
