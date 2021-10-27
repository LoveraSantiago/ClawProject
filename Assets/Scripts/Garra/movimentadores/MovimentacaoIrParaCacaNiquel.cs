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
        DirecaoDaGarra direcaoVoltar = movVoltarPosCacaNiquel.getDirecaoAtual();
        if(direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {            
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
        else
        {         
            movVoltarPosCacaNiquel.voltarVindoPelaEsquerda(getPosicaoCacaNiquel(), - 0.5f);
        }
    }
}
