using System.Collections.Generic;
using UnityEngine;

public class ReferenciasDoBoardObstaculo : ReferenciasDoBoard
{
    private GameObject goGaiolaLinha;
    private Dictionary<int, GameObject> dicionarioGaiolaColuna;
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosGaiolas;

    public ReferenciasDoBoardObstaculo() :
        base("BoardAssembler-Obstaculos")
    { }

    public void updateElementoGaiola(int linha, int coluna, bool estado)
    {
        dicionarioGosGaiolas[linha][coluna].SetActive(estado);
    }    

    protected override void preIteracaoLinha()
    {
        dicionarioGosGaiolas = new Dictionary<int, Dictionary<int, GameObject>>();
    }

    protected override void iteracaoLinha(int contadorLinha, GameObject goBoardAssembler)
    {
        goGaiolaLinha = goBoardAssembler.transform.Find("gos-gaiolas").GetChild(contadorLinha).gameObject;
    }

    protected override void preIteracaoColuna()
    {
        dicionarioGaiolaColuna = new Dictionary<int, GameObject>();
    }

    protected override void iteracaoColuna(int contadorColuna, int indiceColuna)
    {
        GameObject goGaiola = goGaiolaLinha.transform.GetChild(contadorColuna).gameObject;
        dicionarioGaiolaColuna.Add(indiceColuna, goGaiola);
    }

    protected override void posIteracaoColuna(int contadorLinha)
    {
        dicionarioGosGaiolas.Add(contadorLinha, dicionarioGaiolaColuna);
    }
}
