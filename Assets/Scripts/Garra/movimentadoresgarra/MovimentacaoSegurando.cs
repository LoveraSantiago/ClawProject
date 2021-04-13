using UnityEngine;

public class MovimentacaoSegurando : MovimentacaoDaGarra
{
    private const int ESTADO_VOLTAR_SUBIDA = 1;
    private const int ESTADO_IR_MEIO_PELA_ESQUERDA  = 2;
    private const int ESTADO_IR_MEIO_PELA_DIREITA  = 3;
    private const int NONE  = 99;

    private int estadoAtual;
    private Vector3 posMeio;

    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;

    public MovimentacaoSegurando()
    {
        posMeio = new Vector3(0, posInicial.y, 0);

        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -compDaGarra.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, compDaGarra.AnguloIdleMin);
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
            pincas.rotacionarFDT(compDaGarra.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaAlturaInicial();
            determinarDirecaoPAraVoltarAoMeio();
        }
    }

    private void determinarDirecaoPAraVoltarAoMeio()
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
            pincas.rotacionarFDT(compDaGarra.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
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
            pincas.rotacionarFDT(compDaGarra.VelocidadeAnguloAbertura, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaPosInicial();
            estadoAtual = NONE;
        }
    }
}
