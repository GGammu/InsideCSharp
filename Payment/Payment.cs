using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    enum Tenders : int
    {
        Cash = 1,
        Visa,
        MasterCard,
        AmericanExpress
    }

    class Payment
    {
        public Payment(Tenders tender)
        {
            this.tender = tender;
        }

        protected Tenders tender;
        public Tenders Tender {
            get { return this.tender; }
            set { this.tender = value;}
        }

        public void ProcessPayment()
        {
            switch ((int)this.tender)
            {
                case (int)Tenders.Cash:
                    Console.WriteLine("\nCash - Always good");
                    break;
                case (int)Tenders.Visa:
                    Console.WriteLine("\nVisa - Accepted");
                    break;
                case (int)Tenders.MasterCard:
                    Console.WriteLine("\nMasterCard - Accepted");
                    break;
                case (int)Tenders.AmericanExpress:
                    Console.WriteLine("\nAmericanExpress - Accepted");
                    break;
                default:
                    Console.WriteLine("\nSorry - Invalid tender");
                    break;
            }
        }
    }
}
