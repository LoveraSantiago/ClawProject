public class MovimentacaoVoltarParaMeioNormal : AbstractMovimentacaoDaGarraNormal
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
        if (movVoltarParaMeio.isDirecaoEsquerda)
        {
            movVoltarParaMeio.voltarVindoPelaEsquerda(getPosicaoHorizontalMeio(), -1);
        }
        else if (movVoltarParaMeio.isDirecaoDireita)
        {
            movVoltarParaMeio.voltarVindoPelaDireita(getPosicaoHorizontalMeio(), 1);
        }
        else if (movVoltarParaMeio.isDirecaoCentralizada)
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
    }
}
