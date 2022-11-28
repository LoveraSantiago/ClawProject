using System.Collections.Generic;
using UnityEngine;

public class ConfiguradorDeDisplayTimers 
{
    private DisplayTimerDto displayDto;
    private DisplayTimerDigitos displayTimerDigitos;

    public ConfiguradorDeDisplayTimers(DisplayTimerDto displayDto, DisplayTimerDigitos displayTimerDigito)
    {
        this.displayDto = displayDto;
        this.displayTimerDigitos = displayTimerDigito;
    }

    public void configurarPeloLevel(Materiais7SegmentosDto materiais7SegsDto)
    {
        Dictionary<string, string> dicionarioDeCores = ContextoEstaticoUtils.level.getDicionarioDeCores();
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL];
        SpriteRenderer placaTimer = displayDto.SprRendererPlacaGrupo;
        placaTimer.color = CorUtils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS];
        Color corDigito = CorUtils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO];
        Color corPlaca = CorUtils.getCorByHex(corDigitosHex);

        bool isAlbedo0Level = ContextoEstaticoUtils.level.isLevelAlbedo0Timers();
        Material materialDisplay = materiais7SegsDto.getMaterialFromAlbedo(isAlbedo0Level);
        passarCoresAosDisplaysDigitos(materialDisplay, corDigito, corPlaca);        

        DisplayTimerDigito2Pontos displayTimer2Pontos = displayTimerDigitos.getDisplayTimer2Segmentos();
        bool isAlbedo0Timer2Pontos = ContextoEstaticoUtils.level.isLevelAlbedo0Timer2Pontos();
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
