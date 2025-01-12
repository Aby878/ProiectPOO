namespace Proiect.Classes;

public class ServiceAuto
{
    private int cod = 1000;
    private List<Utilizator> utilizatori = new List<Utilizator>();
    private List<CerereRezolvare> cereriRezolvare = new List<CerereRezolvare>();
    private List<CererePiese> cereriPiese = new List<CererePiese>();
    private int idCounterRezolvare = 1;
    private int idCounterPiese = 1;
    private readonly ConsoleWrapper _console;
    public ServiceAuto(ConsoleWrapper console)
    {
        _console = console;
    }
    public void Adaugare_Utilizator()
    {
        _console.WriteLine("Adăugare utilizator nou");
        
        cod++;
        string rol;

        while (true)
        {
            rol = _console.ReadLine("Scrieti tipul de utilizator: administrator/mecanic").ToLower();
            if (rol == "administrator" || rol == "mecanic")
                break;
            _console.WriteLine("Rol invalid! Introduceti 'administrator' sau 'mecanic'.");
        }

        string name = _console.ReadLine("Introduceti numele:");
        string email = _console.ReadLine("Introduceti email:");
        if (utilizatori.Any(u => u.email == email))
        {
            _console.WriteLine("Email deja utilizat! Incercati altul!");
            return;
        }

        string parola = _console.ReadLine("Introduceti parola:");
        if (string.IsNullOrEmpty(parola))
        {
            _console.WriteLine("Parola invalida!");
            return;
        }

        Utilizator utilizatorNou = new Utilizator(cod, name, email, parola, rol);
        utilizatori.Add(utilizatorNou);
        _console.WriteLine($"Utilizator {rol} adăugat cu succes! Cod unic: {cod}");
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
        string _meniu_administrator = @"
        1.Vizualizare cereri de rezolvare
        2.Vizualizare comenzi piese
        3.Preluare si finalizare comenzi piese auto 
        4.Adaugare cerere de rezolvare
        5. Adaugare cerere piese
        0.Iesire";
        
        _console.WriteLine("Alegeti optiunea dorita:");
        _console.WriteLine(_meniu_administrator);
        string comanda = _console.ReadLine("Introduceti optiunea:");
        
        while (comanda != "0")
        {
            switch (comanda)
            {
                case "1":
                    VizualizareCereriRezolvare();
                    break;

                case "2":
                    VizualizareCereriPiese();
                    break;

                case "3":
                    int avb = _console.ReadInt("Introduceti AVB-ul comenzii de piese pe care doriti sa o finalizati:");
                    FinalizareCereriPiese();
                    break;

                case "4":
                    string numeClient = _console.ReadLine("Introduceti numele clientului:");
                    string numarMasina = _console.ReadLine("Introduceti numarul masinii:");
                    string descriereProblema = _console.ReadLine("Descrieti problema:");
                    AdaugaCerereRezolvare();
                    break;

                case "5":
                    string numeMecanic = _console.ReadLine("Introduceti numele mecanicului:");
                    string detaliiPiese = _console.ReadLine("Introduceti detaliile piesei:");
                    int idCerereRezolvare = _console.ReadInt("Introduceti ID-ul cererii de rezolvare asociate:");
                    AdaugaCererePiese();
                    break;

                case "0":
                    _console.WriteLine("Iesire din meniul administrator.");
                    return;

                default:
                    _console.WriteLine("Optiune invalida! Va rugam sa alegeti din nou.");
                    break;
            }
        }

    }

    
    public void AdaugaCerereRezolvare()
    {
        _console.WriteLine("Adăugare cerere de rezolvare");
        
        string numeClient = _console.ReadLine("Introduceti numele clientului:");
        string numarMasina = _console.ReadLine("Introduceti numarul masinii:");
        
        if (!ValidareNumarMasina(numarMasina))
        {
            _console.WriteLine("Numarul de masina este invalid! Reincercati.");
            return;
        }

        string descriereProblema = _console.ReadLine("Descrieti problema:");
        
        if (string.IsNullOrEmpty(numeClient) || string.IsNullOrEmpty(descriereProblema))
        {
            _console.WriteLine("Toate campurile sunt obligatorii! Reincercati.");
            return;
        }
        
        CerereRezolvare cerere = new CerereRezolvare(idCounterRezolvare++, numeClient, numarMasina, descriereProblema);
        cereriRezolvare.Add(cerere);

        _console.WriteLine($"Cererea de rezolvare a fost adaugata cu succes. ID cerere: {cerere.Id}");
    }
    
