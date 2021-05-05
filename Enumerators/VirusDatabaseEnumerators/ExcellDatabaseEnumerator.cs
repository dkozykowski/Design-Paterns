using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.GenomeDatabaseEnumerators;

namespace Task3.Enumerators.VirusDatabaseEnumerators
{
    public class ExcellDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private readonly ExcellDatabase database;
        public ExcellDatabaseEnumerator(ExcellDatabase database, GenomeDatabaseEnumerator enumerator)
        {
            genomeDatabaseEnumerator = enumerator;
            this.database = database;
        }
        public override IEnumerable GetCollection()
        {
            string[] names = database.Names.Split(';');
            double[] deathRates = database.DeathRates.Split(';').ToDouble();
            double[] infectionRates = database.InfectionRates.Split(';').ToDouble();
            Guid[] genomeIds = database.GenomeIds.Split(';').ToGuid();

            if (names.Length != deathRates.Length || names.Length != infectionRates.Length ||
                names.Length != genomeIds.Length) throw new ArgumentException();

            for (int i = 0; i < names.Length; i++)
            {
                List<GenomeData> genomeDatas = new List<GenomeData>();
                foreach(GenomeData genome in genomeDatabaseEnumerator.GetCollection())
                {
                    if (genomeIds[i] == genome.Id)
                        genomeDatas.Add(genome);
                }
                yield return new VirusData(names[i], deathRates[i], infectionRates[i], genomeDatas);
            }
        }
    }
}
