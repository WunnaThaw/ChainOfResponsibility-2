using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility01
{
    abstract class Approver
    {

        // Event mechanism to know whenever a loan has been applied
        public delegate void OnLoanApplied(Approver approver, Loan loan);
        public event OnLoanApplied onLoanApplied = null;

        // This will invoke events when the loan will be applied
        // i.e. the actual item will be handed over to the hierarchy of
        // concrete handlers.
        public void LoanHandler(Approver approver, Loan loan)
        {
            if (onLoanApplied != null)
            {
                onLoanApplied(this, loan);
            }
        }

        // Sets or gets the next approver
        protected Approver approver;
        public Approver Successor
        {
            get
            {
                return approver;
            }
            set
            {
                approver = value;
            }
        }

        // Using this we can apply for loand
        public void ProcessRequest(Loan loan)
        {
            LoanHandler(this, loan);
        }
    }
}
