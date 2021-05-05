using System;
using System.Collections.Generic;
using System.Text;
using Task3.Subjects;

namespace Task3.Vaccines
{
    class Vaccinator3000 : IVaccine
    {
        public string Immunity => "ACTG";
        public double DeathRate => 0.1f;

        private Random randomElement = new Random(0);
        public override string ToString()
        {
            return "Vaccinator3000";
        }

        public void Vaccinate(Dog dog)
        {
            if (randomElement.NextDouble() <= DeathRate)
            {
                Console.WriteLine($"Vaccine {this} kills Dog with ID = [{dog.ID}]");
                dog.Alive = false;
            }
            else
            {
                char[] tempArray = new char[3000];
                for (int i = 0; i < 3000; i++)
                    tempArray[i] = Immunity[randomElement.Next(0, Immunity.Length)];
                dog.Immunity = new string(tempArray);
            }
        }

        public void Vaccinate(Cat cat)
        {
            if (randomElement.NextDouble() <= DeathRate)
            {
                Console.WriteLine($"Vaccine {this} kills Cat with ID = [{cat.ID}]");
                cat.Alive = false;
            }
            else
            {
                char[] tempArray = new char[300];
                for (int i = 0; i < 300; i++)
                    tempArray[i] = Immunity[randomElement.Next(0, Immunity.Length)];
                cat.Immunity = new string(tempArray);
            }
        }

        public void Vaccinate(Pig pig)
        {
            if (randomElement.NextDouble() <= 3 * DeathRate)
            {
                Console.WriteLine($"Vaccine {this} kills Pig with ID = [{pig.ID}]");
                pig.Alive = false;
            }
            else
            {
                char[] tempArray = new char[15];
                for (int i = 0; i < 15; i++)
                    tempArray[i] = Immunity[randomElement.Next(0, Immunity.Length)];
                pig.Immunity = new string(tempArray);
            }
        }
    }
}
