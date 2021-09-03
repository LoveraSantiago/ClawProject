public class AgendamentoDisplayColetados
{
    public InformacoesColetadoDto infoColetadoDto { get; private set; }
    public ArcoIrisEfeito arcoIris { get; private set; }
    public Executor executor { get; private set; }
    public PowerUpInteracaoDisplayColetado interacaoDisplayColetado { get; private set; }    

    public bool possuiAgendamentoDePowerUp()
    {
        return interacaoDisplayColetado != null;
    }

    public bool possuiAgendamentoDeEvento()
    {
        return infoColetadoDto != null;
    }

    public void agendar(PowerUpInteracaoDisplayColetado interacaoDisplayColetado)
    {
        this.interacaoDisplayColetado = interacaoDisplayColetado;
    }

    public void agendar(
        InformacoesColetadoDto evento, ArcoIrisEfeito arcoIris, Executor executorPosEvento)
    {
        infoColetadoDto = evento;
        this.arcoIris = arcoIris;
        executor = executorPosEvento;
    }

    public void cleanInteracao()
    {
        interacaoDisplayColetado = null;
    }

    public void cleanOutros()
    {
        infoColetadoDto = null;
        arcoIris = null;
        executor = null;
    }
}
