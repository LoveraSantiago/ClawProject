using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaiola : GO
{
    public Gaiola(GOContexto contextoGO, string nome) : base(contextoGO, nome)
    {
    }

    protected override GOContexto getGOContext()
    {
        throw new System.NotImplementedException();
    }
}
