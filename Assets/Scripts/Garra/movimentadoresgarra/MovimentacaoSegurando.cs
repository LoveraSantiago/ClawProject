using UnityEngine;

public class MovimentacaoSegurando : MovimentacaoDaGarra
{
    private const int ESTADO_VOLTAR_SUBIDA = 1;
    private const int ESTADO_IR_PARA_MEIO  = 2;

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
        }        
    }

    private void voltarPosicaoMeioCima()
    {
        if (!isGarraAcimaPosInicial())
        {
            subirGarraFDT();
        }
        else
        {
            diminuirInerciaDaGarra();
            colocarGarraNaAlturaInicial();
            estadoAtual = ESTADO_IR_PARA_MEIO;
        }
    }
}
