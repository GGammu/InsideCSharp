using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    class Program
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Which form of payment is being used:");
            Console.WriteLine("\t1 = Cash");
            Console.WriteLine("\t2 = Visa");
            Console.WriteLine("\t3 = MasterCard");
            Console.WriteLine("\t4 = American Express");
            Console.WriteLine("====>");
        }

        public static int GetTender()
        {
            int tenderChoice = -1;

            DisplayMenu();

            bool validTender = false;

            while (!validTender)
            {
                string str = Console.ReadLine();
                tenderChoice = Convert.ToInt32(str);

                if (tenderChoice >= 0 && tenderChoice <= 4)
                {
                    validTender = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice - try again");
                }
            }

            return tenderChoice;
        }

        static void Main(string[] args)
        {
            Tenders tenderChoice = (Tenders)GetTender();
            Payment payment = new Payment(tenderChoice);
            payment.ProcessPayment();

            Console.ReadLine();
        }
    }
}
