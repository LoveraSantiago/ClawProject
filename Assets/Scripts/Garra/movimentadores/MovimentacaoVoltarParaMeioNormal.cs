public class MovimentacaoVoltarParaMeioNormal : MovimentacaoDaGarraNormal
{    
    private MovimentacaoVoltarParaPosicao movVoltarParaMeio;

    public MovimentacaoVoltarParaMeioNormal()
    {
        movVoltarParaMeio = new MovimentacaoVoltarParaPosicao();
    }

    public override void preInicio()
    {
        movVoltarParaMeio.preInicio(getPosicaoHorizontalMeio());
    }

    public override void fixedUpdate()
    {
        DirecaoDaGarra direcaoVoltar = movVoltarParaMeio.getDirecaoAtual();
        if (direcaoVoltar == DirecaoDaGarra.ESQUERDA)
        {
            movVoltarParaMeio.voltarVindoPelaEsquerda(getPosicaoHorizontalMeio(), -1);
        }
        else if (direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarVindoPelaDireita(getPosicaoHorizontalMeio(), 1);
        }
        else if (direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
    }
}
