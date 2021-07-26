public class MovimentacaoVoltarParaMeioNormal : MovimentacaoDaGarraNormal
{
    private MovimentacaoVoltarParaMeio movVoltarParaMeio;

    public MovimentacaoVoltarParaMeioNormal()
    {
        movVoltarParaMeio = new MovimentacaoVoltarParaMeio();
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
            movVoltarParaMeio.voltarAoMeioVindoPelaEsquerda();
        }
        else if (direcaoVoltar == DirecaoDaGarra.DIREITA)
        {
            movVoltarParaMeio.voltarAoMeioVindoPelaDireita();
        }
        else if (direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
    }
}
