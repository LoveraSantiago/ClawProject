public class AgendamentoDisplayColetados
{
    public PowerUpEnums.TIPO tipoPup { get; private set; }
    public InformacoesColetadoDto infoColetadoDto { get; private set; }
    public ArcoIrisEfeito arcoIris { get; private set; }    
    public PowerUpInteracaoComDisplayColetado interacaoDisplayColetado { get; private set; }    

    public bool possuiAgendamentoDePowerUp()
    {
        return interacaoDisplayColetado != null;
    }

    public bool possuiAgendamentoDeEvento()
    {
        return infoColetadoDto != null;
    }

    public void agendar(PowerUpEnums.TIPO tipo)
    {
        tipoPup = tipo;
    }

    public void agendar(PowerUpInteracaoComDisplayColetado interacaoDisplayColetado)
    {
        this.interacaoDisplayColetado = interacaoDisplayColetado;
    }

    public void agendar(
        InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris)
    {
        infoColetadoDto = evento;
        this.arcoIris = arcoIris;        
    }

    public void cleanInteracao()
    {
        interacaoDisplayColetado = null;
    }

    public void cleanOutros()
    {
        infoColetadoDto = null;
        arcoIris = null;        
    }
}
