public class TempoEsgotadoDto 
{
    public bool restart { get; private set; }

    public TempoEsgotadoDto(bool restart)
    {
        this.restart = restart;
    }

    public bool isTimeOver()
    {
        return !restart;
    }
}
