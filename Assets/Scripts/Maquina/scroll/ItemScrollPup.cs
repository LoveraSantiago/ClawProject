using UnityEngine;

public class ItemScrollPup 
{
    public int indice { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }

    public void addItemInfo(int indice, SpriteRenderer spriteRenderer)
    {
        this.indice = indice;
        this.spriteRenderer = spriteRenderer;
    }

    public float getPosEsquerda()
    {   
        return spriteRenderer.bounds.min.x;
    }

    public float getPosDireita()
    {
        return spriteRenderer.bounds.max.x;
    }

    public void print()
    {
        Debug.Log("Pos " + spriteRenderer.transform.position.x + 
            " | Bounds max " + spriteRenderer.bounds.max + 
            " | Local Pos " + spriteRenderer.transform.localPosition.x);
    }
    
}
