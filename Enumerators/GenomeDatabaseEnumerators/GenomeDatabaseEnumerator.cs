using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators.GenomeDatabaseEnumerators
{
    public abstract class GenomeDatabaseEnumerator
    {
        abstract public IEnumerable GetCollection();
    }
}
