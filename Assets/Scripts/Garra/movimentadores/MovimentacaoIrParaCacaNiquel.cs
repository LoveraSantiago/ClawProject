public class MovimentacaoIrParaCacaNiquel : MovimentacaoDaGarraCacaNiquel
{
    private MovimentacaoVoltarParaPosicao movVoltarPosCacaNiquel;

    public MovimentacaoIrParaCacaNiquel()
    {
        movVoltarPosCacaNiquel = new MovimentacaoVoltarParaPosicao(getPosicaoCacaNiquel());
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
            movVoltarPosCacaNiquel.voltarVindoPelaEsquerda(-0.5f);
        }
    }
}
