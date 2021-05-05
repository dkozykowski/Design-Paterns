using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.GenomeDatabaseEnumerators;

namespace Task3.Enumerators.VirusDatabaseEnumerators
{
    public class OvercomplicatedDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private readonly OvercomplicatedDatabase database;
        public OvercomplicatedDatabaseEnumerator(OvercomplicatedDatabase database, GenomeDatabaseEnumerator enumerator)
        {
            genomeDatabaseEnumerator = enumerator;
            this.database = database;
        }
        public override IEnumerable GetCollection()
        {
            Queue<INode> queue = new Queue<INode>();
            queue.Enqueue(database.Root);

            while(queue.Count > 0)
            {
                INode node = queue.Dequeue();
                foreach(INode child in node.Children)
                    queue.Enqueue(child);

                List<GenomeData> genomeDatas = new List<GenomeData>();
                foreach(GenomeData genome in genomeDatabaseEnumerator.GetCollection())
                {
                    foreach(string tag in genome.Tags)
                    {
                        if (node.GenomeTag == tag)
                        {
                            genomeDatas.Add(genome);
                            break;
                        }
                    }
                }
                yield return new VirusData(node.VirusName, node.DeathRate, node.InfectionRate, genomeDatas);
            }
        }
    }
}
