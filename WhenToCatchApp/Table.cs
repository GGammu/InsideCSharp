using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenToCatchApp
{
    class Table
    {
        public void AddRecord(string record)
        {
            try
            {
                Commit();

                AddRow();

                UpdateRow();

                Commit();
            }
            catch (Exception e)
            {
                Rollback();

                throw e;
            }
        }

        public void Commit()
        {
            Console.WriteLine("[Table.Commit] Commiting " +
                "changes to database");
        }

        public void Rollback()
        {
            Console.WriteLine("[Table.Rollback] Roll back " +
                "uncommitted changes to database");
        }

        public void AddRow()
        {
            Console.WriteLine("[Table.AddRow] Adding blank " +
                "row to database");
        }

        protected void UpdateRow()
        {
            Console.WriteLine("[Table.UpdateRow] Row" +
                "being updated...");

            Console.WriteLine("[Table.UpdateRow] Error" +
                "encounterd. Throwing exception...");

            throw new Exception("Data values do not math " +
                "columns. Update failed");
        }
    }
}
