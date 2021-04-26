using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators.DecoratingEnumerators
{
    public class ConcatenatingEnumerator : DatabaseEnumerator
    {
        private readonly DatabaseEnumerator[] enumerators;
        public ConcatenatingEnumerator(params DatabaseEnumerator[] enumerators)
        {
            this.enumerators = enumerators;
        }
        public override IEnumerable GetCollection()
        {
            foreach(DatabaseEnumerator enumerator in enumerators)
            {
                foreach (VirusData virus in enumerator.GetCollection())
                    yield return virus;
            }    
        }
    }
}
