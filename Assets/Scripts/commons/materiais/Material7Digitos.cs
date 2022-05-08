using UnityEngine;

public class Material7Digitos 
{
    public Material material { get; private set; }

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
        material.SetColor("_cor_desligado", cor);
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
        material.SetVector("_digitos", digito);
    }
}
