using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MaquinaColoridaV2 : FinderComponente
{
    private GameObject goMaquina;
    private GameObject goCabo;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColoridaV2()
    {
        inicializarGos();

        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(ConstantesCoresMaquinaV2.PLACA_FRENTE , new SingleCompColorivel(findNaMaquina(ConstantesCoresMaquinaV2.PLACA_FRENTE)));
        dicionario.Add(ConstantesCoresMaquinaV2.BASE_CHAO    , new SingleCompColorivel(findNaMaquina(ConstantesCoresMaquinaV2.BASE_CHAO)));
        dicionario.Add(ConstantesCoresMaquinaV2.CHAO_DENTRO  , new SingleCompColorivel(findNaMaquina(ConstantesCoresMaquinaV2.CHAO_DENTRO)));
        dicionario.Add(ConstantesCoresMaquinaV2.CABO_DA_GARRA, new SingleCompLineRendererColorivel(goCabo));

        ColorivelVigas vigas = new ColorivelVigas(this);
        dicionario.Add(ConstantesCoresMaquinaV2.VIGAS, vigas.getVigas());

        ColorivelBarra barra = new ColorivelBarra(this);
        dicionario.Add(ConstantesCoresMaquinaV2.BARRA, barra.getBarra());

        ColorivelTimer timer = new ColorivelTimer(this);
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_PLACA_PRINCIPAL  , timer.getPlacaPrincipal());
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_PLACA_DIGITO     , timer.getPlacaDigitos());
        dicionario.Add(ConstantesCoresMaquinaV2.TIMER_DISPLAY_SEGMENTOS, timer.getSegmentos());

        ColorivelDisplayColetavel dispColetavel = new ColorivelDisplayColetavel(this);
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_GRUPO      , dispColetavel.getPlacaPrincipal());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL1, dispColetavel.getPlacaIndividual1());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL2, dispColetavel.getPlacaIndividual2());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_COLETADOS_PLACA_INDIVIDUAL3, dispColetavel.getPlacaIndividual3());

        DisplayScoreColorivel displayScore = new DisplayScoreColorivel(this);
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_GRUPO      , displayScore.getPlacaGrupo());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL1, displayScore.getPlacaIndividual1());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL2, displayScore.getPlacaIndividual2());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_PLACA_INDIVIDUAL3, displayScore.getPlacaIndividual3());
        dicionario.Add(ConstantesCoresMaquinaV2.DISPLAY_SCORE_LEDS             , displayScore.getGrupoLeds());

        ColorivelTubo tubo = new ColorivelTubo(this);
        dicionario.Add(ConstantesCoresMaquinaV2.TUBO_BORDA, tubo.getBorda());
        dicionario.Add(ConstantesCoresMaquinaV2.TUBO_BASE , tubo.getBase());

        ColorivelMesaJoystick mesa = new ColorivelMesaJoystick(this);
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA  , mesa.getMesaCima());
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO , mesa.getMesaBaixo());
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_SUPORTE    , mesa.getJoystickSuporte());
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_HASTE      , mesa.getJoystickHaste());
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_BOLA       , mesa.getJoystickBola());
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_BTN_SUPORTE, mesa.getJoystickBtnSuporte());
        dicionario.Add(ConstantesCoresMaquinaV2.JOYSTICK_BTN        , mesa.getJoystickBtn());
        dicionario.Add(ConstantesCoresMaquinaV2.ORIFICIO_FICHA      , mesa.getOrificioFicha());
        dicionario.Add(ConstantesCoresMaquinaV2.ORIFICIO_CARD       , mesa.getOrificioCard());
        dicionario.Add(ConstantesCoresMaquinaV2.ORIFICIO_SETA       , mesa.getOrificioTrianguloFicha());

        dicionario.Add(ConstantesCoresMaquinaV2.BTN_PUP_BASE_DIREITA , mesa.getBtnPupBaseDireita());
        dicionario.Add(ConstantesCoresMaquinaV2.BTN_PUP_TOPO_DIREITA , mesa.getBtnPupTopoDireita());
        dicionario.Add(ConstantesCoresMaquinaV2.BTN_PUP_BASE_ESQUERDA, mesa.getBtnPupBaseEsquerda());
        dicionario.Add(ConstantesCoresMaquinaV2.BTN_PUP_TOPO_ESQUERDA, mesa.getBtnPupTopoEsquerda());

        ColorivelScrollPups scrollPup = new ColorivelScrollPups(this);
        dicionario.Add(ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_EXTERNA , scrollPup.getPlacaExterna());
        dicionario.Add(ConstantesCoresMaquinaV2.SCROLL_PUP_PLACA_INTERNA , scrollPup.getPlacaInterna());
        dicionario.Add(ConstantesCoresMaquinaV2.SCROLL_PUP_SETAS_LATERAIS, scrollPup.getSetasLaterais());
        dicionario.Add(ConstantesCoresMaquinaV2.SCROLL_PUP_SETA_CIMA     , scrollPup.getSetaSuperior());

        ColorivelSimbolo simbolos = new ColorivelSimbolo(this);
        dicionario.Add(ConstantesCoresMaquinaV2.SIMBOLO_CIRC_EXTERNO, simbolos.getSimbolosExternos());
        dicionario.Add(ConstantesCoresMaquinaV2.SIMBOLO_CIRC_INTERNO, simbolos.getSimbolosInternos());
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

    public void gerarMapa()
    {
        string texto = "Dictionary<string, string> dicionario = new Dictionary<string, string>();" + Environment.NewLine;

        foreach (KeyValuePair<string, ComponenteColorivel> entry in dicionario)
        {
            texto += "dicionario.Add(\"" + entry.Key + "\", \"#" + ColorUtility.ToHtmlStringRGB(entry.Value.getCor()) + "\");" + Environment.NewLine;
        }
        Debug.Log(texto);
    }
}
