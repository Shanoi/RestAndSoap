using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class VelibsServiceCallbackSink : JCDLibrary.IVelibsRetrieverCallback
    {
        public void Retrieved(string res)
        {
            Console.WriteLine(res);
        }

        public void RetrieveFinished()
        {
            Console.WriteLine("Retrieved Complete");
        }
        

    }
}
