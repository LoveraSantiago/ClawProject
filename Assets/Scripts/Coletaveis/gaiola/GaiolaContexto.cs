using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiolaContexto : GOContexto
{
    public Nomeador nomeador { get; private set; }

    public GaiolaContexto(ContextoDto contextoDto) 
        : base(contextoDto)
    {
        nomeador = new Nomeador();
    }
}
