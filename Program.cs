using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;
using Task3.FactoryMethods;
using Task3.Enumerators.DecoratingEnumerators;
using Task3.Enumerators.GenomeDatabaseEnumerators;
using Task3.Enumerators.VirusDatabaseEnumerators;
using Task3.Enumerators;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(IVirusEnumerator enumerator)
            {
                foreach (VirusData virus in enumerator.GetCollection())
                    Console.WriteLine(virus);
            }
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"\nTesting {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        subject.GetVaccinated(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    GenomeDatabaseEnumerator genomeEnumerator = GenomeEnumeratorFactoryMethod.GetEnumerator(genomeDatabase);
                    VirusDatabaseEnumerator enumerator = VirusEnumeratorFactoryMethod.GetEnumerator(simpleDatabase, genomeEnumerator);

                    foreach(VirusData virus in enumerator.GetCollection())
                    {
                        foreach (var subject in subjects)
                        {
                            subject.GetTested(virus);
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            var mediaOutlet = new MediaOutlet();

            GenomeDatabaseEnumerator genomeEnumerator = GenomeEnumeratorFactoryMethod.GetEnumerator(genomeDatabase);

            Console.WriteLine("Simple Database-------------------------------------");
            IVirusEnumerator enumerator = VirusEnumeratorFactoryMethod.GetEnumerator(simpleDatabase, genomeEnumerator);
            mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n\nExcell Database-------------------------------------");
            enumerator = VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator);
            mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n\nOvercomplicated Database----------------------------");
            enumerator = VirusEnumeratorFactoryMethod.GetEnumerator(overcomplicatedDatabase, genomeEnumerator);
            mediaOutlet.Publish(enumerator);


            Console.WriteLine("\n\nFilter 1--------------------------------------------");
            enumerator = new FilteringVirusEnumerator(
                VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator), 
                delegate (VirusData virus)
                {
                    return virus.DeathRate > 15;
                }
            );
            mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n\nFilter 2---------------------------------------------");
            enumerator = new MappingVirusEnumerator(
                VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator),
                delegate (VirusData virus)
                {
                    return new VirusData(virus.VirusName, virus.DeathRate + 10, virus.InfectionRate, virus.Genomes);
                }
            );
            enumerator = new FilteringVirusEnumerator(
                enumerator,
                delegate (VirusData virus)
                {
                    return virus.DeathRate > 15;
                }
            );
            mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n\nFileter 3------------------------------------------");
            enumerator = new ConcatenatingVirusEnumerator(
                VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator),
                VirusEnumeratorFactoryMethod.GetEnumerator(overcomplicatedDatabase, genomeEnumerator)
            );
            mediaOutlet.Publish(enumerator);


            // testing animals
            Console.WriteLine("\n\nVaccinating----------------------------------------");
            var tester = new Tester();
            tester.Test();
        }
    }
}