    public void VizualizareCereriRezolvare()
    {
        _console.WriteLine("Listă cereri de rezolvare:");

        if (!cereriRezolvare.Any())
        {
            _console.WriteLine("Nu exista cereri de rezolvare.");
            return;
        }

        foreach (var cerere in cereriRezolvare)
        {
            _console.WriteLine(
                $"ID: {cerere.Id}, Client: {cerere.NumeClient},Mașină: {cerere.NumarMasina}, Status: {cerere.Status}, Descriere: {cerere.DescriereProblema}");
        }
    }

    public void AdaugaCererePiese()
    {
        _console.WriteLine("Adăugare cerere de piese");
        
        string numeMecanic = _console.ReadLine("Introduceti numele mecanicului:");
        string detaliiPiese = _console.ReadLine("Introduceti detaliile piesei:");
        int idCerereRezolvare = _console.ReadInt("Introduceti ID-ul cererii de rezolvare asociate:");
        
        var cerereRezolvare = cereriRezolvare.Find(c => c.Id == idCerereRezolvare);
        if (cerereRezolvare == null)
        {
            _console.WriteLine("Cererea de rezolvare nu exista! Reincercati.");
            return;
        }
        
        CererePiese cererePiese = new CererePiese(idCounterPiese++, numeMecanic, detaliiPiese, cerereRezolvare);
        cereriPiese.Add(cererePiese);
        
        cerereRezolvare.Status = StatusCerere.AsteptarePiese;
        
        _console.WriteLine($"Cererea de piese a fost creata cu succes! AVB: {cererePiese.AVB}");
    }

    public void VizualizareCereriPiese()
    {
        _console.WriteLine("Listă cereri de piese:");
        
        if (!cereriPiese.Any())
        {
            _console.WriteLine("Nu există cereri de piese inregistrate.");
            return;
        }

        foreach (var cerere in cereriPiese)
        {
            _console.WriteLine($"AVB: {cerere.AVB}, Mecanic: {cerere.NumeMecanic}, Status: {cerere.Status}, Detalii: {cerere.DetaliiPiese}");
        }
    }

    public void FinalizareCereriPiese()
    {
        _console.WriteLine("Finalizare cerere de piese");
        
        int avb = _console.ReadInt("Introduceți AVB-ul cererii de piese pe care doriti sa o introduceti:");
        
        var cerere = cereriPiese.Find(c => c.AVB == avb);
        if (cerere == null)
        {
            Console.WriteLine("Cererea de piese nu exista! Incercati un AVB valid!");
            return;
        }

        cerere.SchimbaStatus(StatusPiese.Finalizat);
        cerere.CerereAsociata.SchimbaStatus(StatusCerere.Investigare);

        Console.WriteLine($"Cererea de piese cu AVB {avb} a fost finalizata.");
    }
    
