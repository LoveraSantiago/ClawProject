using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NavegacaoPeloBoard 
{
    private int linhaAtual;
    private int colunaAtual;

    private GameObject goMira;
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;

    public NavegacaoPeloBoard(GameObject goMira, Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard)
    {
        this.goMira = goMira;
        this.dicionarioGosBoard = dicionarioGosBoard;        
    }

    public void configurarBotoes(VisualElement root)
    {
        Button btnCima = root.Q<Button>("botaoCima");
        btnCima.clickable.clicked += () =>
        {
            if (podeDescerUmaLinha())
            {
                linhaAtual++;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };

        Button btnEsquerda = root.Q<Button>("botaoEsquerda");
        btnEsquerda.clickable.clicked += () =>
        {
            if (podeVoltarUmaColuna())
            {
                colunaAtual--;
            }

            posicionarMira(linhaAtual, colunaAtual);
        };

        Button btnDireita = root.Q<Button>("botaoDireita");
        btnDireita.clickable.clicked += () =>
        {
            if (podeAndarUmaColuna())
            {
                colunaAtual++;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };

        Button btnBaixo = root.Q<Button>("botaoBaixo");
        btnBaixo.clickable.clicked += () =>
        {
            if (podeAndarUmaLinha())
            {
                linhaAtual--;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };
    }

    private bool podeAndarUmaColuna()
    {
        return colunaAtual + 1 < dicionarioGosBoard[linhaAtual].Count;
    }

    private bool podeVoltarUmaColuna()
    {
        return colunaAtual - 1 >= 0;
    }

    private bool podeAndarUmaLinha()
    {
        return linhaAtual - 1 >= 0;
    }

    private bool podeDescerUmaLinha()
    {
        return linhaAtual + 1 < dicionarioGosBoard.Count;
    }

    private void posicionarMira(int linha, int coluna)
    {
        GameObject go00 = dicionarioGosBoard[linha][coluna];
        goMira.transform.position = go00.transform.position;
    }

    public void resetMira()
    {
        posicionarMira(0, 0);
        linhaAtual = 0;
        colunaAtual = 0;
    }

    public GameObject getGoDaMira()
    {
        return dicionarioGosBoard[linhaAtual][colunaAtual];
    }
}
