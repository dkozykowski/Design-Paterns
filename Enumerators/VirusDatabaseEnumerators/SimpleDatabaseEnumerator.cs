using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class SimpleDatabaseEnumerator : DatabaseEnumerator
    {
        private readonly SimpleDatabase database;
        private readonly DatabaseEnumerator genomeDatabaseEnumerator;
        public SimpleDatabaseEnumerator(SimpleDatabase database, DatabaseEnumerator enumerator)
        {
            this.genomeDatabaseEnumerator = enumerator;
            this.database = database;
        }
        public override IEnumerable GetCollection()
        {
            foreach(SimpleDatabaseRow sdr in database.Rows)
            {
                List<GenomeData> genomeDatas = new List<GenomeData>();
                foreach (GenomeData genome in genomeDatabaseEnumerator.GetCollection())
                {
                    if (sdr.GenomeId == genome.Id)
                        genomeDatas.Add(genome);
                }
                yield return new VirusData(sdr.VirusName, sdr.DeathRate, sdr.InfectionRate, genomeDatas);
            }
        }
    }
}
