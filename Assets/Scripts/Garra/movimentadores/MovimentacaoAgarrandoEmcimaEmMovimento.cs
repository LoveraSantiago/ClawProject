using UnityEngine;

public class MovimentacaoAgarrandoEmcimaEmMovimento : MovimentacaoDaGarraPowerUp
{
    private int direcao;

    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;

    public MovimentacaoAgarrandoEmcimaEmMovimento()
    {
    }

    public override void preInicio()
    {
        configurarAngulos();
        acionarColliderDasPincas();
        interagirComPup();

        direcao = 1;
        produziuEventoDeDirecao(direcao);//reesincronizarJoystick
    }

    public override void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            comunicadorComGerMovimentacao.trocarParaAcaoSoltar();
        }
    }

    public override void fixedUpdate()
    {
        rotacionarPincaVelocidadeFechamentoFDT(anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);
        verificarSeMovimentacaoAtingiuLimites();
        moverHorizontalmenteFreeze(direcao);
    }

    //TODO duplicidade com MovimentacaoLateralZigZag
    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (isMaiorPosHorizontal(LIMITE_LATERAL_TELA - 0.1f))
        {
            direcao = -1;
            moverHorizontalmenteFreeze(direcao);
            produziuEventoDeDirecao(DirecaoDaGarra.ESQUERDA);
        }
        else if (isMenorPosHorizontal(-LIMITE_LATERAL_TELA + 0.1f))
        {
            direcao = 1;
            moverHorizontalmenteFreeze(direcao);
            produziuEventoDeDirecao(DirecaoDaGarra.DIREITA);
        }      
    }

    private void configurarAngulos()
    {
        anguloDesejadoDireitaFechado = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
    }

    private void interagirComPup()
    {
        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.colocarNaPosicao(getPosicaoCentroGarra());
    }
}
