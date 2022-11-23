public class MovimentacaoParaCima : AbstractMovimentacaoDaGarraNormal
{
    public override void preInicio()
    {
        colocarMassa(getMassaMovimentacaoCima());

        contabilizarSubida();                
        playAnimacaoIrPCima();
        playSomGarraMovimentoVertical();
    }

    public override void update(InputGame inputGame)
    {        
        if(isAcimaPosInicial())
        {
            colocarNaAlturaInicial();
            voltando();
            trocarAcao();            
        }
    }

    public override void fixedUpdate()
    {
        moverParaCimaFreeze();
    }    
    
    protected virtual void trocarAcao()
    {
        comunicadorComGerMovimentacao.trocarParaAcaoNormal();
    }
}
