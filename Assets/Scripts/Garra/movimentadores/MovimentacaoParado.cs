using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoParado : MovimentacaoDaGarraPowerUp
{
    //TODO agrupar em um unico lugar os angulos desejados
    private Quaternion anguloDesejadoEsquerdaAntesEstadoInicial;
    private Quaternion anguloDesejadoDireitaAntesEstadoInicial;
    
    public MovimentacaoParado()
    {
        anguloDesejadoDireitaAntesEstadoInicial  = Quaternion.Euler(0, 0, -garraDto.AnguloIdleMin);
        anguloDesejadoEsquerdaAntesEstadoInicial = Quaternion.Euler(0, 0, garraDto.AnguloIdleMin);
    }

    public override void fixedUpdate()
    {
        pararGarra();
        pincas.rotacionarFDT(garraDto.VelocidadeAnguloFechamento, anguloDesejadoEsquerdaAntesEstadoInicial, anguloDesejadoDireitaAntesEstadoInicial);
    }
}
