using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class ExcellDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private ExcellDatabase db;
        public ExcellDatabaseEnumerator(ExcellDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection(GenomeDatabaseEnumerator enumerator)
        {
            throw new NotImplementedException();
        }
    }
}
