using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.VirusDatabaseEnumerators;

namespace Task3.Enumerators.DecoratingEnumerators
{
    class FilteringVirusEnumerator : DecoratingVirusEnumerator
    {
        private readonly Func<VirusData, bool> filterFunction;
        private readonly IVirusEnumerator baseEnumerator;

        public FilteringVirusEnumerator(IVirusEnumerator enumerator, Func<VirusData, bool> function)
        {
            filterFunction = function;
            baseEnumerator = enumerator;
        }
        override public IEnumerable GetCollection()
        {
            foreach (VirusData virus in baseEnumerator.GetCollection())
            {
                if (filterFunction(virus)) yield return virus;
            }
        }
    }
}
