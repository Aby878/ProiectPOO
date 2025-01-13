namespace Proiect.Classes;

public class Utilizator
{
        public int cod_munca{get;set;}
        public string nume{get;set;}
        public string email{get;set;}
        public string parola{get;set;}
        public string tip_utilizator{get;set;}

        public Utilizator()
        {
            
        }
        public Utilizator(int CodMunca, string Nume, string Email, string Parola, string TipUtilizator)
        {
            cod_munca = CodMunca;
            nume = Nume;
            email = Email;
            parola = Parola;
            tip_utilizator = TipUtilizator;
        
        }
}