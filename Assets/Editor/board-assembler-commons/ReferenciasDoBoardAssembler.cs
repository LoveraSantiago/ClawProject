using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class ReferenciasDoBoardAssembler
{
    public GameObject goMira { get; private set; }
    public Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard { get; private set; }
    //public Dictionary<int, Dictionary<int, Text>> dicionarioTextLabels { get; private set; }

    public ReferenciasDoBoardAssembler(string nomePrefab)
    {
        configurarReferenciasComBoard(nomePrefab);
    }

    private void configurarReferenciasComBoard(string nomePrefab)
    {
        GameObject goBoardAssembler = getBoardAssembler(nomePrefab);
        inicializarDicionarios(goBoardAssembler);
        goMira = inicializarGoMira(goBoardAssembler);
    }

    private GameObject getBoardAssembler(string nomePrefab)
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            //Debug.Log("Nome: " + gos[contador].name);
            if (gos[contador].name.Equals(nomePrefab))
            {
                return gos[contador];

            }
        }
        Debug.LogError("Nao existe na cena o prefab " + nomePrefab);
        return null;
    }

    private void inicializarDicionarios(GameObject goBoardAssembler)
    {
        dicionarioGosBoard = new Dictionary<int, Dictionary<int, GameObject>>();
        //dicionarioTextLabels = new Dictionary<int, Dictionary<int, Text>>();
        preIteracaoLinha();

        for (int contadorLinha = 0; contadorLinha < goBoardAssembler.transform.Find("gos").childCount; contadorLinha++)
        {
            GameObject goLinha = goBoardAssembler.transform.Find("gos").GetChild(contadorLinha).gameObject;
            //GameObject goLabel = goBoardAssembler.transform.Find("lbls").GetChild(contadorLinha).gameObject;
            iteracaoLinha(contadorLinha, goBoardAssembler);

            if (isNumerico(goLinha.name))
            {
                Dictionary<int, GameObject> dicionarioGoColuna = new Dictionary<int, GameObject>();
                preIteracaoColuna();
                //Dictionary<int, Text> dicionarioTextColuna = new Dictionary<int, Text>();

                for (int contadorColuna = 0; contadorColuna < goLinha.transform.childCount; contadorColuna++)
                {
                    GameObject goColuna = goLinha.transform.GetChild(contadorColuna).gameObject;
                    //Text textColuna = goLabel.transform.GetChild(contadorColuna).GetComponent<Text>();

                    if (isNumerico(goColuna.name))
                    {
                        int indiceColuna = toNumeric(goColuna.name);
                        iteracaoColuna(contadorColuna, indiceColuna);
                        dicionarioGoColuna.Add(indiceColuna, goColuna);
                        //dicionarioTextColuna.Add(indiceColuna, textColuna);
                    }
                }
                int indiceLinha = toNumeric(goLinha.name);
                dicionarioGosBoard.Add(indiceLinha, dicionarioGoColuna);
                posIteracaoColuna(contadorLinha);
                //dicionarioTextLabels.Add(indiceLinha, dicionarioTextColuna);
            }
        }
    }

    protected abstract void preIteracaoLinha();
    protected abstract void iteracaoLinha(int contadorLinha, GameObject goBoardAssembler);
    protected abstract void preIteracaoColuna();
    protected abstract void iteracaoColuna(int contadorColuna, int indiceColuna);
    protected abstract void posIteracaoColuna(int contadorLinha);

    private bool isNumerico(string name)
    {
        int nomeNumericoLinha;
        return int.TryParse(name, out nomeNumericoLinha);
    }

    private int toNumeric(string name)
    {
        int nomeNumericoLinha;
        bool result = int.TryParse(name, out nomeNumericoLinha);
        return nomeNumericoLinha;
    }

    private GameObject inicializarGoMira(GameObject goBoardAssembler)
    {
        GameObject goMira = goBoardAssembler.transform.Find("mira").gameObject;
        if (goMira == null)
        {
            Debug.LogError("Objeto mira nao existe no game object BoardAssembler");
        }
        return goMira;
    }
}
