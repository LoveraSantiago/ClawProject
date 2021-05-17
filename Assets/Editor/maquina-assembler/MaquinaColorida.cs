using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColorida 
{
    public static readonly string PLACA_CIMA = "placa-cima";
    public static readonly string BASE_PARTE = "base-parte";
    public static readonly string BASE_CHAO = "base-chao";
    public static readonly string BORDA_VIDRO = "borda-vidro";
    public static readonly string PLACA_FRONTAL = "placa-frontal";
    public static readonly string PLACA_SAIDA = "placa-saida";
    public static readonly string BARRA = "barra";
    public static readonly string CHAO_DENTRO = "chao-dentro";
    public static readonly string TUBO = "tubo";
    public static readonly string VIGA_TRAS = "viga-tras";

    public static readonly string BTN_POWERUP_1 = "btnPowerUp1";
    public static readonly string BTN_PARTEDENTRO_1 = "parte-dentro1";
    public static readonly string BTN_CONTORNO_1 = "contorno1";
    public static readonly string BTN_POWERUP_2 = "btnPowerUp2";
    public static readonly string BTN_PARTEDENTRO_2 = "parte-dentro2";
    public static readonly string BTN_CONTORNO_2 = "contorno2";
    public static readonly string BTN_POWERUP_3 = "btnPowerUp3";
    public static readonly string BTN_PARTEDENTRO_3 = "parte-dentro3";
    public static readonly string BTN_CONTORNO_3 = "contorno3";
    public static readonly string BTN_POWERUP_4 = "btnPowerUp4";
    public static readonly string BTN_PARTEDENTRO_4 = "parte-dentro4";
    public static readonly string BTN_CONTORNO_4 = "contorno4";

    public static readonly string PARTE_CIMA = "parte-cima";
    public static readonly string PARTE_BAIXO = "parte-baixo";
    public static readonly string FURO_HASTE = "furo-haste";
    public static readonly string HASTE = "haste";
    public static readonly string JOYSTICK_BOLA = "joystick-bola";
    public static readonly string FURO_BOTAO = "furo-botao";
    public static readonly string BOTAO = "botao";

    public static readonly string PLACA_FICHA = "placa-ficha";
    public static readonly string PLACA_P_CIMA = "placa-parte-cima";
    public static readonly string PLACA_P_BAIXO = "placa-parte-baixo";
    public static readonly string QUADRADO_MAIOR = "quadrado-maior";
    public static readonly string QUADRADO_MENOR = "quadrado-menor";
    public static readonly string FURO_CIMA = "furo-cima";
    public static readonly string FURO_BAIXO = "furo-baixo";

    public static readonly string DISPLAY_COLETADOS = "display-coletados";
    public static readonly string PLACA_COLETADO1 = "placa-coletado1";
    public static readonly string PLACA_COLETADO2 = "placa-coletado2";
    public static readonly string PLACA_COLETADO3 = "placa-coletado3";

    public static readonly string DISPLAY_TIMER = "display-timer";
    public static readonly string DIGITOS_TIMERS = "digitos-timer";

    public static readonly string DISPLAY_SCORES1 = "display-pontos1";
    public static readonly string DISPLAY_SCORES2 = "display-pontos2";
    public static readonly string DISPLAY_SCORES3 = "display-pontos3";
    public static readonly string LEDS1 = "leds1";
    public static readonly string LEDS2 = "leds2";
    public static readonly string LEDS3 = "leds3";

    private GameObject goMaquina;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColorida()
    {
        goMaquina = getGoMaquina();
        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(PLACA_CIMA,    new SingleCompColorivel(find(PLACA_CIMA)));
        dicionario.Add(BASE_PARTE,    new MultipleCompColorivel(new GameObject[] { find(BASE_PARTE + "-cima"), find(BASE_PARTE + "-baixo")}));
        dicionario.Add(BASE_CHAO,     new SingleCompColorivel(find(BASE_CHAO)));
        dicionario.Add(BORDA_VIDRO,   new SingleCompColorivel(find(BORDA_VIDRO)));
        dicionario.Add(PLACA_FRONTAL, new SingleCompColorivel(find(PLACA_FRONTAL)));
        dicionario.Add(PLACA_SAIDA,   new SingleCompColorivel(find(PLACA_SAIDA)));
        dicionario.Add(BARRA,         new SingleCompColorivel(find(BARRA)));
        dicionario.Add(CHAO_DENTRO,   new SingleCompColorivel(find(CHAO_DENTRO)));
        dicionario.Add(TUBO,          new SingleCompColorivel(find(TUBO)));
        dicionario.Add(VIGA_TRAS,     new MultipleCompColorivel(new GameObject[] { find(VIGA_TRAS + "-esquerda"), find(VIGA_TRAS + "-direita") }));

        addBotoesAoDicionario(1, BTN_POWERUP_1, BTN_PARTEDENTRO_1, BTN_CONTORNO_1);
        addBotoesAoDicionario(2, BTN_POWERUP_2, BTN_PARTEDENTRO_2, BTN_CONTORNO_2);
        addBotoesAoDicionario(3, BTN_POWERUP_3, BTN_PARTEDENTRO_3, BTN_CONTORNO_3);
        addBotoesAoDicionario(4, BTN_POWERUP_4, BTN_PARTEDENTRO_4, BTN_CONTORNO_4);

        addJoystickPartesAoDicionario();
        addPlacaFichaAoDicionario();
        addDisplaysDeColetadosAoDicionario();
        addDisplayTimerAoDicionario();
        addDisplaysDeScoreAoDicionario();
    }

    private GameObject getGoMaquina()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            if (gos[contador].name == "MainObject")
            {
                return gos[contador].transform.Find("maquina").gameObject;                
            }
        }
        Debug.LogError("Cena nao contem game object maquina");
        return null;
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

        dicionario.Add(PARTE_CIMA,    new SingleCompColorivel(find(goJoystick, PARTE_CIMA)));
        dicionario.Add(PARTE_BAIXO,   new SingleCompColorivel(find(goJoystick, PARTE_BAIXO)));
        dicionario.Add(FURO_HASTE,    new SingleCompColorivel(find(goJoystick, FURO_HASTE)));
        dicionario.Add(HASTE,         new SingleCompColorivel(find(goJoystick, HASTE)));
        dicionario.Add(JOYSTICK_BOLA, new SingleCompColorivel(find(goJoystick, JOYSTICK_BOLA)));
        dicionario.Add(FURO_BOTAO,    new SingleCompColorivel(find(goJoystick, FURO_BOTAO)));
        dicionario.Add(BOTAO,         new SingleCompColorivel(find(goJoystick, BOTAO)));
    }

    private void addPlacaFichaAoDicionario()
    {
        GameObject placa = find(PLACA_FICHA);
        GameObject placaPCima = find(placa, PLACA_P_CIMA);
        GameObject placaPBaixo = find(placa, PLACA_P_BAIXO);
        GameObject quadMaior = find(placa, QUADRADO_MAIOR);
        GameObject quadMenor = find(placa, QUADRADO_MENOR);
        GameObject furoCima = find(placa, FURO_CIMA);
        GameObject furoBaixo = find(placa, FURO_BAIXO);

        dicionario.Add(PLACA_FICHA,    new SingleCompColorivel(placa));
        dicionario.Add(PLACA_P_CIMA,   new SingleCompColorivel(placaPCima));
        dicionario.Add(PLACA_P_BAIXO,  new SingleCompColorivel(placaPBaixo));
        dicionario.Add(QUADRADO_MAIOR, new SingleCompColorivel(quadMaior));
        dicionario.Add(QUADRADO_MENOR, new SingleCompColorivel(quadMenor));
        dicionario.Add(FURO_CIMA,      new SingleCompColorivel(furoCima));
        dicionario.Add(FURO_BAIXO,     new SingleCompColorivel(furoBaixo));
    }

    private void addDisplaysDeColetadosAoDicionario()
    {
        GameObject goGrupoDisplays = find("grupo-display-coletados");

        GameObject display1 = find(goGrupoDisplays, DISPLAY_COLETADOS + "1");
        GameObject display2 = find(goGrupoDisplays, DISPLAY_COLETADOS + "2");
        GameObject display3 = find(goGrupoDisplays, DISPLAY_COLETADOS + "3");

        GameObject placaDisplay1 = find(display1, "dentro");
        GameObject placaDisplay2 = find(display2, "dentro");
        GameObject placaDisplay3 = find(display3, "dentro");

        dicionario.Add(DISPLAY_COLETADOS, new MultipleCompColorivel(new GameObject[] { display1, display2, display3 }));
        dicionario.Add(PLACA_COLETADO1, new SingleCompColorivel(placaDisplay1));
        dicionario.Add(PLACA_COLETADO2, new SingleCompColorivel(placaDisplay2));
        dicionario.Add(PLACA_COLETADO3, new SingleCompColorivel(placaDisplay3));
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

        dicionario.Add(DISPLAY_TIMER, new MultipleCompColorivel(listaTras.ToArray()));
        dicionario.Add(DIGITOS_TIMERS, new MultipleCompColorivel(listaSegmentos.ToArray()));
    }

    private void addDisplaysDeScoreAoDicionario()
    {
        GameObject grupoDisplayScore = find("grupo-display-pontos");
        GameObject displayScore1 = find(grupoDisplayScore, DISPLAY_SCORES1);
        GameObject displayScore2 = find(grupoDisplayScore, DISPLAY_SCORES2);
        GameObject displayScore3 = find(grupoDisplayScore, DISPLAY_SCORES3);

        GameObject[] leds1 = getLedsFromDisplay(displayScore1);
        GameObject[] leds2 = getLedsFromDisplay(displayScore2);
        GameObject[] leds3 = getLedsFromDisplay(displayScore3);

        dicionario.Add(DISPLAY_SCORES1, new SingleCompColorivel(displayScore1));
        dicionario.Add(DISPLAY_SCORES2, new SingleCompColorivel(displayScore2));
        dicionario.Add(DISPLAY_SCORES3, new SingleCompColorivel(displayScore3));

        dicionario.Add(LEDS1, new MultipleCompColorivel(leds1));
        dicionario.Add(LEDS2, new MultipleCompColorivel(leds2));
        dicionario.Add(LEDS3, new MultipleCompColorivel(leds3));
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
}
