namespace Shared;

public class Bruger
{
    public string Brugernavn { get; set; }
    public int BrugerId { get; set; }

    public Bruger(string brugernavn)
    {
       Brugernavn = brugernavn;
    }
    public Bruger() { }
}
