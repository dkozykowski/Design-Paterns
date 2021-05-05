using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.GenomeDatabaseEnumerators;

namespace Task3.Enumerators.VirusDatabaseEnumerators
{
    public abstract class VirusDatabaseEnumerator : IVirusEnumerator
    {
        protected GenomeDatabaseEnumerator genomeDatabaseEnumerator;
        abstract public IEnumerable GetCollection();
    }
}
