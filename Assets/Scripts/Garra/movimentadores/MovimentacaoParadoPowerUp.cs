public class MovimentacaoParadoPowerUp : AbstractMovimentacaoDaGarraPowerUp
{
    private MovimentacaoParado movParado;

    public MovimentacaoParadoPowerUp()
    {
        movParado = new MovimentacaoParado();
    }

    public override void preInicio()
    {
        movParado.preInicio();
        stopSomGarraMovimentoVertical();
    }

    public override void fixedUpdate()
    {
        movParado.fixedUpdate();
    }
}
