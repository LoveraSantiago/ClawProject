public class TipoContagemTempoDto 
{
    public ContadorTimer.Contagem contagem { get; private set; }
    public string tempo { get; private set; }

    public TipoContagemTempoDto(ContadorTimer.Contagem contagem, string tempo)
    {
        this.contagem = contagem;
        this.tempo = tempo;
    }
}
