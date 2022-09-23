public class ComponenteEventosDeMovimentacaoDaGarra : ComponenteGarraDeMovimentacaoGarra
{
    protected void produziuEventoDeDirecao(int direcao)
    {
        getGarra().dispararEventoDirecao(direcao);
    }

    public void produziuEventoDeDirecao(Direcao direcao)
    {
        getGarra().dispararEventoDirecao(direcao);
    }

}
