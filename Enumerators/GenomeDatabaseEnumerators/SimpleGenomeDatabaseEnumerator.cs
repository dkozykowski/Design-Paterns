using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators.GenomeDatabaseEnumerators
{
    public class SimpleGenomeDatabaseEnumerator : GenomeDatabaseEnumerator
    {
        private readonly SimpleGenomeDatabase database;
        public SimpleGenomeDatabaseEnumerator(SimpleGenomeDatabase database)
        {
            this.database = database;
        }
        public override IEnumerable GetCollection()
        {
            foreach(GenomeData genome in database.genomeDatas)
            {
                yield return genome;
            }
        }
    }
}
