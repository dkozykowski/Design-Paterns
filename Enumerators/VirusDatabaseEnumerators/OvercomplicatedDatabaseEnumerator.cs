using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class OvercomplicatedDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private OvercomplicatedDatabase db;
        public OvercomplicatedDatabaseEnumerator(OvercomplicatedDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection(GenomeDatabaseEnumerator enumerator)
        {
            throw new NotImplementedException();
        }
    }
}
