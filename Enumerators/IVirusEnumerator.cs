using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public interface IVirusEnumerator
    {
        public abstract IEnumerable GetCollection();
    }
}
