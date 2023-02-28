using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class BuracoNegroDto
{
    [SerializeField] private float delayEntreColetados;
    [SerializeField] private GameObject buracoNegroGo;

    public float DelayEntreColetados{get{return delayEntreColetados;}}
    public GameObject BuracoNegroGo { get { return buracoNegroGo; } }
}
