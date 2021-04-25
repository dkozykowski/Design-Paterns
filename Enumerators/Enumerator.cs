using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public abstract class DatabaseEnumerator
    {
        public abstract IEnumerable GetCollection();
    }
}
