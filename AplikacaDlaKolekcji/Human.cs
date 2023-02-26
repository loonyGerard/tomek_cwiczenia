using System;
namespace AplikacaDlaKolekcji
{
	public class Human  // u ciebie było internal class, dla czego?
	{
		public int Id { get; set; }  // dlaczego nazwy z wielkiej litery?
		public string Name { get; set; }
		public char Gender { get; set; }
		public int Age { get; set; }

		public Human()
		{
		}

        public Human(int id, string name, char gender, int age)
        {
			Id = id;
			Name = name;
			Gender = gender;
			Age = age;
        }

        public override string ToString()
        {
			return $"{Id};{Name};{Gender};{Age}";

		}

    }
}

