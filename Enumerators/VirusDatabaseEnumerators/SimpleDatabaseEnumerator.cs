using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.GenomeDatabaseEnumerators;

namespace Task3.Enumerators.VirusDatabaseEnumerators
{
    public class SimpleDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private readonly SimpleDatabase database;
        public SimpleDatabaseEnumerator(SimpleDatabase database, GenomeDatabaseEnumerator enumerator)
        {
            genomeDatabaseEnumerator = enumerator;
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
