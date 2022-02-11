public class ComponenteEventosDeMovimentacaoDaGarra : ComponenteGarraDeMovimentacaoGarra
{
    protected void produziuEventoDeDirecao(int direcao)
    {
        getGarra().dispararEventoDirecao(direcao);
    }

    public void produziuEventoDeDirecao(DirecaoDaGarra direcao)
    {
        getGarra().dispararEventoDirecao(direcao);
    }

}
