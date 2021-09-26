using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorOrdenadoDeColetaveis 
{
    private BoardOrdem[] ordem;

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if (level.isOrdemLevel())
        {
            ordem = level.getBoardOrdem();
            for(int contador = 0; contador < ordem.Length; contador++)
            {

            }
        }
    }
}
