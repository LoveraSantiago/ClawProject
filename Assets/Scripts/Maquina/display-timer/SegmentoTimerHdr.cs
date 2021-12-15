using UnityEngine;

public class SegmentoTimerHdr
{
    public Material originalMaterial { get; private set; }
    private Material[] materiaisSegmentosHdr;

    public SegmentoTimerHdr(DisplayTimerDto displayTimerDto)
    {
        configurarMateriais(displayTimerDto.SingleDisplay[0].Segmentos);
        configurarMaterialMiniDisplay(displayTimerDto.SprRendererMiniSegmentos);        
    }

    private void configurarMateriais(SpriteRenderer[] segmentosDisplays)
    {
        materiaisSegmentosHdr = new Material[segmentosDisplays.Length];
        for (int contador = 0; contador < segmentosDisplays.Length; contador++)
        {
            Material materialHdr = MaterialHdr.of(segmentosDisplays[contador].sprite);
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
