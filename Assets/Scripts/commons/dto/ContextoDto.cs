using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ContextoDto 
{
    [SerializeField] private GameObject go;    

    public GameObject Go { get { return go; } }    
}
