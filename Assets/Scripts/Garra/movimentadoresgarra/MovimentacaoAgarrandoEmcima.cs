using UnityEngine;

public class MovimentacaoAgarrandoEmcima : MovimentacaoDaGarra
{
    private const int ESTADO_VOLTAR_SUBIDA = 1;
    private const int ESTADO_IR_MEIO_PELA_ESQUERDA  = 2;
    private const int ESTADO_IR_MEIO_PELA_DIREITA  = 3;
    private const int ESTADO_CENTRALIZADO  = 4;
    private const int NONE  = 99;

    private int estadoAtual;
    private Vector3 posMeio;

    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public ProdutorDeEvento<Vector3> produtorEventoGarraCentralizada { get; private set; }

    public MovimentacaoAgarrandoEmcima()
    {
        posMeio = new Vector3(0, posInicial.y, 0);

        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);

        produtorEventoGarraCentralizada = new ProdutorDeEvento<Vector3>();
    }

    public override void preInicio()
    {
        estadoAtual = ESTADO_VOLTAR_SUBIDA;
    }

    public override void update()
    {
        
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

                break;

            case NONE:
                //pincas.rotacionarFDT(compDaGarra.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
                break;

        }
        Debug.Log("EstadoAtual : " + estadoAtual);
    }

    private void voltarPosicaoMeioCima()
    {
        if (!isGarraAcimaPosInicial())
        {
            moverGarraParaCimaFDT();
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaAlturaInicial();
            determinarDirecaoParaVoltarAoMeio();
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
        if (!isGarraMenorPosHorizontal(0))
        {
            moverGarraHorizontalmenteFDT(-1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaPosInicial();
            estadoAtual = NONE;
        }
    }

    private void voltarAoMeioVindoPelaDireita()
    {
        if (!isGarraMaiorPosHorizontal(0))
        {
            moverGarraHorizontalmenteFDT(1);
            pincas.rotacionarFDT(garraDto.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaPosInicial();
            estadoAtual = NONE;
        }
    }

    private void colocarEstadoCentralizado()
    {
        produtorEventoGarraCentralizada.produziuEvento(garraDto.CentroDaGarra.transform.position);
        estadoAtual = ESTADO_CENTRALIZADO;
    }
}
