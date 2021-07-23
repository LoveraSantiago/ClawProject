public class ElevadorFim 
{
    public bool finalizou { get; private set; }

    public ElevadorFim(bool finalizou)
    {
        this.finalizou = finalizou;
    }
}
