using UnityEngine;

public class MovimentacaoSegurando : MovimentacaoDaGarra
{
    private const int ESTADO_VOLTAR_SUBIDA = 1;
    private const int ESTADO_IR_MEIO_PELA_ESQUERDA  = 2;
    private const int ESTADO_IR_MEIO_PELA_DIREITA  = 3;
    private const int NONE  = 99;

    private int estadoAtual;
    private Vector3 posMeio;

    public MovimentacaoSegurando()
    {
        posMeio = new Vector3(0, posInicial.y, 0);
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
                
        }
        Debug.Log("EstadoAtual : " + estadoAtual);
    }

    private void voltarPosicaoMeioCima()
    {
        if (!isGarraAcimaPosInicial())
        {
            moverGarraParaCimaFDT();
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
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaPosInicial();
            estadoAtual = NONE;
        }
    }
}
