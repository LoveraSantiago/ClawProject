using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MaterialTipoPowerUpDto 
{
    [SerializeField] private Material material;
    [SerializeField] private Color corPrincipal;
    [SerializeField] private Color corEscura;
    [SerializeField] private Color corCirculo;
    [SerializeField] private Color corVariacao1;
    [SerializeField] private Color corVariacao2;
    [SerializeField] private Color corVariacao3;

    public Material Material { get { return material; } }
    public Color CorPrincipal { get { return corPrincipal; } }
    public Color CorEscura { get { return corEscura; } }
    public Color CorCirculo { get { return corCirculo; } }
    public Color CorVariacao1 { get { return corVariacao1; } }
    public Color CorVariacao2 { get { return corVariacao2; } }
    public Color CorVariacao3 { get { return corVariacao3; } }
}
