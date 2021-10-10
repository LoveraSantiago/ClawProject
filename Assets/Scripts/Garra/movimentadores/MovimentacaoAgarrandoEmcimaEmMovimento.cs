using UnityEngine;

public class MovimentacaoAgarrandoEmcimaEmMovimento : MovimentacaoDaGarraPowerUp
{
    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;
    private int direcao;

    public override void preInicio()
    {
        anguloDesejadoDireitaFechado = Quaternion.Euler(0, 0, garraInteracaoComPowerUp.getAnguloParaGarraSegurar());
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraInteracaoComPowerUp.getAnguloParaGarraSegurar());

        acionarColliderDasPincas();        

        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.ligarGravidadeZero();
        garraInteracaoComPowerUp.colocarNaPosicao(garraDto.CentroDaGarra.position);

        direcao = 1;
        dispararEventoDirecao(direcao);//reesincronizarJoystick
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
        pincas.rotacionarFDT(garraDto.Velocidades.MovAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);
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
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (isMenorPosHorizontal(-LIMITE_LATERAL_TELA + 0.1f))
        {
            direcao = 1;
            moverHorizontalmenteFreeze(direcao);
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            //nada
        }
    }

}
