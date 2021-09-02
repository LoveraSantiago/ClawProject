using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoIrParaCacaNiquel : MovimentacaoDaGarraCacaNiquel
{
    private MovimentacaoVoltarParaPosicao movVoltarPosCacaNiquel;

    public MovimentacaoIrParaCacaNiquel()
    {
        movVoltarPosCacaNiquel = new MovimentacaoVoltarParaPosicao(garraDto.PosCacaNiquel);
    }

    public override void fixedUpdate()
    {
        DirecaoDaGarra direcaoVoltar = movVoltarPosCacaNiquel.getDirecaoAtual();
        if(direcaoVoltar == DirecaoDaGarra.CENTRALIZADA)
        {
            comunicadorComGerMovimentacao.trocarParaAcaoParado();
        }
        else
        {
            movVoltarPosCacaNiquel.voltarVindoPelaDireita();
        }
    }
}
