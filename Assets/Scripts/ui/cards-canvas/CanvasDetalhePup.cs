using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDetalhePup : AcaoCardPowerUpSelecionado.ConsumidorEvento
{
    private CanvasDetalheCardPupDto canvasDetalheDto;

    public CanvasDetalhePup(CanvasDetalheCardPupDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
    }

    void AcaoCardPowerUpSelecionado.ConsumidorEvento.consumirEvento(CardPupSelecionadoDto evento)
    {
        
    }
}
