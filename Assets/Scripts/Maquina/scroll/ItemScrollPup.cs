using UnityEngine;

public class ItemScrollPup 
{
    public int indice { get; private set; }
    private SpriteRenderer spriteRenderer;

    public void addItemInfo(int indice, SpriteRenderer spriteRenderer)
    {
        this.indice = indice;
        this.spriteRenderer = spriteRenderer;
    }

    public float getPosEsquerda()
    {
        return spriteRenderer.transform.position.x;
    }

    public void print()
    {
        Debug.Log("Pos " + spriteRenderer.transform.position.x + 
            " | Bounds max " + spriteRenderer.bounds.max + 
            " | Local Pos " + spriteRenderer.transform.localPosition.x);
    }
    
}
