public class TipoContagemTempoDto 
{
    private ContadorTimer.Contagem contagem;
    public string tempo { get; private set; }

    public TipoContagemTempoDto(ContadorTimer.Contagem contagem, string tempo)
    {
        this.contagem = contagem;
        this.tempo = tempo;
    }

    public bool isContagemNormal()
    {
        return contagem == ContadorTimer.Contagem.NORMAL;
    }

    public bool isContagemContinua()
    {
        return contagem == ContadorTimer.Contagem.CONTINUA;
    }

    public bool isContagemRegressiva()
    {
        return contagem == ContadorTimer.Contagem.REGRESSIVA;
    }
}
