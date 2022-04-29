using UnityEngine;

public class GOContexto 
{
    public GameObject mainGO { get; private set; }
    public Material mainMaterial { get; private set; }    

    public GOContexto(GameObject mainGO)
    {
        this.mainGO = mainGO;
        mainMaterial = mainGO.GetComponent<SpriteRenderer>().sharedMaterial;
    }
    
    protected GOContexto(
        GameObject mainGO, Transformador<GameObject, SpriteRenderer> getGoComSprRenderer)
    {
        this.mainGO = mainGO;
        mainMaterial = getGoComSprRenderer.transformar(mainGO).sharedMaterial;
    }

    public GOContexto(GameObject mainGO, GOContexto goContexto)
    {
        this.mainGO = mainGO;
        mainMaterial = goContexto.mainMaterial;
    }
}
