using UnityEngine;

public class MovimentacaoLateralZigZag : MovimentacaoDaGarraNormal
{    
    private bool isUsandoMaxAngulo;
    
    private int direcao;
    private float movimentoLateral;    

    private Quaternion anguloDesejadoEsquerdaAtual;
    private Quaternion anguloDesejadoDireitaAtual;    

    public MovimentacaoLateralZigZag()
    {       
        direcao = 1;        
    }

    public override void preInicio()
    {        
        configurarAngulosParaMax();
        produziuEventoDeDirecao(direcao);
        acionarTriggerDasPincas();        
        moverHorizontalmenteFreeze(direcao);        
    }

    public override void update(InputGame inputGame)
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            produziuEventoDeDirecao(DirecaoDaGarra.PARADA);
            comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
            desafixar();
            acionarColliderDasPincas();
        }
    }
    
    public override void fixedUpdate()
    {        
        verificarSeMovimentacaoAtingiuLimites();
        verificarSePincaAtingiuLimites();
        rotacionarPincaVelocidadeIdleFDT(anguloDesejadoEsquerdaAtual, anguloDesejadoDireitaAtual);        
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
        else
        {
            //nada
        }
    }

    private void verificarSePincaAtingiuLimites()
    {
        if (isPincaDireitaNoAngulo(anguloDesejadoDireitaAtual))
        {
            if (isUsandoMaxAngulo)
            {
                configurarAngulosParaMin();
            }
            else
            {
                configurarAngulosParaMax();
            }
        }       
    }    

    private void configurarAngulosParaMax()
    {
        isUsandoMaxAngulo = true;        
        anguloDesejadoDireitaAtual  = angulosTemp.angIdleMaxDireita;
        anguloDesejadoEsquerdaAtual = angulosTemp.angIdleMaxEsquerda;
    }

    private void configurarAngulosParaMin()
    {
        isUsandoMaxAngulo = false;        
        anguloDesejadoDireitaAtual  = angulosTemp.angIdleMinDireita;
        anguloDesejadoEsquerdaAtual = angulosTemp.angIdleMinEsquerda;
    }
}
