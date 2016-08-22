using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [ServiceContract()]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void Say(string user, string message);
    }
}
