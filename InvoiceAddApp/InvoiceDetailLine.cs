using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAddApp
{
    class InvoiceDetailLine
    {
        double lineTotal;
        public double LineTotal
        {
            get { return this.lineTotal; }
        }

        public InvoiceDetailLine(double lineTotal)
        {
            this.lineTotal = lineTotal;
        }
    }
}
