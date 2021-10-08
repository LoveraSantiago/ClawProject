using UnityEngine;

public class SegmentoTimerHdr
{
    public Material originalMaterial { get; private set; }
    private Material[] materiaisSegmentosHdr;

    public SegmentoTimerHdr(DisplayTimerDto displayTimerDto)
    {
        configurarMateriais(displayTimerDto.MaterialEmptyTimer, displayTimerDto.SingleDisplay[0].Segmentos);
        configurarMaterialMiniDisplay(displayTimerDto.SprRendererMiniSegmentos);        
    }

    private void configurarMateriais(Material materialEmpty, SpriteRenderer[] segmentosDisplays)
    {
        materiaisSegmentosHdr = new Material[segmentosDisplays.Length];
        for (int contador = 0; contador < segmentosDisplays.Length; contador++)
        {
            Material materialHdr = new Material(materialEmpty);
            materialHdr.SetTexture("MainTexture", segmentosDisplays[contador].sprite.texture);
            materiaisSegmentosHdr[contador] = materialHdr;
        }

        originalMaterial = segmentosDisplays[0].material;
    }

    private void configurarMaterialMiniDisplay(SpriteRenderer[] segmentosMiniDisplay)
    {        
        segmentosMiniDisplay[0].material = materiaisSegmentosHdr[1];
        segmentosMiniDisplay[1].material = materiaisSegmentosHdr[2];
    }

    public Material getMaterialSegmento(int indice)
    {
        return materiaisSegmentosHdr[indice];
    }
}
