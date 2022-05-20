using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaquinaEfeitoGlowDto 
{
    [Space(3)]
    [SerializeField] private float factorHdr;
    [SerializeField] private GameObject goEfeito;
    [Space(3)]
    [SerializeField] private Material[] materialLayers = new Material[4];

    public float FactorHdr { get { return factorHdr; } }
    public GameObject GoEfeito { get { return goEfeito; } }
    public Material[] MaterialLayers { get { return materialLayers; } }
}
