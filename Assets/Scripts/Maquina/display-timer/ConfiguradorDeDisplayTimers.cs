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

    public void configurarPeloLevel(Materiais7SegmentosDto materiais7SegsDto, AbstractLevel levelEscolhido)
    {
        Dictionary<string, string> dicionarioDeCores = levelEscolhido.getDicionarioDeCores();
        string corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL];
        SpriteRenderer placaTimer = displayDto.SprRendererPlacaGrupo;
        placaTimer.color = Utils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS];
        Color corDigito = Utils.getCorByHex(corDigitosHex);

        corDigitosHex = dicionarioDeCores[ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO];
        Color corPlaca = Utils.getCorByHex(corDigitosHex);

        bool isAlbedo0Level = levelEscolhido.isLevelAlbedo0Timers();
        Material materialDisplay = materiais7SegsDto.getMaterialFromAlbedo(isAlbedo0Level);
        passarCoresAosDisplaysDigitos(materialDisplay, corDigito, corPlaca);        

        DisplayTimerDigito2Pontos displayTimer2Pontos = displayTimerDigitos.getDisplayTimer2Segmentos();
        bool isAlbedo0Timer2Pontos = levelEscolhido.isLevelAlbedo0Timer2Pontos();
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
