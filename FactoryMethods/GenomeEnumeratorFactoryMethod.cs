﻿using System;
using System.Collections.Generic;
using System.Text;
using Task3.Enumerators;

namespace Task3.FactoryMethods
{
    public static class GenomeEnumeratorFactoryMethod
    {
        public static GenomeDatabaseEnumerator GetEnumerator(SimpleGenomeDatabase db)
        {
            return new SimpleGenomeDatabaseEnumerator(db);
        }
    }
}