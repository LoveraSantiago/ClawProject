using UnityEngine;

public class MaterialGlow 
{
    private static readonly string propMaterial = "_corGlow";
    private Material material;

    public MaterialGlow(Material material)
    {
        this.material = material;
    }

    public void setCorNoMaterial(Color cor)
    {
        material.SetColor(propMaterial, cor);
    }    
}
