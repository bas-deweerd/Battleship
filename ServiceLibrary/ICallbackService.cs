using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary.Models;

namespace ServiceLibrary
{
    public interface ICallbackService
    {
        [OperationContract(IsOneWay = true)]
        void Login(bool correct);

        [OperationContract(IsOneWay = true)]
        void GetAvailableGames(List<Game> games);

        [OperationContract(IsOneWay = true)]
        void GetAllGames(List<Game> games);

        [OperationContract(IsOneWay = true)]
        void StartGame();


    }
}
