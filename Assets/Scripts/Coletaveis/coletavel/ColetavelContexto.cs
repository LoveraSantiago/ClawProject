using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelContexto
{
    public Nomeador nomeador { get; private set; }

    public void configurar(ColetaveisDto coletaveisDto)
    {
        nomeador = new Nomeador();
    }
}
