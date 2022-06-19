using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaterialTipoPowerUpDto 
{
    [SerializeField] private Material material;
    [SerializeField] private Color corPrincipal;
    [SerializeField] private Color corEscura;
    [SerializeField] private Color corCirculo;

    public Material Material { get { return material; } }
    public Color CorPrincipal { get { return corPrincipal; } }
    public Color CorEscura { get { return corEscura; } }
    public Color CorCirculo { get { return corCirculo; } }
}
