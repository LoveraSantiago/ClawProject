public abstract class ComponenteAnimacaoDeMovimentacaoGarra : ComponenteGarraDeMovimentacaoGarra
{
    public void playAnimacaoComemorar()
    {
        getGarra().animacao.comemorar();
    }

    public void playAnimacaoPiscar()
    {
        getGarra().animacao.piscar();
    }

    public void playAnimacaoIrPDireita()
    {
        getGarra().animacao.irParaDireita();
    }

    public void playAnimacaoIrPEsquerda()
    {
        getGarra().animacao.irParaEsquerda();
    }

    public void playAnimacaoIrPCima()
    {
        getGarra().animacao.irParaCima();
    }

    public void playAnimacaoIrPBaixo()
    {
        getGarra().animacao.irParaBaixo();
    }    

    public bool isPlayAnimacaoComemorando()
    {
        return getGarra().animacao.isComemorando();
    }

    public bool isNotPlayAnimacaoComemorando()
    {
        return !isPlayAnimacaoComemorando();
    }
}
