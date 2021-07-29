public class MovimentacaoParadoNormal : MovimentacaoDaGarraNormal
{
    private MovimentacaoParado movParado;

    public MovimentacaoParadoNormal()
    {
        movParado = new MovimentacaoParado();
    }

    public override void preInicio()
    {
        movParado.preInicio();
    }

    public override void fixedUpdate()
    {
        movParado.fixedUpdate();
    }
}
