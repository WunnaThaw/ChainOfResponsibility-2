using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility01
{
    class AssistantManager : Approver
    {
        // Assistant Manager can only approve up to $500
        const int MAX_LOAN_CAN_APPROVE = 500;

        public AssistantManager()
        {
            this.onLoanApplied += AssistantManager_onLoanApplied;
        }

        void AssistantManager_onLoanApplied(Approver approver, Loan loan)
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
