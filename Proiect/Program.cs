using Proiect.Classes;

namespace Proiect;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bine ati venit in meniul aplicatiei!");
        ConsoleWrapper consoleWrapper = new ConsoleWrapper();
        ServiceAuto serviceAuto = new ServiceAuto(consoleWrapper);

        string meniu_aplicatie = @"
        In aceasta aplicatie avem urmatoarele posibilitati:
        1. Adaugare utilizator
        2. Logare
        3. Iesire     
        ";

        Console.WriteLine(meniu_aplicatie);
        string command = Console.ReadLine();

        while (command != "3")
        {
            switch (command)
            {
                case "1":
                    serviceAuto.Adaugare_Utilizator();
                    break;
                case "2":
                    serviceAuto.Logare_Utilizator();
                    break;
                case "3":
                    break;
                default:
                    break;
            }

            Console.WriteLine(meniu_aplicatie);
            command = Console.ReadLine();
                        
        }

    }
}