public class PowerUpUsadoDto 
{
    public PowerUpEnums.TIPO tipo { get; private set; }
    public double tempoAcionamento { get; private set; }

    public PowerUpUsadoDto(PowerUpEnums.TIPO tipo, double tempoAcionamento)
    {
        this.tipo = tipo;
        this.tempoAcionamento = tempoAcionamento;
    }
}
