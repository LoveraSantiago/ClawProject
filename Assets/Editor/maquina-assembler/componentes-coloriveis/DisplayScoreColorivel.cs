using System.Collections.Generic;
using UnityEngine;

public class DisplayScoreColorivel 
{
    private FinderComponente finder;
    private GameObject goDisplayScore;

    public DisplayScoreColorivel(FinderComponente finder)
    {
        this.finder = finder;
        goDisplayScore = finder.findNaMaquina("display-score");
    }

    public ComponenteColorivel getPlacaGrupo()
    {
        GameObject goPlacaGrupo = finder.findNoComponente(goDisplayScore, ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO);
        return new SingleCompColorivel(goPlacaGrupo);
    }

    public ComponenteColorivel getPlacaIndividual1()
    {
        GameObject goPlaca = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1);
        return new SingleCompColorivel(goPlaca);
    }

    public ComponenteColorivel getPlacaIndividual2()
    {
        GameObject goPlaca = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2);
        return new SingleCompColorivel(goPlaca);
    }

    public ComponenteColorivel getPlacaIndividual3()
    {
        GameObject goPlaca = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3);
        return new SingleCompColorivel(goPlaca);
    }

    public ComponenteColorivel getGrupoLeds()
    {
        GameObject goPlaca1 = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1);
        List<GameObject> leds1 = getGrupoDeLedsFrom(goPlaca1);

        GameObject goPlaca2 = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2);
        List<GameObject> leds2 = getGrupoDeLedsFrom(goPlaca2);

        GameObject goPlaca3 = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3);
        List<GameObject> leds3 = getGrupoDeLedsFrom(goPlaca3);

        List<GameObject> leds = new List<GameObject>();
        leds.AddRange(leds1);
        leds.AddRange(leds2);
        leds.AddRange(leds3);
        return new MultipleCompColorivel(leds.ToArray()); 
    }       

    private GameObject getPlacaIndividual(string placaIndividual)
    {
        return finder.findNoComponente(goDisplayScore, placaIndividual); 
    }

    private List<GameObject> getGrupoDeLedsFrom(GameObject goPlacaIndividual)
    {
        List<GameObject> listLeds = new List<GameObject>();
        GameObject displayPontos = finder.findNoComponente(goPlacaIndividual, "display-pontosv2");
        for(int contadorFileira = 1; contadorFileira < 6; contadorFileira++)
        {
            string nomeFileira = "fileira" + contadorFileira;
            GameObject goFileira = finder.findNoComponente(displayPontos, nomeFileira);            
            for(int contadorLed = 0; contadorLed < goFileira.transform.childCount; contadorLed++)
            {   
                GameObject goLed = goFileira.transform.GetChild(contadorLed).gameObject;                
                listLeds.Add(goLed);
            }
        }
        return listLeds;
    }
}
