﻿using System;
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
        string getCities();

        [OperationContract]
        string getDataFromCity(string city, string station);

    }
}
