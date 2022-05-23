public class MovimentacaoVoltarParaCimaNormal : AbstractMovimentacaoDaGarraNormal
{
    private MovimentacaoVoltarParaCima movVoltarPCima;

    public MovimentacaoVoltarParaCimaNormal()
    {
        movVoltarPCima = new MovimentacaoVoltarParaCima(comunicadorComGerMovimentacao);
    }

    public override void preInicio()
    {
        movVoltarPCima.preInicio();
    }


    public override void update(InputGame inputGame)
    {
        movVoltarPCima.update(inputGame);
    }

    public override void fixedUpdate()
    {
        movVoltarPCima.fixedUpdate();
    }
}
