public class MovimentacaoVoltarParaCimaPowerUp : AbstractMovimentacaoDaGarraPowerUp
{
    private MovimentacaoVoltarParaCima movVoltarPCima;

    public MovimentacaoVoltarParaCimaPowerUp()
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
