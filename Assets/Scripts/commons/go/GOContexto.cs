using UnityEngine;

public class GOContexto 
{
    public GameObject mainGO { get; private set; }    

    public GOContexto(GameObject mainGO)
    {
        this.mainGO = mainGO;        
    }
}
