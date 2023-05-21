using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility01
{
    class Manager : Approver
    {
        // Manager can only approve up to $1000
        const int MAX_LOAN_CAN_APPROVE = 1000;

        // in constructor we will attach the event handler that
        // will check if this approver can process or he need to
        // pass on to next approver
        public Manager()
        {
            //this.onLoanApplied += new OnLoanApplied(Manager_onLoanApplied);
            this.onLoanApplied += Manager_onLoanApplied;
        }

        void Manager_onLoanApplied(Approver approver, Loan loan)
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
