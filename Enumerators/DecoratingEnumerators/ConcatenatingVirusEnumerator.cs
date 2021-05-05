using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.VirusDatabaseEnumerators;

namespace Task3.Enumerators.DecoratingEnumerators
{
    public class ConcatenatingVirusEnumerator : DecoratingVirusEnumerator
    {
        private readonly IVirusEnumerator[] enumerators;
        public ConcatenatingVirusEnumerator(params IVirusEnumerator[] enumerators)
        {
            this.enumerators = (IVirusEnumerator[])enumerators.Clone();
        }
        public override IEnumerable GetCollection()
        {
            foreach(IVirusEnumerator enumerator in enumerators)
            {
                foreach (VirusData virus in enumerator.GetCollection())
                    yield return virus;
            }    
        }
    }
}
