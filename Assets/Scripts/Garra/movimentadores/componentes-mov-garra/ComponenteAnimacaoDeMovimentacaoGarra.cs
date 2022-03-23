public abstract class ComponenteAnimacaoDeMovimentacaoGarra : ComponenteEventosDeMovimentacaoDaGarra
{
    public void playAnimacaoComemorar()
    {
        getGarra().animacaoComemorar();
    }

    public void playAnimacaoPiscar()
    {
        getGarra().animacaoPiscar();
    }

    public void playAnimacaoIrPDireita()
    {
        getGarra().animacaoParaDireita();
    }

    public void playAnimacaoIrPEsquerda()
    {
        getGarra().animacaoParaEsquerda();
    }

    public void playAnimacaoIrPCima()
    {
        getGarra().animacaoParaCima();
    }

    public void playAnimacaoIrPBaixo()
    {
        getGarra().animacaoParaBaixo();
    }
    
    public void playAnimacaoGirando()
    {
        getGarra().animacaoGirando();
    }

    public bool isPlayAnimacaoComemorando()
    {
        return getGarra().isAnimacaoComemorando();
    }

    public bool isNotPlayAnimacaoComemorando()
    {
        return !isPlayAnimacaoComemorando();
    }
}
