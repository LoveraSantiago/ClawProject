using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDetalheColetavel 
{
    private CanvasDetalheColetavelDto canvasDetalheDto;

    public CanvasDetalheColetavel(CanvasDetalheColetavelDto canvasDetalheDto)
    {
        this.canvasDetalheDto = canvasDetalheDto;
    }

    public void abrirDetalhe()
    {
        canvasDetalheDto.AnimatorCanvas.Play("abrir-detalhe");
    }    
}
