using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class ReverseVaccine : IVaccine
    {
        public string Immunity => "ACTGAGACAT";

        public double DeathRate => 0.05f;

        private Random randomElement = new Random(0);

        private int vaccinationNumber = 0;
        public override string ToString()
        {
            return "ReverseVaccine";
        }

        public void Vaccinate(Dog dog)
        {
            dog.Immunity = Immunity.Reverse();
            vaccinationNumber++;
        }

        public void Vaccinate(Cat cat)
        {
            Console.WriteLine($"Vaccine {this} kills Cat {cat.ID}");
            cat.Alive = false;
            vaccinationNumber++;
        }

        public void Vaccinate(Pig pig)
        {
            
            if (randomElement.NextDouble() <= DeathRate * vaccinationNumber)
            {
                Console.WriteLine($"Vaccine {this} kills Pig {pig.ID}");
                pig.Alive = false;
            }
            else pig.Immunity = pig.Immunity + pig.Immunity.Reverse();

            vaccinationNumber++;
        }
    }
}
