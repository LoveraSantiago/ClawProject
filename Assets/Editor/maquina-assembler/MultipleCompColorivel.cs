using UnityEngine;

public class MultipleCompColorivel : ComponenteColorivel
{
    private string[] nomes;
    private SpriteRenderer[] sprRenderers;    
    private Color corOriginal;
    

    public MultipleCompColorivel(GameObject[] gos)
    {
        nomes = new string[gos.Length];
        sprRenderers = new SpriteRenderer[gos.Length];

        for(int contador = 0; contador < gos.Length; contador++)
        {
            nomes[contador] = gos[contador].name;
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
}
