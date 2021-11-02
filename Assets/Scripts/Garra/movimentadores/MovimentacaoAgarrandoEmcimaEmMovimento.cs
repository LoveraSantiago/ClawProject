using UnityEngine;

public class MovimentacaoAgarrandoEmcimaEmMovimento : MovimentacaoDaGarraPowerUp
{
    
    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;

    private MovimentacaoDirecao movDirecao;

    public MovimentacaoAgarrandoEmcimaEmMovimento()
    {
        movDirecao = new MovimentacaoDirecao();
    }

    public override void preInicio()
    {
        configurarAngulos();
        acionarColliderDasPincas();
        interagirComPup();

        movDirecao.produziuEventoDeDirecao();//reesincronizarJoystick
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
        movDirecao.fixedUpdate();
        movDirecao.moverHorizontalmenteFreeze();
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
