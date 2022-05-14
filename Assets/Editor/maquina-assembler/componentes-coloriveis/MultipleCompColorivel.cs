using UnityEngine;

public class MultipleCompColorivel : ComponenteColorivel
{
    private GameObject go;
    private SpriteRenderer[] sprRenderers;            

    public MultipleCompColorivel(GameObject[] gos)
    {
        go = gos[0];
        sprRenderers = new SpriteRenderer[gos.Length];

        for(int contador = 0; contador < gos.Length; contador++)
        {            
            sprRenderers[contador] = gos[contador].GetComponent<SpriteRenderer>();
        }        
    }   

    public void passarCor(Color cor)
    {
        for (int contador = 0; contador < sprRenderers.Length; contador++)
        {
            sprRenderers[contador].color = cor;
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
