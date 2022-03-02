using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class ContextoDto 
{
    [SerializeField] private GameObject go;
    [SerializeField] private Transform parentGo;

    public GameObject Go { get { return go; } }
    public Transform ParentGo { get { return parentGo; } }
}
