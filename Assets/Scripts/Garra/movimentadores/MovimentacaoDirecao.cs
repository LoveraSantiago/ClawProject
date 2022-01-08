public class MovimentacaoDirecao : AbstractMovimentacaoDaGarra
{
    private static int direcao = 1;

    public override void fixedUpdate()
    {
        verificarSeMovimentacaoAtingiuLimites();
    }

    public void produziuEventoDeDirecao()
    {
        produziuEventoDeDirecao(direcao);
    }

    public void moverHorizontalmenteFreeze()
    {
        moverHorizontalmenteFreeze(direcao);
    }

    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (isMaiorPosHorizontal(LIMITE_LATERAL_TELA))
        {
            direcao = -1;
            moverHorizontalmenteFreeze(direcao);
            playAnimacaoIrPEsquerda();
            produziuEventoDeDirecao(DirecaoDaGarra.ESQUERDA);
        }
        else if (isMenorPosHorizontal(-LIMITE_LATERAL_TELA))
        {
            direcao = 1;
            moverHorizontalmenteFreeze(direcao);
            playAnimacaoIrPDireita();
            produziuEventoDeDirecao(DirecaoDaGarra.DIREITA);
        }
    }
}
