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

    public void configurar(DisplayDeScoreDto displayDeScoresDto, AbstractLevel levelEscolhido)
    {
        Material materialEfeitoLed = getMaterialLedToLevel(displayDeScoresDto, levelEscolhido);
        Material materialDefaultLed= displayDeScoresDto.SingleDisplayScoreDto[0].Fileira1[0].sharedMaterial;

        Dictionary<string, string> dicionarioDeCores = levelEscolhido.getDicionarioDeCores();
        string hexLed = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS];
        Color corOriginalDoLed = CorUtils.getCorByHex(hexLed);

        DisplayScoreDigito.configurar(materialEfeitoLed, materialDefaultLed, corOriginalDoLed);

        string hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1];
        displayCentena.configuradoPeloLevel(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2];        
        displayDezena.configuradoPeloLevel(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3];        
        displayUnidade.configuradoPeloLevel(hexCor);

        hexCor = dicionarioDeCores[ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO];
        SpriteRenderer sprRendererPlacaGrupo = displayDeScoresDto.SprRendererPlacaGrupo;
        sprRendererPlacaGrupo.color = CorUtils.getCorByHex(hexCor);
    }

    private Material getMaterialLedToLevel(DisplayDeScoreDto displayDeScoresDto, AbstractLevel levelEscolhido)
    {
        if (levelEscolhido.isLevelAlbedo0Scores())
        {
            return displayDeScoresDto.MaterialEfeitoLedAditivo;
        }
        else
        {
            return displayDeScoresDto.MaterialEfeitoLedAlpha;
        }
    }
}
