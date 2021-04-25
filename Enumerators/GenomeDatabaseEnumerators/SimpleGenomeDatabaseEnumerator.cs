using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class SimpleGenomeDatabaseEnumerator : GenomeDatabaseEnumerator
    {
        private SimpleGenomeDatabase db;
        public SimpleGenomeDatabaseEnumerator(SimpleGenomeDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection()
        {
            foreach(GenomeData genome in db.genomeDatas)
            {
                yield return genome;
            }
        }
    }
}
