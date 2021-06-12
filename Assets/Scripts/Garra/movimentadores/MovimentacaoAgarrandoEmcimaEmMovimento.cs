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

        pincas.acionarCollider();

        garraInteracaoComPowerUp.iniciar();
        garraInteracaoComPowerUp.desligarGravidade();
        garraInteracaoComPowerUp.colocarNaPosicao(garraDto.CentroDaGarra.position);

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
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);
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
