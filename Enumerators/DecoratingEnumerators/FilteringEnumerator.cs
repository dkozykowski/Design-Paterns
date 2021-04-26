using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators.DecoratingEnumerators
{
    class FilteringEnumerator : DatabaseEnumerator
    {
        private readonly Func<VirusData, bool> filterFunction;
        private readonly DatabaseEnumerator baseEnumerator;

        public FilteringEnumerator(DatabaseEnumerator enumerator, Func<VirusData, bool> function)
        {
            this.filterFunction = function;
            this.baseEnumerator = enumerator;
        }
        public override IEnumerable GetCollection()
        {
            foreach (VirusData virus in baseEnumerator.GetCollection())
            {
                if (filterFunction(virus)) yield return virus;
            }
        }
    }
}
