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

    public ComponenteColorivel getGrupoLeds1()
    {
        GameObject goPlaca = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1);
        List<GameObject> leds = getGrupoDeLedsFrom(goPlaca);
        return new MultipleCompColorivel(leds.ToArray()); 
    }

    public ComponenteColorivel getGrupoLeds2()
    {
        GameObject goPlaca = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2);
        List<GameObject> leds = getGrupoDeLedsFrom(goPlaca);
        return new MultipleCompColorivel(leds.ToArray());
    }

    public ComponenteColorivel getGrupoLeds3()
    {
        GameObject goPlaca = getPlacaIndividual(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3);
        List<GameObject> leds = getGrupoDeLedsFrom(goPlaca);
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
            Debug.Log("recuperando fileira " + nomeFileira);
            for(int contadorLed = 0; contadorLed < goFileira.transform.childCount; contadorLed++)
            {   
                GameObject goLed = goFileira.transform.GetChild(contadorLed).gameObject;
                Debug.Log("Led recuperado " + goLed.name);
                listLeds.Add(goLed);
            }
        }
        return listLeds;
    }
}
