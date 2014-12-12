using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedExceptionApp
{
    class MyExceptionClass : Exception
    {
        public MyExceptionClass()
            : base()
        {
            LogException();
        }

        public MyExceptionClass(string message)
            : base(message)
        {
            LogException();
        }

        public MyExceptionClass(string message, Exception innerException)
            : base(message, innerException)
        {
            LogException();
        }

        protected void LogException()
        {
            Console.WriteLine("[MyExceptionClass.LogException] Logging '{0}'",
                this.Message);
        }
    }
}
