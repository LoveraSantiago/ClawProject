using UnityEngine;

public class MovimentacaoAgarrandoEmcima : MovimentacaoDaGarra
{
    private const int ESTADO_VOLTAR_SUBIDA = 1;
    private const int ESTADO_IR_MEIO_PELA_ESQUERDA  = 2;
    private const int ESTADO_IR_MEIO_PELA_DIREITA  = 3;
    private const int ESTADO_CENTRALIZADO  = 4;
    private const int ESTADO_SOLTAR = 5;
    private const int NONE  = 99;

    private int estadoAtual;
    private Vector3 posMeio;

    private int direcao;

    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    private Quaternion anguloDesejadoEsquerdaFechado;
    private Quaternion anguloDesejadoDireitaFechado;

    private Quaternion anguloDesejadoAberturaEsquerda;
    private Quaternion anguloDesejadoAberturaDireita;

    public ProdutorDeEvento<Vector3> produtorEventoGarraCentralizada { get; private set; }

    private ContadorDeTempo contadorDeTempoPausa;

    public MovimentacaoAgarrandoEmcima()
    {
        posMeio = new Vector3(0, posInicial.y, 0);

        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);

        anguloDesejadoDireitaFechado  = Quaternion.Euler(0, 0, garraDto.AnguloFechamento);
        anguloDesejadoEsquerdaFechado = Quaternion.Euler(0, 0, -garraDto.AnguloFechamento);

        anguloDesejadoAberturaDireita = Quaternion.Euler(0, 0, -garraDto.AnguloAbertura);
        anguloDesejadoAberturaEsquerda = Quaternion.Euler(0, 0, garraDto.AnguloAbertura);

        produtorEventoGarraCentralizada = new ProdutorDeEvento<Vector3>();
        contadorDeTempoPausa = new ContadorDeTempo(0.4f);
        direcao = 1;
    }

    public override void preInicio()
    {
        estadoAtual = ESTADO_VOLTAR_SUBIDA;
        //colocarMassaNaGarra(30);
    }

    public override void update()
    {
        switch (estadoAtual)
        {
            case ESTADO_CENTRALIZADO:
                if (inputGame.aconteceuTapNaAreaSuperior())
                {                    
                    pararGarra();
                    contadorDeTempoPausa.resetContador();
                    estadoAtual = ESTADO_SOLTAR;
                }
                break;
        }
    }

    public override void fixedUpdate()
    {
        switch (estadoAtual)
        {
            case ESTADO_VOLTAR_SUBIDA:
                voltarPosicaoMeioCima();
                break;

            case ESTADO_IR_MEIO_PELA_DIREITA:
                voltarAoMeioVindoPelaDireita();
                break;

            case ESTADO_IR_MEIO_PELA_ESQUERDA:
                voltarAoMeioVindoPelaEsquerda();
                break;

            case ESTADO_CENTRALIZADO:
                movendoZigueZague();
                break;

            case ESTADO_SOLTAR:
                abrirPincas();
                break;
            case NONE:
                //pincas.rotacionarFDT(compDaGarra.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
                break;

        }
        //Debug.Log("EstadoAtual : " + estadoAtual);
    }

    private void voltarPosicaoMeioCima()
    {
        if (!isGarraAcimaPosInicial())
        {
            moverGarraParaCimaFreeze();
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            pararGarra();
            colocarGarraNaAlturaInicial();
            determinarDirecaoParaVoltarAoMeio();
            contadorDeTempoPausa.resetContador();
        }
    }

    private void determinarDirecaoParaVoltarAoMeio()
    {
        if (isGarraMaiorPosHorizontal(0))
        {
            estadoAtual = ESTADO_IR_MEIO_PELA_ESQUERDA;
        }
        else
        {
            estadoAtual = ESTADO_IR_MEIO_PELA_DIREITA;
        }
    }

    private void voltarAoMeioVindoPelaEsquerda()
    {
        if (contadorDeTempoPausa.contarTempoFDT())
        {
            if (!isGarraMenorPosHorizontal(0))
            {
                moverGarraHorizontalmenteFreeze(-1);
                pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
            }
            else
            {
                pararGarra();
                colocarGarraNaPosInicial();
                colocarEstadoCentralizado();                
            }
        }
    }

    private void voltarAoMeioVindoPelaDireita()
    {
        if (contadorDeTempoPausa.contarTempoFDT())
        {
            if (!isGarraMaiorPosHorizontal(0))
            {
                moverGarraHorizontalmenteFreeze(1);
                pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
            }
            else
            {
                pararGarra();
                colocarGarraNaPosInicial();
                colocarEstadoCentralizado();                
            }
        }
    }

    private void colocarEstadoCentralizado()
    {   
        produtorEventoGarraCentralizada.produziuEvento(garraDto.CentroDaGarra.transform.position);        
        pincas.acionarCollider();
        contadorDeTempoPausa.resetContador();
        estadoAtual = ESTADO_CENTRALIZADO;
    }

    private void movendoZigueZague()
    {
        if (contadorDeTempoPausa.contarTempoFDT())
        {
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaFechado, anguloDesejadoDireitaFechado);
            verificarSeMovimentacaoAtingiuLimites();

            moverGarraHorizontalmenteFreeze(direcao);            
        }
    }


    private void verificarSeMovimentacaoAtingiuLimites()//DUPLICIDADE COM MOVIMENTACAO LATERAL
    {
        if (isGarraMaiorPosHorizontal(LIMITE_LATERAL_TELA - 0.1f))//DIMINUINDO RANGE PQ O OBJETO SEGURADO PODE IMPEDIR DA GARRA CHEGAR NO LIMITE
        {
            direcao = -1;
            pararGarra();
            //produtorEventoDirecao.produziuEvento(DirecaoDaGarra.ESQUERDA);
        }
        else if (isGarraMenorPosHorizontal(-LIMITE_LATERAL_TELA + 0.1f))
        {            
            direcao = 1;
            pararGarra();            
            //produtorEventoDirecao.produziuEvento(DirecaoDaGarra.DIREITA);
        }
        else
        {
            //if (isGarraParada())
            //{
            //    moverGarraHorizontalmenteFreeze(direcao);
            //}
            //nada
        }
    }

    private void abrirPincas()
    {
        if (contadorDeTempoPausa.contarTempoDT())
        {
            pararGarra();
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoAberturaEsquerda, anguloDesejadoAberturaDireita);

        }
        else
        {
            Debug.Log("Esperando");
        }
    }
}
