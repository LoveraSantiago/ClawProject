using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInfo
{
    public int duracaoTempo{ get; private set; }

    public void configurarDuracaoTempo(int duracao)
    {
        duracaoTempo = duracao;
    }
}
