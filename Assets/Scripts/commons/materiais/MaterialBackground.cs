using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBackground 
{
    

    public static void movimentarEntrada(Material material)
    {
        material.SetFloat("_tempoSubtracao", Time.time);
    }
}
