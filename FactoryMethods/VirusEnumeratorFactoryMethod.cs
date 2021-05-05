using System;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators.VirusDatabaseEnumerators;
using Task3.Enumerators.GenomeDatabaseEnumerators;

namespace Task3.FactoryMethods
{
    public static class VirusEnumeratorFactoryMethod
    {
        public static VirusDatabaseEnumerator GetEnumerator(ExcellDatabase database, GenomeDatabaseEnumerator enumerator)
        {
            return new ExcellDatabaseEnumerator(database, enumerator);
        }
        public static VirusDatabaseEnumerator GetEnumerator(SimpleDatabase database, GenomeDatabaseEnumerator enumerator)
        {
            return new SimpleDatabaseEnumerator(database, enumerator);
        }
        public static VirusDatabaseEnumerator GetEnumerator(OvercomplicatedDatabase database, GenomeDatabaseEnumerator enumerator)
        {
            return new OvercomplicatedDatabaseEnumerator(database, enumerator);
        }
    }
}
