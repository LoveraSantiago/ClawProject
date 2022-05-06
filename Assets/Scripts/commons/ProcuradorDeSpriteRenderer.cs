using UnityEngine;

public class ProcuradorDeSpriteRenderer : Transformador<GameObject, SpriteRenderer>
{
    private string nomeComponente;

    public ProcuradorDeSpriteRenderer(string nomeComponente)
    {
        this.nomeComponente = nomeComponente;
    }

    public SpriteRenderer transformar(GameObject entrada)
    {
        return entrada.transform.Find(nomeComponente)
                       .GetComponent<SpriteRenderer>();
    }
}
