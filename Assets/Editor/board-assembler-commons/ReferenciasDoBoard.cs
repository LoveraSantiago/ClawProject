using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ReferenciasDoBoard
{
    public GameObject goMira { get; private set; }
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;
    //public Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard { get; private set; }

    public ReferenciasDoBoard(string nomePrefab)
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
        preIteracaoLinha();

        for (int contadorLinha = 0; contadorLinha < goBoardAssembler.transform.Find("gos").childCount; contadorLinha++)
        {
            GameObject goLinha = goBoardAssembler.transform.Find("gos").GetChild(contadorLinha).gameObject;
            iteracaoLinha(contadorLinha, goBoardAssembler);

            if (isNumerico(goLinha.name))
            {
                Dictionary<int, GameObject> dicionarioGoColuna = new Dictionary<int, GameObject>();
                preIteracaoColuna();

                for (int contadorColuna = 0; contadorColuna < goLinha.transform.childCount; contadorColuna++)
                {
                    GameObject goColuna = goLinha.transform.GetChild(contadorColuna).gameObject;

                    if (isNumerico(goColuna.name))
                    {
                        int indiceColuna = toNumeric(goColuna.name);
                        iteracaoColuna(contadorColuna, indiceColuna);
                        dicionarioGoColuna.Add(indiceColuna, goColuna);
                    }
                }
                int indiceLinha = toNumeric(goLinha.name);
                dicionarioGosBoard.Add(indiceLinha, dicionarioGoColuna);
                posIteracaoColuna(contadorLinha);
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
