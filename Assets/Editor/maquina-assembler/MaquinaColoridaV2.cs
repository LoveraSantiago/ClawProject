using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColoridaV2 : FinderComponente
{
    private GameObject goMaquina;
    private GameObject goCabo;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColoridaV2()
    {
        inicializarGos();

        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(ConstantesCoresMaquinaV2.PLACA_FRENTE, new SingleCompColorivel(findNaMaquina(ConstantesCoresMaquinaV2.PLACA_FRENTE)));
        dicionario.Add(ConstantesCoresMaquinaV2.BASE_CHAO, new SingleCompColorivel(findNaMaquina(ConstantesCoresMaquinaV2.BASE_CHAO)));

        VigasColoriveis vigas = new VigasColoriveis(this);
        dicionario.Add(ConstantesCoresMaquinaV2.VIGAS, vigas.getVigas());

        TimerColorivel timer = new TimerColorivel(this);
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL, timer.getPlacaPrincipal());
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO, timer.getPlacaDigitos());
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS, timer.getSegmentos());

        DisplayColetavelColorivel dispColetavel = new DisplayColetavelColorivel(this);
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO, dispColetavel.getPlacaPrincipal());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1, dispColetavel.getPlacaIndividual1());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL2, dispColetavel.getPlacaIndividual2());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL3, dispColetavel.getPlacaIndividual3());

        DisplayScoreColorivel displayScore = new DisplayScoreColorivel(this);
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO, displayScore.getPlacaGrupo());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1, displayScore.getPlacaIndividual1());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2, displayScore.getPlacaIndividual2());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3, displayScore.getPlacaIndividual3());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS1, displayScore.getGrupoLeds1());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS2, displayScore.getGrupoLeds2());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS3, displayScore.getGrupoLeds3());
    }

    private void inicializarGos()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            if (gos[contador].name == "main-object")
            {
                goMaquina = findNoComponente(gos[contador], "maquina-v3");                
                goCabo = findNoComponente(gos[contador], "cabo-da-garra");
                return;
            }
        }
        Debug.LogError("Cena nao contem game object maquina");
    }

    public GameObject findNaMaquina(string nome)
    {
        return goMaquina.transform.Find(nome).gameObject;
    }

    public GameObject findNoComponente(GameObject go, string nome)
    {
        return go.transform.Find(nome).gameObject;
    }

    public void colorir(string nome, Color cor)
    {
        dicionario[nome].passarCor(cor);
    }

    public void select(string nome)
    {
        Selection.activeGameObject = dicionario[nome].getGo();
    }

    public void reset(string nome)
    {
        dicionario[nome].resetCor();
    }
}
