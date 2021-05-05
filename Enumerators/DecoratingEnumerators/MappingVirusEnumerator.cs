using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.VirusDatabaseEnumerators;

namespace Task3.Enumerators.DecoratingEnumerators
{
    public class MappingVirusEnumerator : DecoratingVirusEnumerator
    {
        private readonly Func<VirusData, VirusData> mappingFunction;
        private readonly IVirusEnumerator baseEnumerator;

        public MappingVirusEnumerator(IVirusEnumerator enumerator, Func<VirusData, VirusData> function) {
            mappingFunction = function;
            baseEnumerator = enumerator;
        }
        public override IEnumerable GetCollection()
        {
            foreach (VirusData virus in baseEnumerator.GetCollection())
                yield return mappingFunction(virus);
        }
    }
}
