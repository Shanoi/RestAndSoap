using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    [ServiceContract]
    [ServiceKnownType(typeof(Station))]
    public interface IVelibsRetriever
    {

        [OperationContract]
        List<string> getCities();

        [OperationContract]
        string getDataFromCityString(string city, string station);

        [OperationContract]
        ArrayList getDataFromCityStation(string city, string station);

        [OperationContract]
        Task<string> getDataFromCityAsync(string city, string station);



    }
}
