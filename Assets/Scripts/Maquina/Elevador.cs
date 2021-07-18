using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : Consumidor<bool>
{
    private void acionarElevador()
    {

    }

    public void consumir(bool evento)
    {
        acionarElevador();
    }
}
