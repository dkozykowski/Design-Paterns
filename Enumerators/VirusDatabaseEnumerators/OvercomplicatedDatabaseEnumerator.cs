using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class OvercomplicatedDatabaseEnumerator : DatabaseEnumerator
    {
        private readonly OvercomplicatedDatabase database;
        private readonly DatabaseEnumerator genomeDatabaseEnumerator;
        public OvercomplicatedDatabaseEnumerator(OvercomplicatedDatabase database, DatabaseEnumerator enumerator)
        {
            this.genomeDatabaseEnumerator = enumerator;
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
