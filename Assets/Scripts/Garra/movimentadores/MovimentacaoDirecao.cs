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
        float limiteGarra = getGarra().getPosicaoLimiteGarra();
        if(isMaiorPosHorizontal(limiteGarra))
        {
            direcao = -1;
            moverHorizontalmenteFreeze(direcao);
            playAnimacaoIrPEsquerda();
            produziuEventoDeDirecao(Direcao.ESQUERDA);
        }
        else if (isMenorPosHorizontal(-limiteGarra))
        {
            direcao = 1;
            moverHorizontalmenteFreeze(direcao);
            playAnimacaoIrPDireita();
            produziuEventoDeDirecao(Direcao.DIREITA);
        }
    }
}
