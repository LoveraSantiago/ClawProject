using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class CorHdrEfeitoDto 
{
    [SerializeField] private Color corMaterial;
    [SerializeField] private float hdrMaterial;

    public Color CorMaterial { get { return corMaterial; } }
    public float HdrMaterial { get { return hdrMaterial; } }
}
