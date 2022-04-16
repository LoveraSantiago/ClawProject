using System.Collections.Generic;
using UnityEngine;

public class ColoridorTimerV2 
{
    private DisplayTimerDto displayDto;
    private DisplayTimerDigitos displayTimerDigitos;

    public ColoridorTimerV2(DisplayTimerDto displayDto, DisplayTimerDigitos displayTimerDigito)
    {
        this.displayDto = displayDto;
        this.displayTimerDigitos = displayTimerDigito;
    }

    public void colorir(AbstractLevel levelEscolhido)
    {
        colorir(levelEscolhido.isLevelAlbedo0(), levelEscolhido.isLevelAlbedo0Timer2Pontos(), levelEscolhido.getDicionarioDeCores());
    }

    public void colorir(bool isAlbedo0Level, bool isAlbedo0Timer2Pontos, Dictionary<string, string> dicionarioDeCores)
    {   
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL];
        SpriteRenderer placaTimer = displayDto.SprRendererPlacaGrupo;
        placaTimer.color = Utils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS];
        Color corDigito = Utils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO];
        Color corPlaca = Utils.getCorByHex(corDigitosHex);

        Material materialDisplay = getMaterialSegmentos(isAlbedo0Level);
        passarCoresAosDisplaysDigitos(materialDisplay, corDigito, corPlaca);        

        DisplayTimerDigito2Pontos displayTimer2Pontos = displayTimerDigitos.getDisplayTimer2Segmentos();
        Material materialDisplay2Pontos = getMaterialSegmentos2Pontos(isAlbedo0Timer2Pontos);
        displayTimer2Pontos.configuradoPeloLevel(materialDisplay2Pontos, corDigito);
    }

    private void passarCoresAosDisplaysDigitos(Material materialDisplay, Color corDigito, Color corPlaca)
    {
        CorDisplayTimerDto coresDisplay = new CorDisplayTimerDto(corDigito, corPlaca);

        for (int contador = 0; contador < displayTimerDigitos.getQtdDisplaysDigitos(); contador++)
        {
            DisplayTimerDigito displayTimerDigito = displayTimerDigitos.getDisplayTimer(contador);
            displayTimerDigito.configuradoPeloLevel(materialDisplay, displayDto.SingleDisplay[contador], coresDisplay);
        }
    }    

    private Material getMaterialSegmentos(bool isAlbedo0)
    {
        if (isAlbedo0)
        {
            return displayDto.MatSegmentosAditivos;
        }
        else
        {
            return displayDto.MatSegmentosAlpha;
        }
    }

    private Material getMaterialSegmentos2Pontos(bool isAlbedo0)
    {
        if (isAlbedo0)
        {
            return MaterialHdr.ofAditivo();
        }
        else
        {
            return MaterialHdr.ofAlpha();
        }
    }
}
