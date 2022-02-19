public class TrioDeColetaveis 
{
    public Coletavel coletavel1 { get; private set; }
    public Coletavel coletavel2 { get; private set; }
    public Coletavel coletavel3 { get; private set; }

    public TrioDeColetaveis(Coletavel coletavel1, Coletavel coletavel2, Coletavel coletavel3)
    {
        this.coletavel1 = coletavel1;
        this.coletavel2 = coletavel2;
        this.coletavel3 = coletavel3;
    }   
}
