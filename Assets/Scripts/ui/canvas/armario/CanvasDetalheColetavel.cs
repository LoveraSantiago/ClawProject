using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDetalheColetavel : AcaoItemArmarioSelecionado.ConsumidorEvento
{
    private CanvasDetalheColetavelDto canvasDetalheDto;

    public CanvasDetalheColetavel(CanvasDetalheColetavelDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
    }

    void AcaoItemArmarioSelecionado.ConsumidorEvento.consumirEvento(IndiceArmarioSelecionadoDto evento)
    {
        canvasDetalheDto.AnimatorCanvas.Play("abrir-detalhe");
    }
}
