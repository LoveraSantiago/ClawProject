using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MolaDto 
{
    [SerializeField] private GameObject molaGo;

    public GameObject MolaGo { get { return molaGo; } }
}
