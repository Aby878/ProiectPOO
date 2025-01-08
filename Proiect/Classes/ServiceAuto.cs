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
}