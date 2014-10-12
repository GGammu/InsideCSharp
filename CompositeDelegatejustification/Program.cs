using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CompositeDelegatejustification
{
    class Part
    {
        protected string sku;
        public string Sku
        {
            get { return this.sku; }
            set { this.sku = value; }
        }

        protected int onHand;
        public int OnHand
        {
            get { return this.onHand; }
            set { this.onHand = value; }
        }

        public Part(string sku)
        {
            this.Sku = sku;

            Random r = new Random(DateTime.Now.Millisecond);
            double d = r.NextDouble() * 100;
            this.OnHand = (int)d;
        }
    }

    class InventoryManager
    {
        protected const int MIN_ONHAND = 50;

        public Part[] parts;

        public InventoryManager()
        {
            Console.WriteLine("[InventoryManager.InventoryManager]" +
                " Adding parts..");

            parts = new Part[5];

            for (int i = 0; i < 5; i++)
            {
                Part part = new Part("Part " + (i + 1));

                Thread.Sleep(10);

                parts[i] = part;

                Console.WriteLine("\tPart '{0}' on-hand = {1}", part.Sku, part.OnHand);
            }
        }

        public delegate void OutOfStockExceptionMethod(Part part);
        public void ProcessInventory(OutOfStockExceptionMethod exception)
        {
            Console.WriteLine("\n[InventoryManager.ProcessInventory]" +
                " Processing inventory...");

            foreach (Part part in parts)
            {
                if (part.OnHand < MIN_ONHAND)
                {
                    Console.WriteLine("\n\t{0} ({1} units) is " +
                        "below minimum on-hand {2}",
                        part.Sku, part.OnHand, MIN_ONHAND);

                    exception(part);
                }
            }
        }
    }

    class Program
    {
        public static void LogEvent(Part part)
        {
            Console.WriteLine("\t[CompositeDelegate.LogEvent] " + "logging event...");
        }

        public static void EmailPurchasingMgr(Part part)
        {
            Console.WriteLine("\t[CompositeDelegate.EmailPurchasingMgr]" +
                " emailing Purchasing manager...");
        }

        public static void EmailStoreMgr(Part part)
        {
            Console.WriteLine("\t[CompositeDelegate.EmailStoreMgr]" +
                " emailing Store manager...");
        }

        static void Main(string[] args)
        {
            InventoryManager mgr = new InventoryManager();

            InventoryManager.OutOfStockExceptionMethod[] exceptionMethods =
                new InventoryManager.OutOfStockExceptionMethod[3];

            exceptionMethods[0] = new InventoryManager.OutOfStockExceptionMethod(LogEvent);
            exceptionMethods[1] = new InventoryManager.OutOfStockExceptionMethod(EmailPurchasingMgr);
            exceptionMethods[2] = new InventoryManager.OutOfStockExceptionMethod(EmailStoreMgr);

            int location = 2;

            InventoryManager.OutOfStockExceptionMethod compositeDeleagete;

            if (location == 2)
            {
                compositeDeleagete = exceptionMethods[0] + exceptionMethods[1];
            }
            else
            {
                compositeDeleagete = exceptionMethods[0] + exceptionMethods[2];
            }

            mgr.ProcessInventory(compositeDeleagete);

            Console.ReadLine();
        }
    }
}
