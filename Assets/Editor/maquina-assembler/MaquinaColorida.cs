using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColorida 
{
    public static readonly string PLACA_CIMA = "placa-cima";

    private GameObject goMaquina;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColorida()
    {
        goMaquina = getGoMaquina();
        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(PLACA_CIMA, new ComponenteColorivel(PLACA_CIMA, find(PLACA_CIMA)));
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
