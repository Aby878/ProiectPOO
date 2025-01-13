namespace Proiect.Classes;

public class ServiceAutoData 
{
    public int Cod { get; set; }                
    public int IdCounterRezolvare { get; set; } 
    public int IdCounterPiese { get; set; }    

    public List<Utilizator> Utilizatori { get; set; }      
    public List<CerereRezolvare> CereriRezolvare { get; set; }
    public List<CererePiese> CereriPiese { get; set; }       
}