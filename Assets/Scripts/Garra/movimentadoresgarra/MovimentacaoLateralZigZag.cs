using UnityEngine;

public class MovimentacaoLateralZigZag : MovimentacaoDaGarraHorizontal
{    
    private float movimentoLateral;        
    private float direcao;

    private bool isUsandoMaxAngulo;
    private float anguloAtual;

    private Vector2 posicaoInicial;
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

        posicaoInicial = compDaGarra.RigidBody.transform.localPosition;
        direcao = 1;        
    }

    public override void preInicio()
    {
        desligarAtracaoNoObjeto();
        configurarAngulosParaMax();
        dispararEventoDirecao();

        compDaGarra.RigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public override void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector2 posicaoInicial = compDaGarra.RigidBody.transform.localPosition;            
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.PARADA);
            comunicadorComGerMovimentacao.trocarParaAcaoDescendo(posicaoInicial);
            compDaGarra.RigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    
    public override void fixedUpdate()
    {        
        verificarSeMovimentacaoAtingiuLimites();
        verificarSePincaAtingiuLimites();

        pincas.fixUpdateRotacionamento(compDaGarra.VelocAnguloIdle, anguloDesejadoEsquerdaAtual, anguloDesejadoDireitaAtual);
        
        compDaGarra.RigidBody.velocity = new Vector2(
            direcao * compDaGarra.VelocMovHorizontal * Time.fixedDeltaTime,
            compDaGarra.RigidBody.velocity.y);
    }

    private void verificarSeMovimentacaoAtingiuLimites()
    {
        if (compDaGarra.RigidBody.transform.localPosition.x > LIMITE_LATERAL_TELA)
        {
            direcao = -1;     
            diminuirInerciaDaGarra();
            produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (compDaGarra.RigidBody.transform.localPosition.x < -LIMITE_LATERAL_TELA)
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
