public class MovimentacaoLateralZigZag : MovimentacaoDaGarraNormal
{    
    private int direcao;
    private MovimentacaoPincaZigZag movPincaZigZag;    

    public MovimentacaoLateralZigZag()
    {       
        direcao = 1;
        movPincaZigZag = new MovimentacaoPincaZigZag();
    }

    public override void preInicio()
    {        
        movPincaZigZag.preInicio();
        produziuEventoDeDirecao(direcao);
        acionarTriggerDasPincas();        
        moverHorizontalmenteFreeze(direcao);        
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
        verificarSeMovimentacaoAtingiuLimites();
        movPincaZigZag.fixedUpdate();     
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
