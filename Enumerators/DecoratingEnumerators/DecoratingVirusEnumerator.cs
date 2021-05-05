using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators.DecoratingEnumerators
{
    public abstract class DecoratingVirusEnumerator : IVirusEnumerator
    {
        public abstract IEnumerable GetCollection();
    }
}
