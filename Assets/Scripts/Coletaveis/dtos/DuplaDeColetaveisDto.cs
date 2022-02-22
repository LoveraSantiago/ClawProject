public class DuplaDeColetaveisDto 
{
    public Coletavel coletavel1 { get; private set; }
    public Coletavel coletavel2 { get; private set; }

    public DuplaDeColetaveisDto(Coletavel coletavel1, Coletavel coletavel2)
    {
        this.coletavel1 = coletavel1;
        this.coletavel2 = coletavel2;
    }
}
