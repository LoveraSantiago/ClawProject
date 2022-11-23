using UnityEngine;

public class MovimentacaoLateralZigZag : AbstractMovimentacaoDaGarraNormal
{    
    private MovimentacaoDirecao movDirecao;
    private MovimentacaoPincaZigZag movPincaZigZag;

    public MovimentacaoLateralZigZag()
    {
        movDirecao     = new MovimentacaoDirecao();
        movPincaZigZag = new MovimentacaoPincaZigZag();
    }

    public override void preInicio()
    {        
        movPincaZigZag.preInicio();
        movDirecao.produziuEventoDeDirecao();
        acionarTriggerDasPincas();
        movDirecao.moverHorizontalmenteFreeze();
        stopSomGarraMovimentoVertical();
    }

    public override void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            //Debug.Log("TAP SUPERIOR GARRA");
            produziuEventoDeDirecao(Direcao.PARADA);
            desafixar();
            acionarColliderDasPincas();
            comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
        }
    }
    
    public override void fixedUpdate()
    {        
        movDirecao.fixedUpdate();
        movPincaZigZag.fixedUpdate();     
    }
}
