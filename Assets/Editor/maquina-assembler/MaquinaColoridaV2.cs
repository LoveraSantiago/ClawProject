using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaquinaColoridaV2 
{
    private GameObject goMaquina;
    private GameObject goCabo;
    private Dictionary<string, ComponenteColorivel> dicionario;

    public MaquinaColoridaV2()
    {
        inicializarGos();

        dicionario = new Dictionary<string, ComponenteColorivel>();
        dicionario.Add(ConstantesCoresMaquinaV2.PLACA_FRENTE, new SingleCompColorivel(find(ConstantesCoresMaquinaV2.PLACA_FRENTE)));
    }

    private void inicializarGos()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            if (gos[contador].name == "main-object")
            {
                goMaquina = find(gos[contador], "maquina-v3");                
                goCabo = find(gos[contador], "cabo-da-garra");
                return;
            }
        }
        Debug.LogError("Cena nao contem game object maquina");
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

    public void select(string nome)
    {
        Selection.activeGameObject = dicionario[nome].getGo();
    }

    public void reset(string nome)
    {
        dicionario[nome].resetCor();
    }
}
