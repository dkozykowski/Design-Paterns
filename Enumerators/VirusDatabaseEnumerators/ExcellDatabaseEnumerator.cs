using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class ExcellDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private ExcellDatabase db;
        public ExcellDatabaseEnumerator(ExcellDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection(GenomeDatabaseEnumerator enumerator)
        {
            string[] names = db.Names.Split(';');
            double[] deathRates = db.DeathRates.Split(';').toDouble();
            double[] infectionRates = db.InfectionRates.Split(';').toDouble();
            Guid[] genomeIds = db.GenomeIds.Split(';').toGuid();

            if (names.Length != deathRates.Length || names.Length != infectionRates.Length ||
                names.Length != genomeIds.Length) throw new ArgumentException();

            for (int i = 0; i < names.Length; i++)
            {
                List<GenomeData> genomeDatas = new List<GenomeData>();
                foreach(GenomeData genome in enumerator.GetCollection())
                {
                    if (genomeIds[i] == genome.Id)
                        genomeDatas.Add(genome);
                }
                yield return new VirusData(names[i], deathRates[i], infectionRates[i], genomeDatas);
            }
        }
    }
}
