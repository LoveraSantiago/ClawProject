using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenteEfeitoDeMovimentacaoGarra : ComponenteAngulosPincaDeMovimentacaoGarra
{
    protected void ligarTrailParaCima()
    {
        getGarra().efeito.ligarTrailPCima();//deveria estar aqui?
    }

    protected void ligarTrailParaBaixo()
    {
        getGarra().efeito.ligarTrailPBaixo();
    }

    protected void desligarTrail()
    {
        getGarra().efeito.desligarTrail();
    }
}
