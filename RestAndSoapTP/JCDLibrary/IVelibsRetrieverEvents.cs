using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    public interface IVelibsRetrieverEvents
    {

        [OperationContract(IsOneWay = true)]
        void Retrieved(string res);

        [OperationContract(IsOneWay = true)]
        void RetrieveFinished();

    }
}
