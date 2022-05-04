using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace View
{
    public class TransactionEventArgs : EventArgs
    {
        public TransactionViewModel Transaction { get; set; }

        public TransactionEventArgs(TransactionViewModel t)
        {
            Transaction = t;
        }
    }
}
