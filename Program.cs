using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;
using Task3.Enumerators;
using Task3.FactoryMethods;
using Task3.Enumerators.DecoratingEnumerators;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(DatabaseEnumerator enumerator)
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
                    Console.WriteLine($"Testing {vaccine}");
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
                    DatabaseEnumerator genomeEnumerator = GenomeEnumeratorFactoryMethod.GetEnumerator(genomeDatabase);
                    DatabaseEnumerator enumerator = VirusEnumeratorFactoryMethod.GetEnumerator(simpleDatabase, genomeEnumerator);

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

            DatabaseEnumerator genomeEnumerator = GenomeEnumeratorFactoryMethod.GetEnumerator(genomeDatabase);
            
            //// Uncomment to print All Data
            //DatabaseEnumerator enumerator = new ConcatenatingEnumerator(
            //    VirusEnumeratorFactoryMethod.GetEnumerator(simpleDatabase, genomeEnumerator),
            //    VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator),
            //    VirusEnumeratorFactoryMethod.GetEnumerator(overcomplicatedDatabase, genomeEnumerator)
            //);
            //mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n----------------------------------------------------\n");
            DatabaseEnumerator enumerator = new FilteringEnumerator(
                VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator), 
                delegate (VirusData virus)
                {
                    return virus.DeathRate > 15;
                }
            );
            mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n----------------------------------------------------\n");
            enumerator = new MappingEnumerator(
                VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator),
                delegate (VirusData virus)
                {
                    return new VirusData(virus.VirusName, virus.DeathRate + 10, virus.InfectionRate, virus.Genomes);
                }
            );
            enumerator = new FilteringEnumerator(
                enumerator,
                delegate (VirusData virus)
                {
                    return virus.DeathRate > 15;
                }
            );
            mediaOutlet.Publish(enumerator);

            Console.WriteLine("\n----------------------------------------------------\n");
            enumerator = new ConcatenatingEnumerator(
                VirusEnumeratorFactoryMethod.GetEnumerator(excellDatabase, genomeEnumerator),
                VirusEnumeratorFactoryMethod.GetEnumerator(overcomplicatedDatabase, genomeEnumerator)
            );
            mediaOutlet.Publish(enumerator);


            // testing animals
            Console.WriteLine("\n----------------------------------------------------\n");
            var tester = new Tester();
            tester.Test();
        }
    }
}
