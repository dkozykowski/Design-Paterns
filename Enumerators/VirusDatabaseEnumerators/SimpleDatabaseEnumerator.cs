using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class SimpleDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private SimpleDatabase db;
        public SimpleDatabaseEnumerator(SimpleDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection(GenomeDatabaseEnumerator enumerator)
        {
            throw new NotImplementedException();
        }
    }
}
