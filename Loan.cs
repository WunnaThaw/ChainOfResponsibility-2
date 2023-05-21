using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility01
{
    /// <summary>
    /// Class that holds request details
    /// </summary>
    class Loan
    {
        public double Amount { get; set; }
        public string Purpose { get; set; }
        public int Number { get; set; }
    }
}
