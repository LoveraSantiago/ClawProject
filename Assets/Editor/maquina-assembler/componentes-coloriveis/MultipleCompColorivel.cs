using UnityEngine;

public class MultipleCompColorivel : ComponenteColorivel
{
    private GameObject go;
    private SpriteRenderer[] sprRenderers;    
    private Color corOriginal;
    

    public MultipleCompColorivel(GameObject[] gos)
    {
        go = gos[0];
        sprRenderers = new SpriteRenderer[gos.Length];

        for(int contador = 0; contador < gos.Length; contador++)
        {            
            sprRenderers[contador] = gos[contador].GetComponent<SpriteRenderer>();
        }
        corOriginal = sprRenderers[0].color;        
    }   

    public void passarCor(Color cor)
    {
        for (int contador = 0; contador < sprRenderers.Length; contador++)
        {
            sprRenderers[contador].color = cor;
        }
    }

    public void resetCor()
    {
        for (int contador = 0; contador < sprRenderers.Length; contador++)
        {
            sprRenderers[contador].color = corOriginal;
        }
    }

    public GameObject getGo()
    {
        return go;
    }

    public Color getCor()
    {
        return sprRenderers[0].color;
    }
}
