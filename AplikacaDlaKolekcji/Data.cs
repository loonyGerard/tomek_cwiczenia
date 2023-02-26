using System;
using System.Runtime.ConstrainedExecution;

namespace AplikacaDlaKolekcji
{
	public class Data
    {
        public List<Human> GetHumansFromFile()
        {
            var fileName = "humans.txt";
            var humans = new List<Human>();
            var lines = File.ReadAllLines(fileName);

            // Mamy juz "lines" ktore sa tablica samochodow ale w formie string czyli dane1;dane2;dane3
            // Musimy wiec wyciagnac te dane i stworzyc klasy Car na ich podstawie
            foreach (var line in lines)
            {
                // sprawdzamy czy linia nie jest pusta
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var data = line.Split(';');
                Console.WriteLine(string.Join(" ", data));

                // sprawdzamy czy w linijce tekstu sa 4 dane, lub wiecej/mniej
                if (data.Length != 4)
                    continue;

                var convertResult = int.TryParse(data[0], out int id);

                // sprawdzamy czy udalo sie przekonwertowac
                if (convertResult == false)
                    continue;

                // sprawdzamy czy id nie jest mniejszy od 1
                if (id < 1)
                    continue;

                var name = data[1];
                var gender = data[2];
                var age = data[3];
                var human = new Human(id, name, gender, age); // nie bardzo wiem jak to naprawić, wiem ze nie kazdy jes stringiem a chciałoby nim być

                humans.Add(human);
            }

            return humans;
        }

        public void SaveCarsToFile(List<Human> humans)
        {
            var fileName = "humans.txt";

            var convertedCars = new List<string>();

            foreach (var human in humans)
            {
                convertedCars.Add(human.ToString());
            }

            // sprawdzamy czy istnieje directory (sciezka) do pliku
            // jesli nie = tworzymy folder 'data'
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            File.WriteAllLines(fileName, convertedCars);
        }
    }
}
