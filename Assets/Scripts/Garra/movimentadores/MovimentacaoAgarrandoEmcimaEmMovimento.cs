public class MovimentacaoAgarrandoEmcimaEmMovimento : MovimentacaoAgarrandoEmcima
{
    private int direcao;

    public override void preInicio()
    {
        base.preInicio();

        direcao = 1;
        dispararEventoDirecao(direcao);//reesincronizarJoystick
    }

    public override void update()
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            comunicadorComGerMovimentacao.trocarParaAcaoSoltar();
        }
    }

    public override void fixedUpdate()
    {
        base.fixedUpdate();        
        verificarSeMovimentacaoAtingiuLimites();
        moverGarraHorizontalmenteFreeze(direcao);
    }

    //TODO duplicidade com MovimentacaoLateralZigZag
    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (isGarraMaiorPosHorizontal(LIMITE_LATERAL_TELA - 0.1f))
        {
            direcao = -1;
            moverGarraHorizontalmenteFreeze(direcao);
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (isGarraMenorPosHorizontal(-LIMITE_LATERAL_TELA + 0.1f))
        {
            direcao = 1;
            moverGarraHorizontalmenteFreeze(direcao);
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            //nada
        }
    }

}
