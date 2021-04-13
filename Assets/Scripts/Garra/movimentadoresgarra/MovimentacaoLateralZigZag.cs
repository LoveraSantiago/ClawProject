using UnityEngine;

public class MovimentacaoLateralZigZag : MovimentacaoDaGarraHorizontal
{    
    private float movimentoLateral;        
    private int direcao;

    private bool isUsandoMaxAngulo;
    private float anguloAtual;
    
    private Quaternion anguloDesejadoEsquerdaMin;
    private Quaternion anguloDesejadoDireitaMin;

    private Quaternion anguloDesejadoEsquerdaMax;
    private Quaternion anguloDesejadoDireitaMax;

    private Quaternion anguloDesejadoEsquerdaAtual;
    private Quaternion anguloDesejadoDireitaAtual;    

    public MovimentacaoLateralZigZag()
    {
        anguloDesejadoDireitaMin = Quaternion.Euler(0, 0, -compDaGarra.AnguloIdleMin);
        anguloDesejadoEsquerdaMin = Quaternion.Euler(0, 0, compDaGarra.AnguloIdleMin);

        anguloDesejadoDireitaMax = Quaternion.Euler(0, 0, -compDaGarra.AnguloIdleMax);
        anguloDesejadoEsquerdaMax = Quaternion.Euler(0, 0, compDaGarra.AnguloIdleMax);

        posInicial = compDaGarra.RigidBody.transform.localPosition;
        direcao = 1;        
    }

    public override void preInicio()
    {        
        configurarAngulosParaMax();
        dispararEventoDirecao();

        colocarGarraNaAlturaInicial();
        compDaGarra.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        pincas.acionarTrigger();
    }

    public override void update()
    {
        if (inputGame.aconteceuTapNaAreaSuperior())
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.PARADA);
            comunicadorComGerMovimentacao.trocarParaAcaoDescendo();
            compDaGarra.RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            pincas.acionarCollider();
        }
    }
    
    public override void fixedUpdate()
    {        
        verificarSeMovimentacaoAtingiuLimites();
        verificarSePincaAtingiuLimites();

        pincas.rotacionarFDT(compDaGarra.VelocAnguloIdle, anguloDesejadoEsquerdaAtual, anguloDesejadoDireitaAtual);

        moverGarraHorizontalmenteFDT(direcao);        
    }

    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (isGarraMaiorPosHorizontal(LIMITE_LATERAL_TELA))            
        {
            direcao = -1;     
            diminuirInerciaDaGarra();
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (isGarraMenorPosHorizontal(-LIMITE_LATERAL_TELA))
        {
            direcao = 1;     
            diminuirInerciaDaGarra();
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

    private void dispararEventoDirecao()
    {
        if(direcao == 1)
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
    }

    private void configurarAngulosParaMax()
    {
        isUsandoMaxAngulo = true;
        anguloAtual = -compDaGarra.AnguloIdleMax;
        anguloDesejadoDireitaAtual = anguloDesejadoDireitaMax;
        anguloDesejadoEsquerdaAtual = anguloDesejadoEsquerdaMax;
    }

    private void configurarAngulosParaMin()
    {
        isUsandoMaxAngulo = false;
        anguloAtual = compDaGarra.AnguloIdleMin;
        anguloDesejadoDireitaAtual = anguloDesejadoDireitaMin;
        anguloDesejadoEsquerdaAtual = anguloDesejadoEsquerdaMin;
    }
}
