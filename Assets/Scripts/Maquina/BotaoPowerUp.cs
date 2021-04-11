using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;

    private Bounds boundExterno;
    private GameObject goBotaoExterno;
    private GameObject goBotaoInterno;

    public BotaoPowerUp(GameObject goBotao)
    {
        goBotaoExterno = goBotao;
        goBotaoInterno = goBotao.transform.Find("parte-dentro").gameObject;

        boundExterno = goBotaoExterno.GetComponent<SpriteRenderer>()
            .bounds;

        isDraggavel = false;
    }

    public void transformarEmBotaoDragavel()
    {
        isDraggavel = true;
    }

    public void transormarEmBotalClicavel()
    {
        isDraggavel = false;
    }

    private bool isPosicaoDentroAreaBotao(Vector2 posicao)
    {
        return boundExterno.Contains(posicao);        
    }

    public bool isCliqueDentroAreaBotao(Vector2 posicao)
    {
        return !isDraggavel && isPosicaoDentroAreaBotao(posicao);
    }

    public bool isDragDentroAreaBotao(Vector2 posicao)
    {
        return isDraggavel && isPosicaoDentroAreaBotao(posicao);
    }

    //IMPLEMENTANDO INTERFACE DRAGGAVEL INICIO
    public void updateDrag()
    {
        
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM
}
