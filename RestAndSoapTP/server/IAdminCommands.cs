using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    [ServiceContract]
    public interface IAdminCommands
    {

        [OperationContract]
        string updateCacheDurationCitites(int duration);

        [OperationContract]
        string updateCacheDurationStations(int duration);

    }
}
