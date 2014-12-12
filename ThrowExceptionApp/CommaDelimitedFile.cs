using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionApp
{
    class CommaDelimitedFile
    {
        protected string fileName;

        public void Open(string fileName)
        {
            this.fileName = fileName;

            throw new Exception("[CommaDelimitedFile.Open] Open failed");
        }

        public bool Read(string record)
        {
            return false;
        }
    }
}
