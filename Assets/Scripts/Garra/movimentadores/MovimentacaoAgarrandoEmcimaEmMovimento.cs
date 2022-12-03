using UnityEngine;

public class MovimentacaoAgarrandoEmcimaEmMovimento : AbstractMovimentacaoDaGarraPowerUp
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
}
