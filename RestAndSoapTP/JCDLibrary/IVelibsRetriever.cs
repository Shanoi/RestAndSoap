using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    [ServiceContract]
    public interface IVelibsRetriever
    {

        [OperationContract]
        List<string> getCities();

        [OperationContract]
        string getDataFromCity(string city, string station, string fidelity);

        [OperationContract]
        Task<List<Station>> getListStationFromCity(string city, string station, string fidelity);

        [OperationContract]
        List<string> getFidelityLevels();

        [OperationContract]
        DateTime getLastUpdate();
    }
}
