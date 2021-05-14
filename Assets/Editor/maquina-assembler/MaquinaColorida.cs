using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColorida 
{
    private GameObject goMaquina;
    private ComponenteColorivel compPlacaCima;

    public MaquinaColorida()
    {
        goMaquina = getGoMaquina();
        compPlacaCima = new ComponenteColorivel("placa-cima", find("placa-cima"));
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

    public void colorirPlacaCima(Color cor)
    {
        compPlacaCima.passarCor(cor);
    }

    public void resetPlacaCima()
    {
        compPlacaCima.resetCor();
    }
}
