namespace Proiect.Classes;

public class CererePiese
{
    public int AVB { get; set; }
    public string NumeMecanic { get; set; }
    public StatusPiese Status { get; set; } 
    public string DetaliiPiese { get; set; }
    public CerereRezolvare CerereAsociata { get; set; }
        
    public CererePiese(int avb, string numeMecanic, string detaliiPiese, CerereRezolvare cerereAsociata)
    {
        AVB = avb;
        NumeMecanic = numeMecanic;
        DetaliiPiese = detaliiPiese;
        CerereAsociata = cerereAsociata;
        Status = StatusPiese.InAsteptare;
    }
        
    public void SchimbaStatus(StatusPiese nouStatus)
    {
        Status = nouStatus;
    }
}

public enum StatusPiese
{
    InAsteptare,
    Finalizat
}