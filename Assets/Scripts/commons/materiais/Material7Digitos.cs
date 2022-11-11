using UnityEngine;

public class Material7Digitos 
{
    public Material material { get; private set; }
    private static readonly int ID_DIGITOS       = Shader.PropertyToID("_digitos");
    private static readonly int ID_COR_DESLIGADO = Shader.PropertyToID("_cor_desligado");

    public Material7Digitos(Material material)
    {
        this.material = new Material(material);
    }

    public Material7Digitos(SpriteRenderer spriteRenderer)
    {
        this.material = spriteRenderer.sharedMaterial;
    }

    public void addCorDesligado(Color cor)
    {
        material.SetColor(ID_COR_DESLIGADO, cor);
    }

    public void addDigito(int digito)
    {
        Vector4 digitosVetor = Digitos7Segmentos.getSegmentosDigito(digito);
        addDigito(digitosVetor);
    }

    public void desligarDigitos()
    {
        addDigito(Digitos7Segmentos.getSegmentosOff());
    }

    private void addDigito(Vector4 digito)
    {
        material.SetVector(ID_DIGITOS, digito);
    }
}
