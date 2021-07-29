public class TempoEsgotado 
{
    public bool restart { get; private set; }

    public TempoEsgotado(bool restart)
    {
        this.restart = restart;
    }

    public bool isTimeOver()
    {
        return !restart;
    }
}
