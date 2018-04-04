using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EventsLibrary
{
    [ServiceContract(CallbackContract = typeof(ICalcServiceEvents))]
    public interface ICalcService
    {
        [OperationContract]
        void Calculate(int nOp, double dblNum1, double dblNum2);

        [OperationContract]
        void SubscribeCalculatedEvent();

        [OperationContract]
        void SubscribeCalculationFinishedEvent();
    }
}
