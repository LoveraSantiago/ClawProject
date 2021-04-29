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
        anguloDesejadoDireitaMin = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaMin = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);

        anguloDesejadoDireitaMax = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMax);
        anguloDesejadoEsquerdaMax = Quaternion.Euler(0, 0, garraDto.AnguloIdleMax);

        posInicial = garraDto.RigidBody.transform.localPosition;
        direcao = 1;        
    }

    public override void preInicio()
    {        
        configurarAngulosParaMax();
        dispararEventoDirecao(direcao);

        colocarGarraNaAlturaInicial();        

        pincas.acionarTrigger();
        moverGarraHorizontalmenteFreeze(direcao);
    }

    public override void update()
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.PARADA);
            comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
            desafixarGarraHorizontalmente();
            pincas.acionarCollider();
        }
    }
    
    public override void fixedUpdate()
    {        
        verificarSeMovimentacaoAtingiuLimites();
        verificarSePincaAtingiuLimites();

        pincas.rotacionarFDT(garraDto.VelocAnguloIdle, anguloDesejadoEsquerdaAtual, anguloDesejadoDireitaAtual);        
    }

    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (isGarraMaiorPosHorizontal(LIMITE_LATERAL_TELA))            
        {
            direcao = -1;     
            moverGarraHorizontalmenteFreeze(direcao);            
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (isGarraMenorPosHorizontal(-LIMITE_LATERAL_TELA))
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

    private void verificarSePincaAtingiuLimites()
    {
        if (pincas.isDireitaNoAngulo(anguloDesejadoDireitaAtual))
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
        anguloAtual = -garraDto.AnguloIdleMax;
        anguloDesejadoDireitaAtual = anguloDesejadoDireitaMax;
        anguloDesejadoEsquerdaAtual = anguloDesejadoEsquerdaMax;
    }

    private void configurarAngulosParaMin()
    {
        isUsandoMaxAngulo = false;
        anguloAtual = garraDto.AnguloIdleMin;
        anguloDesejadoDireitaAtual = anguloDesejadoDireitaMin;
        anguloDesejadoEsquerdaAtual = anguloDesejadoEsquerdaMin;
    }
}
