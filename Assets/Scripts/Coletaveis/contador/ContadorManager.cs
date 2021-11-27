using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorManager 
{
    private AbstractContadorDeColetaveis contador;
    private ColetaveisDto coletaveisDto;

    public ContadorManager(ColetaveisDto coletaveisDto)
    {
        this.coletaveisDto = coletaveisDto;
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if (level.isOrdemLevel())
        {
            contador = new ContadorDeColetaveisOrdenado(coletaveisDto.EfeitoOutline);
        }
        else
        {
            contador = new ContadorDeColetaveis(coletaveisDto.PontosColetados, coletaveisDto.PontosAcerto);
        }
    }
}
