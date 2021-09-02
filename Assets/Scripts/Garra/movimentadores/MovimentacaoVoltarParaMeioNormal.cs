public class MovimentacaoVoltarParaMeioNormal : MovimentacaoDaGarraNormal
{
    private MovimentacaoVoltarParaPosicao movVoltarParaMeio;

    public MovimentacaoVoltarParaMeioNormal()
    {
        movVoltarParaMeio = new MovimentacaoVoltarParaPosicao(0);
    }

    public override void preInicio()
    {
        movVoltarParaMeio.preInicio();
    }

    public override void fixedUpdate()
    {
        DirecaoDaGarra direcaoVoltar = movVoltarParaMeio.getDirecaoAtual();
        if (direcaoVoltar == DirecaoDaGarra.ESQUERDA)
        {
            movVoltarParaMeio.voltarVindoPelaEsquerda(-1);
        }
        else if (direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarVindoPelaDireita(1);
        }
        else if (direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
    }
}
