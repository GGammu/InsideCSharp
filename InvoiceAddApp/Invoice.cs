using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InvoiceAddApp
{
    class Invoice
    {
        public ArrayList DetailLines;

        static private long nextInvoiceNumber;

        protected long invoiceNumber;
        public long InvoiceNumber
        {
            get { return invoiceNumber; }
        }

        public Invoice()
        {
            invoiceNumber = ++nextInvoiceNumber;
            DetailLines = new ArrayList();
        }

        public void PrintInvoice()
        {
            Console.WriteLine("Invoice Number : {0}", invoiceNumber);
            Console.WriteLine("Line Nbr\tTotal");

            int i = 1;
            double total = 0;
            foreach (InvoiceDetailLine detailLine in DetailLines)
            {
                Console.WriteLine("{0}\t\t{1}", i++, detailLine.LineTotal);
                total += detailLine.LineTotal;
            }

            Console.WriteLine("===\t\t===");
            Console.WriteLine("Total\t\t{1}\n", i++, total);
        }

        public static Invoice operator+ (Invoice invoice1, Invoice invoice2)
        {
            Invoice returnInvoice = new Invoice();

            foreach (InvoiceDetailLine detailLine in invoice1.DetailLines)
            {
                returnInvoice.DetailLines.Add(detailLine);
            }

            foreach (InvoiceDetailLine detailLine in invoice2.DetailLines)
            {
                returnInvoice.DetailLines.Add(detailLine);
            }

            return returnInvoice;
        }
    }
}
