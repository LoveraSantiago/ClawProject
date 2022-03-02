using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaiola : GO
{
    public static GaiolaContexto contexto;

    public Gaiola() 
        : base(contexto, contexto.nomeador.getName()) {}

    protected override GOContexto getGOContext()
    {
        return contexto;
    }

    public static void configurar(ContextoDto contextoDto)
    {
        contexto = new GaiolaContexto(contextoDto);
    }
}
