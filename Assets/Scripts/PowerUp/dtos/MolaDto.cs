using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MolaDto 
{
    [SerializeField] private float delayInicial;
    [Space(3)]
    [SerializeField] private GameObject molaGo;

    public float DelayInicial { get { return delayInicial;  } }
    public GameObject MolaGo { get { return molaGo; } }
}
