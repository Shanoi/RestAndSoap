using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JCDLibrary
{
    public interface IVelibsRetriever
    {

        [OperationContract]
        void getCities();

        [OperationContract]
        void getDataFromCity(string city);

    }
}
