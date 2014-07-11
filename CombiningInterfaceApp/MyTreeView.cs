using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombiningInterfaceApp
{
    class MyTreeView: Control, ICombo
    {
        public void Drag()
        {
            Console.WriteLine("MyTreeView.Drag called");
        }

        public void Drop()
        {
            Console.WriteLine("MyTreeView.Drop called");
        }

        public void Serialize()
        {
            Console.WriteLine("MyTreeView.Serialize called");
        }
    }
}
