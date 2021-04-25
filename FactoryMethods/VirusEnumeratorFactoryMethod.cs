using System;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators;

namespace Task3.FactoryMethods
{
    public static class VirusEnumeratorFactoryMethod
    {
        public static DatabaseEnumerator GetEnumerator(ExcellDatabase database, DatabaseEnumerator enumerator)
        {
            return new ExcellDatabaseEnumerator(database, enumerator);
        }
        public static DatabaseEnumerator GetEnumerator(SimpleDatabase database, DatabaseEnumerator enumerator)
        {
            return new SimpleDatabaseEnumerator(database, enumerator);
        }
        public static DatabaseEnumerator GetEnumerator(OvercomplicatedDatabase database, DatabaseEnumerator enumerator)
        {
            return new OvercomplicatedDatabaseEnumerator(database, enumerator);
        }
    }
}
