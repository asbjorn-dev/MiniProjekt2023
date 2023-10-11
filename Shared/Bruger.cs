namespace Shared;

public class Bruger
{
    public string Brugernavn { get; set; }
    public int Bruger_Id { get; set; }

    public Bruger(string brugernavn = "")
    {
       Brugernavn = brugernavn;
    }
    public Bruger()
    {
        Bruger_Id = 0;
        Brugernavn = "";
    }
}
