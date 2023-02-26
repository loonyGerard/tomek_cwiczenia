using AplikacaDlaKolekcji;

var shutDown = false;
// nie działa mi skrót cw -> tab, nie robi nowiej lini, nie działa mi też autoformatowanie shift/alt/l czy jakos tak
//var option = new Options();

Console.WriteLine("Hello in your students collection app!");

while(!shutDown)
{
    Console.WriteLine("\nList of possible operations:");
    Console.WriteLine("Type [A] for adding the new student");
    Console.WriteLine("Type [D] for delete the student");
    Console.WriteLine("Type [S] for showing all student");
    Console.WriteLine("Type [E] for editing the student");
    Console.WriteLine("Type [EXIT] for closing the app");

    var userValue = Console.ReadLine();

    switch (userValue.ToUpper())
    {
        case "A": // ważen, tu wpisujemy " : ", a nie średnik
            HumanOptions.Add();
            break;
        case "S":
            HumanOptions.Show();
            break;
        case "D":
            HumanOptions.Delete();
            break;
        case "E":
            HumanOptions.Edit();
            break;
        case "EXIT":
            shutDown = true;
            break;
        default:  // to podaje co się stanie przy podaniu innej opcji.
            Console.WriteLine("You've provided the wrong operation!");
            break;
    }
}

Console.WriteLine("Closing the application...");