public class MovimentacaoComemorando : AbstractMovimentacaoDaGarraNormal
{
    private IntervaloDeTempo intervaloDeTempo;

    public override void preInicio()
    {
        intervaloDeTempo = new IntervaloDeTempo(getTempoComemoracao());
    }


    public override void update(InputGame inputGame)
    {
        if (intervaloDeTempo.contarTempo())
        {
            comunicadorComGerMovimentacao.trocarParaMovLateral();
        }
    }

}
