public class ComponenteEfeitoDeMovimentacaoGarra : ComponenteAngulosPincaDeMovimentacaoGarra
{
    protected void ligarEfeitoTrailParaCima()
    {
        getGarra().ligarEfeitoTrailPCima();//deveria estar aqui?
    }

    protected void ligarEfeitoTrailParaBaixo()
    {
        getGarra().ligarEfeitoTrailPBaixo();
    }

    protected void desligarEfeitoTrail()
    {
        getGarra().desligarEfeitoTrail();
    }
}