    private bool ValidareNumarMasina(string numarMasina)
    {
        string pattern = @"^[A-Z]{1,2}-\d{2,3}-[A-Z]{3}$";
        return System.Text.RegularExpressions.Regex.IsMatch(numarMasina, pattern);
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
                    PreluareCerereRezolvare();
                    break;
                case "2":
                    InvestigareProblema();
                    break;
                case "3":
                    CreareCererePiese();
                    break;
                case "4":
                    RezolvareProblemaMasina();
                    break;
                case "0":
                    _console.WriteLine("Iesire din meniu mecanic.");
                    break; 
                default:
                    _console.WriteLine("Optiune invalida!Va rugam sa alegeti din nou.");
                    break;
            }
            _console.WriteLine(_meniu_mecanic);
            comanda=_console.ReadLine("Introduceti optiunea:");
        }
        
    }
     public void PreluareCerereRezolvare()
    {
        var cerere = cereriRezolvare.FirstOrDefault(c => c.Status == StatusCerere.InPreluare);

        if (cerere == null)
        {
            _console.WriteLine("Nu exista cereri de rezolvare in asteptare.");
            return;
        }

        string numeMecanic = _console.ReadLine("Introduceti numele mecanicului care preia cererea:");
        var mecanic = utilizatori.OfType<Mecanic>().FirstOrDefault(m => m.nume == numeMecanic);

        if (mecanic == null)
        {
            _console.WriteLine("Mecanicul specificat nu exista.");
            return;
        }

        cerere.AsigneazaMecanic(mecanic);
        _console.WriteLine($"Cererea ID {cerere.Id} a fost preluata de mecanicul {mecanic.nume}.");
    }

    public void InvestigareProblema()
    {
        int idCerere = _console.ReadInt("Introduceti ID-ul cererii de investigat:");
        var cerere = cereriRezolvare.FirstOrDefault(c => c.Id == idCerere);

        if (cerere == null || cerere.Status != StatusCerere.Investigare)
        {
            _console.WriteLine("Cererea specificata nu este valida sau nu este in investigare.");
            return;
        }

        _console.WriteLine("Se decide daca problema poate fi rezolvata cu sau fara piese auto.");
        string decizie = _console.ReadLine("Scrieti 'da' daca sunt necesare piese auto sau 'nu' daca problema poate fi rezolvata direct:").ToLower();

        if (decizie == "da")
        {
            cerere.SchimbaStatus(StatusCerere.AsteptarePiese);
            _console.WriteLine($"Cererea ID {cerere.Id} necesita piese auto si a fost marcata ca 'Asteptare Piese'.");
        }
        else if (decizie == "nu")
        {
            cerere.SchimbaStatus(StatusCerere.Investigare);
            _console.WriteLine($"Cererea ID {cerere.Id} poate fi rezolvata direct.");
        }
        else
        {
            _console.WriteLine("Optiune invalida. Reincercati investigarea.");
        }
    }

    public void CreareCererePiese()
    {
        int idCerereRezolvare = _console.ReadInt("Introduceti ID-ul cererii de rezolvare asociate:");
        var cerereRezolvare = cereriRezolvare.FirstOrDefault(c => c.Id == idCerereRezolvare);

        if (cerereRezolvare == null || cerereRezolvare.Status != StatusCerere.AsteptarePiese)
        {
            _console.WriteLine("Cererea de rezolvare nu exista sau nu necesita piese auto.");
            return;
        }

        string numeMecanic = _console.ReadLine("Introduceti numele mecanicului care initiaza cererea de piese:");
        string detaliiPiese = _console.ReadLine("Introduceti detaliile pieselor necesare:");

        CererePiese cererePiese = new CererePiese(idCounterPiese++, numeMecanic, detaliiPiese, cerereRezolvare);
        cereriPiese.Add(cererePiese);

        cerereRezolvare.SchimbaStatus(StatusCerere.AsteptarePiese);
        _console.WriteLine($"Cererea de piese a fost creata cu succes. AVB: {cererePiese.AVB}");
    }

    public void RezolvareProblemaMasina()
    {
        int idCerere = _console.ReadInt("Introduceti ID-ul cererii de rezolvare pentru masina:");
        var cerere = cereriRezolvare.FirstOrDefault(c => c.Id == idCerere);

        if (cerere == null)
        {
            _console.WriteLine("Cererea specificata nu exista.");
            return;
        }

        if (cerere.Status == StatusCerere.AsteptarePiese)
        {
            _console.WriteLine("Cererea nu poate fi rezolvata deoarece inca se asteapta piesele necesare.");
            return;
        }

        string numeMecanic = _console.ReadLine("Introduceti numele mecanicului care rezolva cererea:");
        var mecanic = utilizatori.OfType<Mecanic>().FirstOrDefault(m => m.nume == numeMecanic);

        if (mecanic == null)
        {
            _console.WriteLine("Mecanicul specificat nu exista.");
            return;
        }

        cerere.SchimbaStatus(StatusCerere.Finalizat);
        _console.WriteLine($"Cererea ID {cerere.Id} a fost rezolvata cu succes de mecanicul {mecanic.nume}.");
    }
}