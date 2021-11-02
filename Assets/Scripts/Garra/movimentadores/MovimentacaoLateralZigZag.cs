public class MovimentacaoLateralZigZag : MovimentacaoDaGarraNormal
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
    }

    public override void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            produziuEventoDeDirecao(DirecaoDaGarra.PARADA);
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
