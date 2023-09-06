using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleApp_Assignment1
{
    [ServiceContract]
    internal interface Interface {
        //Each of these are service function contracts. They need to be tagged as OperationContracts.
        [OperationContract]
        int GetNumEntries();
        [OperationContract]
        void GetValuesForEntry(int index, out uint acctNo, out uint pin, out int bal, out string fName, out string lName);
    }
}
