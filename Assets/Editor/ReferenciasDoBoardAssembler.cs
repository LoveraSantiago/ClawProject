using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReferenciasDoBoardAssembler 
{
    public Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard { get; private set; }
    public GameObject goMira { get; private set; }

    public ReferenciasDoBoardAssembler()
    {
        configurarReferenciasComBoard();
    }

    private void configurarReferenciasComBoard()
    {
        GameObject goBoardAssembler = getBoardAssembler();
        dicionarioGosBoard = inicializarDicionarioDeGosBoard(goBoardAssembler);
        goMira = inicializarGoMira(goBoardAssembler);
    }

    private GameObject getBoardAssembler()
    {
        GameObject[] gos = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int contador = 0; contador < gos.Length; contador++)
        {
            //Debug.Log("Nome: " + gos[contador].name);
            if (gos[contador].name == "BoardAssembler")
            {
                return gos[contador];

            }
        }
        Debug.LogError("Nao existe na cena o prefab BoardAssembler");
        return null;
    }

    private Dictionary<int, Dictionary<int, GameObject>> inicializarDicionarioDeGosBoard(GameObject goBoardAssembler)
    {
        Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard = new Dictionary<int, Dictionary<int, GameObject>>();
        for (int contadorLinha = 0; contadorLinha < goBoardAssembler.transform.childCount; contadorLinha++)
        {
            GameObject goLinha = goBoardAssembler.transform.GetChild(contadorLinha).gameObject;
            int nomeNumericoLinha;
            bool isNumericoLinha = int.TryParse(goLinha.name, out nomeNumericoLinha);
            if (isNumericoLinha)
            {
                Dictionary<int, GameObject> dicionarioColuna = new Dictionary<int, GameObject>();

                for (int contadorColuna = 0; contadorColuna < goLinha.transform.childCount; contadorColuna++)
                {
                    GameObject goColuna = goLinha.transform.GetChild(contadorColuna).gameObject;
                    int nomeNumericoColuna;
                    bool isNumericoColuna = int.TryParse(goColuna.name, out nomeNumericoColuna);
                    if (isNumericoColuna)
                    {                        
                        dicionarioColuna.Add(nomeNumericoColuna, goColuna);
                    }
                }
                dicionarioGosBoard.Add(nomeNumericoLinha, dicionarioColuna);
            }
        }
        return dicionarioGosBoard;
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
