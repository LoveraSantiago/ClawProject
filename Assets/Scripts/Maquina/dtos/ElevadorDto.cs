using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ElevadorDto 
{
    [SerializeField] private GameObject paredeHorizontal1;
    [SerializeField] private GameObject paredeHorizontal2;

    public GameObject ParedeHorizontal1 { get { return paredeHorizontal1; } }
    public GameObject ParedeHorizontal2 { get { return paredeHorizontal2; } }

}
