using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static Vector3 posInicial;

    public MolaPowerUpGo() 
        : base(powerUpDto.MolaDto.MolaGo, "mola"){}

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {
        
    }

    public override void iniciarPup()
    {
        ligar();
        posInicial.y = powerUpDto.HalturaPupDraggavel;
        base.colocarNaPosicao(posInicial);
    }

    public override void resetPup()
    {
        
    }
}
