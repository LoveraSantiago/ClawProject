using UnityEngine;

public class FinderDeSprRenderer1Nivel : FinderDeSprRenderer
{
    private string nomeComponente;

    public FinderDeSprRenderer1Nivel(string nomeComponente)
    {
        this.nomeComponente = nomeComponente;
    }

    public SpriteRenderer transformar(GameObject entrada)
    {
        return entrada.transform.Find(nomeComponente)
                       .GetComponent<SpriteRenderer>();
    }
}
