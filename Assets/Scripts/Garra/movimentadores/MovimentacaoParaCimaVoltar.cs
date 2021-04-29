using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoParaCimaVoltar : MovimentacaoDaGarra
{
    public override void fixedUpdate()
    {
        if (!isGarraAcimaPosInicial())
        {

        }
        else
        {
            pararGarra();
            colocarGarraNaAlturaInicial();

        }
    }
}
