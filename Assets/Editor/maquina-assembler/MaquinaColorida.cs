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
    

    private GameObject goMaquina;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColorida()
    {
        goMaquina = getGoMaquina();
        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(PLACA_CIMA, new SingleCompColorivel(find(PLACA_CIMA)));
        dicionario.Add(BASE_PARTE, new DoubleCompColorivel(find(BASE_PARTE + "-cima"), find(BASE_PARTE + "-baixo")));
        dicionario.Add(BASE_CHAO, new SingleCompColorivel(find(BASE_CHAO)));
        dicionario.Add(BORDA_VIDRO, new SingleCompColorivel(find(BORDA_VIDRO)));
        dicionario.Add(PLACA_FRONTAL, new SingleCompColorivel(find(PLACA_FRONTAL)));
        dicionario.Add(PLACA_SAIDA, new SingleCompColorivel(find(PLACA_SAIDA)));
        dicionario.Add(BARRA, new SingleCompColorivel(find(BARRA)));
        dicionario.Add(CHAO_DENTRO, new SingleCompColorivel(find(CHAO_DENTRO)));
        dicionario.Add(TUBO, new SingleCompColorivel(find(TUBO)));
        dicionario.Add(VIGA_TRAS, new DoubleCompColorivel(find(VIGA_TRAS + "-esquerda"), find(VIGA_TRAS + "-direita")));

        addBotoesAoDicionario(1, BTN_POWERUP_1, BTN_PARTEDENTRO_1, BTN_CONTORNO_1);
        addBotoesAoDicionario(2, BTN_POWERUP_2, BTN_PARTEDENTRO_2, BTN_CONTORNO_2);
        addBotoesAoDicionario(3, BTN_POWERUP_3, BTN_PARTEDENTRO_3, BTN_CONTORNO_3);
        addBotoesAoDicionario(4, BTN_POWERUP_4, BTN_PARTEDENTRO_4, BTN_CONTORNO_4);

        addJoystickPartesAoDicionario();
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

        dicionario.Add(strBtn, new SingleCompColorivel(goBotao));
        dicionario.Add(strParteDentro, new SingleCompColorivel(parteDentro));
        dicionario.Add(strContorno, new SingleCompColorivel(contorno));
    }

    private void addJoystickPartesAoDicionario()
    {
        GameObject goJoystick = find("joystick");

        dicionario.Add(PARTE_CIMA, new SingleCompColorivel(find(goJoystick, PARTE_CIMA)));
        dicionario.Add(PARTE_BAIXO, new SingleCompColorivel(find(goJoystick, PARTE_BAIXO)));
        dicionario.Add(FURO_HASTE, new SingleCompColorivel(find(goJoystick, FURO_HASTE)));
        dicionario.Add(HASTE, new SingleCompColorivel(find(goJoystick, HASTE)));
        dicionario.Add(JOYSTICK_BOLA, new SingleCompColorivel(find(goJoystick, JOYSTICK_BOLA)));
        dicionario.Add(FURO_BOTAO, new SingleCompColorivel(find(goJoystick, FURO_BOTAO)));
        dicionario.Add(BOTAO, new SingleCompColorivel(find(goJoystick, BOTAO)));
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
