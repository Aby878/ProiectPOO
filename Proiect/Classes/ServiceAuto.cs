namespace Proiect.Classes;

public class ServiceAuto
{
    private int cod = 1000;
    private List<Utilizator> utilizatori = new List<Utilizator>();
    
    public void Adaugare_Utilizator()
    {
        cod = cod + 1;
        string rol;
        while (true)
        {
            Console.WriteLine("Scrieti tipul de utilizator: administrator/mecanic");
            rol = Console.ReadLine()?.ToLower();
            if (rol == "administrator" || rol == "mecanic")
                break;
            else
                Console.WriteLine("Rol invalid! Introduceti 'administrator' sau 'mecanic'.");
            
        }
        
        Console.WriteLine("Introduceti numele:");
        string Name = Console.ReadLine();
        Console.WriteLine("Introduceti email:");
        string Email = Console.ReadLine();
        if (utilizatori.Any(u => u.email == Email))
        {
            Console.WriteLine("Email deja utilizat!Incercati altul!");
            return;

        }
        
        Console.WriteLine("Introduceti parola:");
        string Parola = Console.ReadLine();
        if (string.IsNullOrEmpty(Parola))
        {
            Console.WriteLine("Parola invalida!");
            return;
        }

        Utilizator utilizatorNou = new Utilizator(cod, Name, Email, Parola, rol);
        utilizatori.Add(utilizatorNou);
        Console.WriteLine($"Utilizator {rol} adăugat cu succes! Cod unic: {cod}");
    }
    
     public void Logare_Utilizator()
    {
        while (true)
        {
            Console.WriteLine("Apasati tasta 0 daca doriti sa reveniti la meniul anterior\n Introduceti email-ul:");
            string Email = Console.ReadLine();
            if (Email == "0")
            {
                break;
            }


            var utilizator = utilizatori.Find(u => u.email == Email);
            if (utilizator == null)
            {
                Console.WriteLine("Nu exista un cont cu aceasta adresa de email! Incercati din nou.");
                continue;
            }

            while (true)
            {
                Console.WriteLine("Introduceti parola:");
                string Parola = Console.ReadLine();


                if (utilizator.parola == Parola)
                {
                    Console.WriteLine("Autentificare efectuata cu succes!");
                    if (utilizator.tip_utilizator == "administrator")
                    {
                        Meniu_Administrator();
                    }
                    else if (utilizator.tip_utilizator == "mecanic")
                    {
                        Meniu_Mecanic();
                    }

                    return;
                }
                else
                {
                    Console.WriteLine("Parola invalida! Incercati din nou.");
                }
            }

           
            
        }
        
    }
    
    public void Meniu_Administrator()
    {
        Console.WriteLine("Alegeti optiunea dorita");
        string _meniu_administrator = @"
        1.Vizualizare cereri de rezolvare
        2.Vizualizare comenzi piese
        3.Preluzare si finalizare comanda piese auto 
        4.Adaugare cerere de rezolvare
        0.Iesire";
        Console.WriteLine(_meniu_administrator);
        string comanda =Console.ReadLine();
        while (comanda != "0")
        {
            switch (comanda)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "0":
                    break; 
                default:
                    break;
            }
        }

    }

    public void Meniu_Mecanic()
    {
        Console.WriteLine("Alegeti optiunea dorita");
        string _meniu_mecanic = @"
        1.Preluare cerere de rezolvare din lista de asteptare
        2.Investigare problema
        3.Cerere piese auto 
        4.Rezolvare problema masina
        0.Iesire";
        Console.WriteLine(_meniu_mecanic);
        string comanda =Console.ReadLine();
        while (comanda != "0")
        {
            switch (comanda)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "0":
                    break; 
                default:
                    break;
            }
        }
        
    }
}