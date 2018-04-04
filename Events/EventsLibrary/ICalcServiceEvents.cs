using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EventsLibrary
{
    public interface ICalcServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void Calculated(int nOp, double dblNum1, double dblNum2, double dblResult);

        [OperationContract(IsOneWay = true)]
        void CalculationFinished();
    }
}
