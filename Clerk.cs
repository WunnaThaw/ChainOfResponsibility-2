using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility01
{
    class Clerk : Approver
    {
        // Clerk can only approve up to $100
        const int MAX_LOAN_CAN_APPROVE = 100;

        public Clerk()
        {
            this.onLoanApplied += Clerk_onLoanApplied;
        }

        void Clerk_onLoanApplied(Approver approver, Loan loan)
        {
            // check if we can process this request
            if (loan.Amount < MAX_LOAN_CAN_APPROVE)
            {
                // process it on our level only
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, loan.Number);
            }
            else
            {
                // if we cant process pass on to the supervisor 
                // so that he can process
                if (Successor != null)
                {
                    Successor.LoanHandler(this, loan);
                }
            }
        }
    }
}
