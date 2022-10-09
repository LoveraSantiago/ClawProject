using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetorDeDados 
{
    private ProvedorDadosTempo provedorDadosTempo;

    public ColetorDeDados addProvedorDadosTempo(ProvedorDadosTempo provedorDadosTempo)
    {
        this.provedorDadosTempo = provedorDadosTempo;
        return this;
    }

    public string coletar()
    {
        return provedorDadosTempo.getTempoPartida();
    }
}
