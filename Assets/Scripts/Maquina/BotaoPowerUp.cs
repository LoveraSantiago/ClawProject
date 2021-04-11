using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPowerUp 
{
    private Bounds boundExterno;

    private GameObject goBotaoExterno;
    private GameObject goBotaoInterno;

    public BotaoPowerUp(GameObject goBotao)
    {
        goBotaoExterno = goBotao;
        goBotaoInterno = goBotao.transform.Find("parte-dentro").gameObject;

        boundExterno = goBotaoExterno.GetComponent<SpriteRenderer>()
            .bounds;
    }

    public bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return boundExterno.Contains(posicao);        
    }
}
