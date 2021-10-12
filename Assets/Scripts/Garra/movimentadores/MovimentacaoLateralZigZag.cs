using UnityEngine;

public class MovimentacaoLateralZigZag : MovimentacaoDaGarraNormal
{    
    private int direcao;

    private float movimentoLateral;

    private float anguloAtual;
    private bool isUsandoMaxAngulo;
    
    private Quaternion anguloDesejadoEsquerdaMin;
    private Quaternion anguloDesejadoDireitaMin;

    private Quaternion anguloDesejadoEsquerdaMax;
    private Quaternion anguloDesejadoDireitaMax;

    private Quaternion anguloDesejadoEsquerdaAtual;
    private Quaternion anguloDesejadoDireitaAtual;    

    public MovimentacaoLateralZigZag()
    {
        anguloDesejadoDireitaMin = Quaternion.Euler(0, 0, -garra.garraDto.Angulos.IdleMin);
        anguloDesejadoEsquerdaMin = Quaternion.Euler(0, 0, garra.garraDto.Angulos.IdleMin);

        anguloDesejadoDireitaMax = Quaternion.Euler(0, 0, -garra.garraDto.Angulos.IdleMax);
        anguloDesejadoEsquerdaMax = Quaternion.Euler(0, 0, garra.garraDto.Angulos.IdleMax);        
        direcao = 1;        
    }

    public override void preInicio()
    {        
        configurarAngulosParaMax();
        dispararEventoDirecao(direcao);
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

        rotacionarPincaFDT(garra.garraDto.Velocidades.MovAnguloIdle, anguloDesejadoEsquerdaAtual, anguloDesejadoDireitaAtual);        
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
        anguloAtual = -garra.garraDto.Angulos.IdleMax;
        anguloDesejadoDireitaAtual = anguloDesejadoDireitaMax;
        anguloDesejadoEsquerdaAtual = anguloDesejadoEsquerdaMax;
    }

    private void configurarAngulosParaMin()
    {
        isUsandoMaxAngulo = false;
        anguloAtual = garra.garraDto.Angulos.IdleMin;
        anguloDesejadoDireitaAtual = anguloDesejadoDireitaMin;
        anguloDesejadoEsquerdaAtual = anguloDesejadoEsquerdaMin;
    }
}
