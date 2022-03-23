public abstract class ComponenteAnimacaoDeMovimentacaoGarra : ComponenteEventosDeMovimentacaoDaGarra
{
    public void playAnimacaoComemorar()
    {
        getGarra().comemorar();
    }

    public void playAnimacaoPiscar()
    {
        getGarra().piscar();
    }

    public void playAnimacaoIrPDireita()
    {
        getGarra().irParaDireita();
    }

    public void playAnimacaoIrPEsquerda()
    {
        getGarra().irParaEsquerda();
    }

    public void playAnimacaoIrPCima()
    {
        getGarra().irParaCima();
    }

    public void playAnimacaoIrPBaixo()
    {
        getGarra().irParaBaixo();
    }
    
    public void playAnimacaoGirando()
    {
        getGarra().girando();
    }

    public bool isPlayAnimacaoComemorando()
    {
        return getGarra().isComemorando();
    }

    public bool isNotPlayAnimacaoComemorando()
    {
        return !isPlayAnimacaoComemorando();
    }
}
