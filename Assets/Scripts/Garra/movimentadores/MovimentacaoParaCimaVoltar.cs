using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoParaCimaVoltar : MovimentacaoDaGarraPowerUp
{
    public override void fixedUpdate()
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

        }
    }
}
