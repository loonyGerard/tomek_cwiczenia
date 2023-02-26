using System;
using System.Runtime.ConstrainedExecution;

namespace AplikacaDlaKolekcji
{
    public class HumanOptions
    {

        // metody do wyboru użytkownika

        public void Add()
        {
            var succes = false;
            var newHuman = new Human();

            while (!succes)
            {
                Console.WriteLine("Provide a NAME");

                var providedName = Console.ReadLine();
                newHuman.Id = BiggestId() + 1;

                try
                {
                    Validate(providedName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // gdzie to jest ex.Message??
                    continue;
                }
                Console.WriteLine("Provide a GENDER -> M-Male,F-Female,O-Other");

                var providedGender = Console.ReadLine().ToUpper();


                while (!providedGender.Equals('M') || !providedGender.Equals('F') || !providedGender.Equals('O'))
                { Console.WriteLine("Wrong gender type, try again with M,F or O");
                    providedGender = Console.ReadLine().ToUpper();
                }

                try //to juz chyba tu nie bedzie potrzebne jak wyzej był while?
                {
                    Validate(providedGender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                Console.WriteLine("Provide a AGE");

                var providedAge = Console.ReadLine();

                try
                {
                    Validate(providedAge);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

        }

        public void Show()
        {
            Console.WriteLine("Humans list:");
            foreach (var human in Humans)
            {
                Console.WriteLine(human.ToString());
            }
        }

        public void Delete()
        {
            var success = false;

            while (!success)
            {
                Console.WriteLine("Provide an ID of the student that you want to remove:");

                var providedValue = Console.ReadLine();

                try
                {
                    Validate(providedValue);

                    var humanId = int.Parse(providedValue);

                    // Posiadajac carId musze znalezc w mojej liscie odpowiedni Car
                    // zapisac sobie referencje do tego Car w np. nowe zmiennej 'carToRemove'
                    // I na koniec przekazac ta refenrecje do wbudowane metody Remove() z klasy List<T>

                    var humanToRemove = Humans.Find(x => x.Id == humanId);

                    // Moze byc sytuacja ze w liscie samochodow nie ma tego co szukam wiec carToRemove bedzie null
                    // (bo Find zwraca null jesli nie znajdzie)
                    // Robie wiec warunek sprawdzajacy czy carToRemove jest null i jesli tak to wyswietlam odpowiednie info
                    if (humanToRemove == null)
                        throw new Exception($"There is not student with provided id {humanId}");

                    Humans.Remove(humanToRemove);

                    Console.WriteLine("You've removed a student successfully!");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("You've provided a wrong number!");

                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }

                success = true;
            }
        }

        public void Edit()
        {
            var success = false;

            var humanToEditName = string.Empty;   // co to robi?

            Human humanToEdit = new Human();        // i co robi to?

            // -- ETAP1: Wyciagniecie od uzytkownika obiekt do edycji
            while (!success)
            {
                Console.WriteLine("Provide student ID to edit:");

                var providedValue = Console.ReadLine();

                try
                {
                    humanToEdit = GetHuman(providedValue);  // czemu mi to nie działa
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }

                success = true;
            }

            // ETAP2: Pobranie od uzytkownika operacji jaka chce wykonac przy edycji
            success = false;

            var editOperationType = EditOperationType.ChangeName;

            while (!success)
            {
                Console.WriteLine("Type [N] for editing the NAME of the student.\nType [G] for editing the Gender.\nType [A] for editing AGE." +
                    "\nType [X] for editing the all values.");

                var providedValue = Console.ReadLine();

                switch (providedValue.ToUpper())
                {
                    case "N":
                        editOperationType = EditOperationType.ChangeName;
                        break;
                    case "G":
                        editOperationType = EditOperationType.ChangeGender;
                        break;
                    case "A":
                        editOperationType = EditOperationType.ChangeAge;
                        break;
                    case "X":
                        editOperationType = EditOperationType.ChangeAll;
                        break;
                    default:
                        continue;
                }

                success = true;
            }

            // -- ETAP3: Wykonujemy operacje edycji
            if (editOperationType == EditOperationType.ChangeName)
            {
                ChangeName(humanToEdit);
            }
            else if (editOperationType == EditOperationType.ChangeGender)
            {
                ChangeGender(humanToEdit);
            }
            else if (editOperationType == EditOperationType.ChangeAge)
            {
                ChangeAge(humanToEdit);
            }
            else if (editOperationType == EditOperationType.ChangeAll)
            {
                ChangeAll(humanToEdit);
            }
        }

        // metody wewnętrzne

        private void ChangeName(Human human)
        {
            var success = false;

            while (!success)
            {
                Console.WriteLine("Provide the new NAME:");

                var providedValue = Console.ReadLine();

                try
                {
                    Validate(providedValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }

                // ZMIENIAMY IMIĘ
                human.Name = providedValue;

                success = true;
            }
        }
        private void ChangeGender(Human human)
        {
            var success = false;

            while (!success)
            {
                Console.WriteLine("Provide the new Gender -> M/F/O:");

                var providedGender = Console.ReadLine();

                while (!providedGender.Equals('M') || !providedGender.Equals('F') || !providedGender.Equals('O'))
                {
                    Console.WriteLine("Wrong gender type, try again with M,F or O");
                    providedGender = Console.ReadLine().ToUpper();
                }

                try
                {
                    Validate(providedGender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    continue;
                }

                // ZMIENIAMY PŁEĆ
                human.Gender = providedGender;

                success = true;
            }
        }
        private void ChangeAge(Human human)
            {
                var success = false;

                while (!success)
                {
                    Console.WriteLine("Provide the new AGE:");

                    var providedValue = Console.ReadLine();

                    try
                    {
                        Validate(providedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        continue;
                    }

                    // ZMIENIAMY WIEK
                    human.Age = providedValue;

                    success = true;
                }
            }
        private void ChangeAll(Human human)
        {
            ChangeName(human);
            ChangeGender(human);
            ChangeAge(human);
        }

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("The name can't me empty!");
        }

        private Human GetHuman(string providedValue)
        {
            // sprawdzamy czy podana wartosc nie jest pustym stringiem
            if (string.IsNullOrWhiteSpace(providedValue))
                throw new Exception("The name can't me empty!");

            // sprawdzamy czy podana wartosc to liczba calkowita
            var parseResult = int.TryParse(providedValue, out var humanId);  //co to robi? out var?

            if (!parseResult)
                throw new Exception("Provided value is not a number");

            // bierzemy referencje do samochodu jaki chcemy edytowac oraz zwracamy ta referencje
            var humanResult = Humans.Find(car => car.Id == carId);

            if (humanResult == null)
                throw new Exception("There is no car with id: " + humanId);

            return humanResult;
        }

        private int BiggestId()
            {
                if (Humans.Count == 0)
                    return 0;

                var result = Humans.First();

                if (result == null)
                    return 0;

                if (Humans.Count == 1)
                    return result.Id;

                foreach (var human in Humans)
                {
                    if (human.Id != result.Id && human.Id > result.Id)
                        result = human;
                }

                return result.Id;
            }
      
    }
}