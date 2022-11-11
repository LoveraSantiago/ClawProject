using UnityEngine;

public class MaterialGlow 
{    
    private static readonly int ID_COR_GLOW = Shader.PropertyToID("_corGlow");
    public Material material { get; private set; }

    public MaterialGlow(Material material)
    {
        this.material = material;
    }

    public void setCorNoMaterial(Color cor)
    {
        material.SetColor(ID_COR_GLOW, cor);
    }    
}
