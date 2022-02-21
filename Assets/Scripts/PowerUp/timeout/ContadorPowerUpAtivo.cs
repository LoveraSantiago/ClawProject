using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorPowerUpAtivo : ContadorTimeout
{
    private IntervaloDeTempo intervaloFimTempo;

    public ContadorPowerUpAtivo(int duracaoTempo)
    {
        intervaloFimTempo = new IntervaloDeTempo(duracaoTempo);
    }

    public void contarTimeout()
    {
        if (intervaloFimTempo.contarTempo())
        {

        }
    }
}
