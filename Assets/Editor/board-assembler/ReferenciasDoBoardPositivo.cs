using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReferenciasDoBoardPositivo : ReferenciasDoBoard
{
    private GameObject goLinhaLabel;
    private Dictionary<int, Text> dicionarioTextColuna;
    public Dictionary<int, Dictionary<int, Text>> dicionarioTextLabels { get; private set; }

    public ReferenciasDoBoardPositivo() : 
        base("BoardAssembler"){}

    public void updateElementoTexto(int linha, int coluna, int valor)
    {
        bool isVazio = isElementoGoVazio(linha, coluna);
        if (!isVazio)
        {
            dicionarioTextLabels[linha][coluna].text = valor.ToString();
        }
    }

    protected override void preIteracaoLinha()
    {
        dicionarioTextLabels = new Dictionary<int, Dictionary<int, Text>>();
    }

    protected override void iteracaoLinha(int contadorLinha, GameObject goBoardAssembler)
    {
        goLinhaLabel = goBoardAssembler.transform.Find("lbls").GetChild(contadorLinha).gameObject;
    }

    protected override void preIteracaoColuna()
    {
        dicionarioTextColuna = new Dictionary<int, Text>();
    }

    protected override void iteracaoColuna(int contadorColuna, int indiceColuna)
    {
        Text textColuna = goLinhaLabel.transform.GetChild(contadorColuna).GetComponent<Text>();
        dicionarioTextColuna.Add(indiceColuna, textColuna);
    }

    protected override void posIteracaoColuna(int contadorLinha)
    {
        dicionarioTextLabels.Add(contadorLinha, dicionarioTextColuna);
    }
}
