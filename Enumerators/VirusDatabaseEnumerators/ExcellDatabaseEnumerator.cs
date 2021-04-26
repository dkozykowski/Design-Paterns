using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class ExcellDatabaseEnumerator : DatabaseEnumerator
    {
        private readonly ExcellDatabase database;
        private readonly DatabaseEnumerator genomeDatabaseEnumerator;
        public ExcellDatabaseEnumerator(ExcellDatabase database, DatabaseEnumerator enumerator)
        {
            this.genomeDatabaseEnumerator = enumerator;
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
