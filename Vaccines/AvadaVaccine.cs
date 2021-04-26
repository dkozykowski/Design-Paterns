using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class AvadaVaccine : IVaccine
    {
        public string Immunity => "ACTAGAACTAGGAGACCA";

        public double DeathRate => 0.2f;

        private Random randomElement = new Random(0);

        public override string ToString()
        {
            return "AvadaVaccine";
        }

        public void Vaccinate(Dog dog)
        {
            dog.Immunity = Immunity;
        }

        public void Vaccinate(Cat cat)
        {
            if (randomElement.NextDouble() <= DeathRate)
            {
                Console.WriteLine($"Vaccine {this} kills Cat {cat.ID}");
                cat.Alive = false;
            }
            else cat.Immunity = Immunity[3..];
        }

        public void Vaccinate(Pig pig)
        {
            Console.WriteLine($"Vaccine {this} kills Pig {pig.ID}");
            pig.Alive = false;
        }
    }
}
