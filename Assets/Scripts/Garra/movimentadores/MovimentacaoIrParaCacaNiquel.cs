public class MovimentacaoIrParaCacaNiquel : MovimentacaoDaGarraCacaNiquel
{
    private MovimentacaoVoltarParaPosicao movVoltarPosCacaNiquel;

    public MovimentacaoIrParaCacaNiquel()
    {
        movVoltarPosCacaNiquel = new MovimentacaoVoltarParaPosicao();
    }

    public override void preInicio()
    {
        movVoltarPosCacaNiquel.preInicio(getPosicaoCacaNiquel());
    }

    public override void fixedUpdate()
    {        
        if(movVoltarPosCacaNiquel.isDirecaoCentralizada)
        {            
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
        else
        {         
            movVoltarPosCacaNiquel.voltarVindoPelaEsquerda(getPosicaoCacaNiquel(), - 0.5f);
        }
    }
}
