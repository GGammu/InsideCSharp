using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvents
{
    class InventoryChangeEventArgs : EventArgs
    {
        public InventoryChangeEventArgs(string sku, int change)
        {
            this.sku = sku;
            this.change = change;
        }

        string sku;
        public string Sku
        {
            get { return sku; }
        }

        int change;
        public int Change
        {
            get { return change; }
        }
    }

    class InventoryManager
    {
        public delegate void InventoryChangeEventHandler(
            object source, InventoryChangeEventArgs e);

        public event InventoryChangeEventHandler OnInventoryChageHandler;

        public void UpdateInventory(string sku, int change)
        {
            if (0 == change)
            {
                return;
            }

            InventoryChangeEventArgs e = new InventoryChangeEventArgs(sku, change);

            if (OnInventoryChageHandler != null)
            {
                Console.WriteLine("[InventoryManager.UpdateInventory] " +
                    "Rasing event to all subscribers...\n");
                OnInventoryChageHandler(this, e);
            }
        }
    }

    class InventoryWatcher
    {
        InventoryManager inventoryManager;

        public InventoryWatcher(InventoryManager inventoryManager)
        {
            Console.WriteLine("[InventoryWatcher.InventoryManager] " +
                "Subscribing to InventoryChange event\n");
            this.inventoryManager = inventoryManager;
            inventoryManager.OnInventoryChageHandler +=
                new InventoryManager.InventoryChangeEventHandler(OnInventoryChange);
        }

        void OnInventoryChange(object source, InventoryChangeEventArgs e)
        {
            int change = e.Change;
            Console.WriteLine("[InventoryManager.OnInventoryChange]" +
                "\n\tPart '{0}' was {1} by {2} units\n", e.Sku,
                change > 0 ? "increased" : "decreased", Math.Abs(e.Change));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();

            Console.WriteLine("[DelegateEvents.Main] Instantiating subscriber object\n");

            InventoryWatcher inventoryWatch = new InventoryWatcher(inventoryManager);

            inventoryManager.UpdateInventory("111 006 116", -2);

            inventoryManager.UpdateInventory("111 005 383", 5);

            Console.ReadLine();
        }
    }
}
