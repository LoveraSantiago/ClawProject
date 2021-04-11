using UnityEngine;

public class BotaoPowerUp : Draggavel
{
    private bool isDraggavel;

    private Vector2 posicaoInicialDrag;
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
    public void prepararDraggagem(Vector3 posInicialDrag)
    {
        this.posicaoInicialDrag = posInicialDrag;
    }

    public void updateDrag(Vector2 posicaoAtual)
    {
        Vector2 delta = posicaoAtual - posicaoInicialDrag;
        posicaoInicialDrag = posicaoAtual;

        Vector3 posicaoCalculada = new Vector3(
            goBotaoInterno.transform.position.x + delta.x,
            goBotaoInterno.transform.position.y + delta.y, 
            goBotaoInterno.transform.position.z);

        goBotaoInterno.transform.position = posicaoCalculada;
    }
    //IMPLEMENTANDO INTERFACE DRAGGAVEL FIM    
}
