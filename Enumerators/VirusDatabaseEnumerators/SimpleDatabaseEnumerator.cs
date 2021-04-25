using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class SimpleDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private SimpleDatabase db;
        public SimpleDatabaseEnumerator(SimpleDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection(GenomeDatabaseEnumerator enumerator)
        {
            foreach(SimpleDatabaseRow sdr in db.Rows)
            {
                List<GenomeData> genomeDatas = new List<GenomeData>();
                foreach (GenomeData genome in enumerator.GetCollection())
                {
                    if (sdr.GenomeId == genome.Id)
                        genomeDatas.Add(genome);
                }
                yield return new VirusData(sdr.VirusName, sdr.DeathRate, sdr.InfectionRate, genomeDatas);
            }
        }
    }
}
