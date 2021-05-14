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


    private GameObject find(string nome)
    {
        return goMaquina.transform.Find(nome).gameObject;
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
