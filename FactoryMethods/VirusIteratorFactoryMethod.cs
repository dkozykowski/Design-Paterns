using System;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators;

namespace Task3.FactoryMethods
{
    public static class VirusIteratorFactoryMethod
    {
        public static VirusDatabaseEnumerator GetEnumerator(ExcellDatabase db)
        {
            return new ExcellDatabaseEnumerator();
        }
        public static VirusDatabaseEnumerator GetEnumerator(SimpleDatabase db)
        {
            return new SimpleDatabaseEnumerator();
        }
        public static VirusDatabaseEnumerator GetEnumerator(OvercomplicatedDatabase db)
        {
            return new OvercomplicatedDatabaseEnumerator();
        }
    }
}
