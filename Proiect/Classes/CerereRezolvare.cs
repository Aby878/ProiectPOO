namespace Proiect.Classes;

public class CerereRezolvare
{
        public int Id { get; set; }
        public string NumeClient { get; set; }
        public string NumarMasina { get; set; } 
        public string DescriereProblema { get; set; }
        public StatusCerere Status { get; set; } 
        public Mecanic MecanicResponsabil { get; set; } 
        
        public CerereRezolvare(int id, string numeClient, string numarMasina, string descriereProblema)
        {
            Id = id;
            NumeClient = numeClient;
            NumarMasina = numarMasina;
            DescriereProblema = descriereProblema;
            Status = StatusCerere.InPreluare;
        }
        
        public void SchimbaStatus(StatusCerere nouStatus)
        {
            Status = nouStatus;
        }
        
        public void AsigneazaMecanic(Mecanic mecanic)
        {
            MecanicResponsabil = mecanic;
            Status = StatusCerere.Investigare;
        }
    }

    public enum StatusCerere
    {
        InPreluare,
        Investigare,
        AsteptarePiese,
        Finalizat
    }