using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators.DecoratingEnumerators
{
    public class MappingEnumerator : DatabaseEnumerator
    {
        private readonly Func<VirusData, VirusData> mappingFunction;
        private readonly DatabaseEnumerator baseEnumerator;

        public MappingEnumerator(DatabaseEnumerator enumerator, Func<VirusData, VirusData> function) {
            this.mappingFunction = function;
            this.baseEnumerator = enumerator;
        }
        public override IEnumerable GetCollection()
        {
            foreach (VirusData virus in baseEnumerator.GetCollection())
                yield return mappingFunction(virus);
        }
    }
}
