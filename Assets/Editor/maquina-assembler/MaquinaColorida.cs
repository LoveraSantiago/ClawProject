using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColorida 
{
    private GameObject goMaquina;
    private GameObject goCabo;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColorida()
    {
        inicializarGos();
        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(ConstantesCoresMaquina.PLACA_CIMA,    new SingleCompColorivel(find(ConstantesCoresMaquina.PLACA_CIMA)));
        dicionario.Add(ConstantesCoresMaquina.BASE_PARTE,    new MultipleCompColorivel(new GameObject[] { find(ConstantesCoresMaquina.BASE_PARTE + "-cima"), find(ConstantesCoresMaquina.BASE_PARTE + "-baixo")}));
        dicionario.Add(ConstantesCoresMaquina.BASE_CHAO,     new SingleCompColorivel(find(ConstantesCoresMaquina.BASE_CHAO)));
        dicionario.Add(ConstantesCoresMaquina.BORDA_VIDRO,   new SingleCompColorivel(find(ConstantesCoresMaquina.BORDA_VIDRO)));
        dicionario.Add(ConstantesCoresMaquina.PLACA_FRONTAL, new SingleCompColorivel(find(ConstantesCoresMaquina.PLACA_FRONTAL)));
        dicionario.Add(ConstantesCoresMaquina.PLACA_SAIDA,   new SingleCompColorivel(find(ConstantesCoresMaquina.PLACA_SAIDA)));
        dicionario.Add(ConstantesCoresMaquina.BARRA,         new SingleCompColorivel(find(ConstantesCoresMaquina.BARRA)));
        dicionario.Add(ConstantesCoresMaquina.CHAO_DENTRO,   new SingleCompColorivel(find(ConstantesCoresMaquina.CHAO_DENTRO)));
        dicionario.Add(ConstantesCoresMaquina.TUBO,          new SingleCompColorivel(find(ConstantesCoresMaquina.TUBO), 0.88f));
        dicionario.Add(ConstantesCoresMaquina.VIGA_TRAS,     new MultipleCompColorivel(new GameObject[] { find(ConstantesCoresMaquina.VIGA_TRAS + "-esquerda"), find(ConstantesCoresMaquina.VIGA_TRAS + "-direita") }));

        addBotoesAoDicionario(1, ConstantesCoresMaquina.BTN_POWERUP_1, ConstantesCoresMaquina.BTN_PARTEDENTRO_1, ConstantesCoresMaquina.BTN_CONTORNO_1);
        addBotoesAoDicionario(2, ConstantesCoresMaquina.BTN_POWERUP_2, ConstantesCoresMaquina.BTN_PARTEDENTRO_2, ConstantesCoresMaquina.BTN_CONTORNO_2);
        addBotoesAoDicionario(3, ConstantesCoresMaquina.BTN_POWERUP_3, ConstantesCoresMaquina.BTN_PARTEDENTRO_3, ConstantesCoresMaquina.BTN_CONTORNO_3);
        addBotoesAoDicionario(4, ConstantesCoresMaquina.BTN_POWERUP_4, ConstantesCoresMaquina.BTN_PARTEDENTRO_4, ConstantesCoresMaquina.BTN_CONTORNO_4);

        addJoystickPartesAoDicionario();
        addPlacaFichaAoDicionario();
        addDisplaysDeColetadosAoDicionario();
        addDisplayTimerAoDicionario();
        addDisplaysDeScoreAoDicionario();

        dicionario.Add(ConstantesCoresMaquina.CABO_DA_GARRA, new SingleCompLineRendererColorivel(goCabo));
    }    

    private void inicializarGos()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            if (gos[contador].name == "MainObject")
            {
                goMaquina = find(gos[contador], "maquina");
                goCabo = find(gos[contador], "cabo_da_garra");
                return;
            }
        }
        Debug.LogError("Cena nao contem game object maquina");
    }

    private void addBotoesAoDicionario(int indice, string strBtn, string strParteDentro, string strContorno)
    {
        GameObject goBotoes = find("btns-power-ups");
        GameObject goBotao = goBotoes.transform.Find("btnPowerUp" + indice).gameObject;
        GameObject parteDentro = goBotao.transform.Find("parte-dentro").gameObject;
        GameObject contorno = parteDentro.transform.Find("contorno").gameObject;

        dicionario.Add(strBtn,         new SingleCompColorivel(goBotao));
        dicionario.Add(strParteDentro, new SingleCompColorivel(parteDentro));
        dicionario.Add(strContorno,    new SingleCompColorivel(contorno));
    }

    private void addJoystickPartesAoDicionario()
    {
        GameObject goJoystick = find("joystick");

        dicionario.Add(ConstantesCoresMaquina.PARTE_CIMA,    new SingleCompColorivel(find(goJoystick, ConstantesCoresMaquina.PARTE_CIMA)));
        dicionario.Add(ConstantesCoresMaquina.PARTE_BAIXO,   new SingleCompColorivel(find(goJoystick, ConstantesCoresMaquina.PARTE_BAIXO)));
        dicionario.Add(ConstantesCoresMaquina.FURO_HASTE,    new SingleCompColorivel(find(goJoystick, ConstantesCoresMaquina.FURO_HASTE)));

        GameObject goHaste = find(goJoystick, ConstantesCoresMaquina.HASTE);
        dicionario.Add(ConstantesCoresMaquina.HASTE,         new SingleCompColorivel(goHaste));
        dicionario.Add(ConstantesCoresMaquina.JOYSTICK_BOLA, new SingleCompColorivel(find(goHaste, ConstantesCoresMaquina.JOYSTICK_BOLA)));
        dicionario.Add(ConstantesCoresMaquina.FURO_BOTAO,    new SingleCompColorivel(find(goJoystick, ConstantesCoresMaquina.FURO_BOTAO)));
        dicionario.Add(ConstantesCoresMaquina.BOTAO,         new SingleCompColorivel(find(goJoystick, ConstantesCoresMaquina.BOTAO)));
    }

    private void addPlacaFichaAoDicionario()
    {
        GameObject placa = find(ConstantesCoresMaquina.PLACA_FICHA);
        GameObject placaPCima = find(placa, ConstantesCoresMaquina.PLACA_P_CIMA);
        GameObject placaPBaixo = find(placa, ConstantesCoresMaquina.PLACA_P_BAIXO);
        GameObject quadMaior = find(placa, ConstantesCoresMaquina.QUADRADO_MAIOR);
        GameObject quadMenor = find(placa, ConstantesCoresMaquina.QUADRADO_MENOR);
        GameObject furoCima = find(placa, ConstantesCoresMaquina.FURO_CIMA);
        GameObject furoBaixo = find(placa, ConstantesCoresMaquina.FURO_BAIXO);

        dicionario.Add(ConstantesCoresMaquina.PLACA_FICHA,    new SingleCompColorivel(placa));
        dicionario.Add(ConstantesCoresMaquina.PLACA_P_CIMA,   new SingleCompColorivel(placaPCima));
        dicionario.Add(ConstantesCoresMaquina.PLACA_P_BAIXO,  new SingleCompColorivel(placaPBaixo));
        dicionario.Add(ConstantesCoresMaquina.QUADRADO_MAIOR, new SingleCompColorivel(quadMaior));
        dicionario.Add(ConstantesCoresMaquina.QUADRADO_MENOR, new SingleCompColorivel(quadMenor));
        dicionario.Add(ConstantesCoresMaquina.FURO_CIMA,      new SingleCompColorivel(furoCima));
        dicionario.Add(ConstantesCoresMaquina.FURO_BAIXO,     new SingleCompColorivel(furoBaixo));
    }

    private void addDisplaysDeColetadosAoDicionario()
    {
        GameObject goGrupoDisplays = find("grupo-display-coletados");

        GameObject display1 = find(goGrupoDisplays, ConstantesCoresMaquina.DISPLAY_COLETADOS + "1");
        GameObject display2 = find(goGrupoDisplays, ConstantesCoresMaquina.DISPLAY_COLETADOS + "2");
        GameObject display3 = find(goGrupoDisplays, ConstantesCoresMaquina.DISPLAY_COLETADOS + "3");

        GameObject placaDisplay1 = find(display1, "dentro");
        GameObject placaDisplay2 = find(display2, "dentro");
        GameObject placaDisplay3 = find(display3, "dentro");

        dicionario.Add(ConstantesCoresMaquina.DISPLAY_COLETADOS, new MultipleCompColorivel(new GameObject[] { display1, display2, display3 }));
        dicionario.Add(ConstantesCoresMaquina.PLACA_COLETADO1, new SingleCompColorivel(placaDisplay1));
        dicionario.Add(ConstantesCoresMaquina.PLACA_COLETADO2, new SingleCompColorivel(placaDisplay2));
        dicionario.Add(ConstantesCoresMaquina.PLACA_COLETADO3, new SingleCompColorivel(placaDisplay3));
    }

    private void addDisplayTimerAoDicionario()
    {
        GameObject goDisplayTimer = find("display-timer");

        List<GameObject> listaTras = new List<GameObject>();
        List<GameObject> listaSegmentos = new List<GameObject>();

        for(int contador = 1; contador < 5; contador++)
        {
            GameObject goDiplayTimerDigito = find(goDisplayTimer, "display-timer-digito-" + contador);
            GameObject tras = find(goDiplayTimerDigito, "tras");
            listaTras.Add(tras);

            for(int subContador = 1; subContador < 8; subContador++)
            {
                GameObject segmento = find(goDiplayTimerDigito, "seg-" + subContador);
                listaSegmentos.Add(segmento);
            }
        }

        GameObject display2Digitos = find(goDisplayTimer, "display-timer-2pontos");
        GameObject tras2P = find(display2Digitos, "tras");
        GameObject seg1 = find(display2Digitos, "seg-1");
        GameObject seg2 = find(display2Digitos, "seg-2");

        listaTras.Add(tras2P);
        listaSegmentos.Add(seg1);
        listaSegmentos.Add(seg2);

        dicionario.Add(ConstantesCoresMaquina.DISPLAY_TIMER, new MultipleCompColorivel(listaTras.ToArray()));
        dicionario.Add(ConstantesCoresMaquina.DIGITOS_TIMERS, new MultipleCompColorivel(listaSegmentos.ToArray()));
    }

    private void addDisplaysDeScoreAoDicionario()
    {
        GameObject grupoDisplayScore = find("grupo-display-pontos");
        GameObject displayScore1 = find(grupoDisplayScore, ConstantesCoresMaquina.DISPLAY_SCORES1);
        GameObject displayScore2 = find(grupoDisplayScore, ConstantesCoresMaquina.DISPLAY_SCORES2);
        GameObject displayScore3 = find(grupoDisplayScore, ConstantesCoresMaquina.DISPLAY_SCORES3);

        GameObject[] leds1 = getLedsFromDisplay(displayScore1);
        GameObject[] leds2 = getLedsFromDisplay(displayScore2);
        GameObject[] leds3 = getLedsFromDisplay(displayScore3);

        dicionario.Add(ConstantesCoresMaquina.DISPLAY_SCORES1, new SingleCompColorivel(displayScore1));
        dicionario.Add(ConstantesCoresMaquina.DISPLAY_SCORES2, new SingleCompColorivel(displayScore2));
        dicionario.Add(ConstantesCoresMaquina.DISPLAY_SCORES3, new SingleCompColorivel(displayScore3));

        dicionario.Add(ConstantesCoresMaquina.LEDS1, new MultipleCompColorivel(leds1));
        dicionario.Add(ConstantesCoresMaquina.LEDS2, new MultipleCompColorivel(leds2));
        dicionario.Add(ConstantesCoresMaquina.LEDS3, new MultipleCompColorivel(leds3));
    }

    private GameObject[] getLedsFromDisplay(GameObject display)
    {
        List<GameObject> listaDeLeds = new List<GameObject>();
        for(int contador = 0; contador < 5; contador++)
        {
            GameObject goFileira = display.transform.Find("fileira" + (contador + 1)).gameObject;
            for(int subContador = 0; subContador < goFileira.transform.childCount; subContador++)
            {
                GameObject led = goFileira.transform.GetChild(subContador).gameObject;
                listaDeLeds.Add(led);
            }
        }
        return listaDeLeds.ToArray();
    }

    private GameObject find(string nome)
    {
        return goMaquina.transform.Find(nome).gameObject;
    }

    private GameObject find(GameObject go, string nome)
    {
        return go.transform.Find(nome).gameObject;
    }

    public void colorir(string nome, Color cor)
    {
        dicionario[nome].passarCor(cor);
    }

    public void reset(string nome)
    {
        dicionario[nome].resetCor();
    }

    public void select(string nome)
    {
        Selection.activeGameObject = dicionario[nome].getGo();        
    }

    public void gerarMapa()
    {
        string texto = "Dictionary<string, string> dicionario = new Dictionary<string, string>();" + Environment.NewLine;

        foreach(KeyValuePair<string, ComponenteColorivel> entry in dicionario)
        {
            texto += "dicionario.Add(\"" + entry.Key + "\", \"#" + ColorUtility.ToHtmlStringRGB(entry.Value.getCor()) + "\");" + Environment.NewLine;
        }
        Debug.Log(texto);        
    }
}
