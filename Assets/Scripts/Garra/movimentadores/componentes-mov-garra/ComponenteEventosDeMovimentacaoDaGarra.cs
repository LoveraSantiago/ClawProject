public class ComponenteEventosDeMovimentacaoDaGarra : ComponenteSomDaGarraDeMovimentacaoGarra
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
