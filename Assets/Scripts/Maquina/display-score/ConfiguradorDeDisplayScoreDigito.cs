using System.Collections.Generic;
using UnityEngine;

public class ConfiguradorDeDisplayScoreDigito
{
    private DisplayScoreDigito displayCentena;
    private DisplayScoreDigito displayDezena;
    private DisplayScoreDigito displayUnidade;

    public ConfiguradorDeDisplayScoreDigito(
        DisplayScoreDigito displayCentena, DisplayScoreDigito displayDezena, DisplayScoreDigito displayUnidade)
    {
        this.displayCentena = displayCentena;
        this.displayDezena = displayDezena;
        this.displayUnidade = displayUnidade;
    }

    public void configurar(SpriteRenderer sprRendererPlacaGrupo, Dictionary<string, string> dicionarioDeCores)
    {
        ComponentePropriedadesDeDisplayScoreDigito.configurar();

        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1];
        string hexLed = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS];
        displayCentena.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2];        
        displayDezena.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3];        
        displayUnidade.configuradoPeloLevel(hexCor, hexLed);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO];
        sprRendererPlacaGrupo.color = Utils.getCorByHex(hexCor);
    }
}
