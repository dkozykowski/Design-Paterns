using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    interface IVaccine
    {
        public string Immunity { get; }
        public double DeathRate { get; }
        abstract public void Vaccinate(Dog dog);
        abstract public void Vaccinate(Cat cat);
        abstract public void Vaccinate(Pig pig);
    }
}
