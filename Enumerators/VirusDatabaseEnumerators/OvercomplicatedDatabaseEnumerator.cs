using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Enumerators
{
    public class OvercomplicatedDatabaseEnumerator : VirusDatabaseEnumerator
    {
        private OvercomplicatedDatabase db;
        public OvercomplicatedDatabaseEnumerator(OvercomplicatedDatabase db)
        {
            this.db = db;
        }
        public override IEnumerable GetCollection(GenomeDatabaseEnumerator enumerator)
        {
            Queue<INode> queue = new Queue<INode>();
            queue.Enqueue(db.Root);

            while(queue.Count > 0)
            {
                INode node = queue.Dequeue();
                foreach(INode child in node.Children)
                    queue.Enqueue(child);

                List<GenomeData> genomeDatas = new List<GenomeData>();
                foreach(GenomeData genome in enumerator.GetCollection())
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
