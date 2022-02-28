using UnityEngine;

public class GOContexto 
{
    public GameObject mainGO { get; private set; }
    public Material mainMaterial { get; private set; }
    public Transform mainGOParent { get; private set; }

    public GOContexto(GameObject mainGO, Transform transformMainTileParent)
    {
        this.mainGO = mainGO;
        mainMaterial = mainGO.GetComponent<SpriteRenderer>().sharedMaterial;
        this.mainGOParent = transformMainTileParent;
    }
}
