using UnityEngine;

public class SegmentoTimerHdr
{
    public Material originalMaterial { get; private set; }
    private Material[] materiaisSegmentosHdr;

    public SegmentoTimerHdr(Material materialEmpty, SpriteRenderer[] segmentos)
    {
        materiaisSegmentosHdr = new Material[segmentos.Length];
        for(int contador = 0; contador < segmentos.Length; contador++)
        {
            Material materialHdr = new Material(materialEmpty);
            materialHdr.SetTexture("MainTexture", segmentos[contador].sprite.texture);
            materiaisSegmentosHdr[contador] = materialHdr;
        }

        originalMaterial = segmentos[0].material;
    }

    public Material getMaterialSegmento(int indice)
    {
        return materiaisSegmentosHdr[indice];
    }
}
