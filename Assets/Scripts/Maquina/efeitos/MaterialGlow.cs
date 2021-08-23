using UnityEngine;

public class MaterialGlow 
{
    private static readonly string propMaterial = "_corGlow";
    public Material material { get; private set; }

    public MaterialGlow(Material material)
    {
        this.material = material;
    }

    public void setCorNoMaterial(Color cor)
    {
        material.SetColor(propMaterial, cor);
    }    
}
