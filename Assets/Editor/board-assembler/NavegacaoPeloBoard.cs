using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NavegacaoPeloBoard 
{
    private int linhaAtual;
    private int colunaAtual;

    private GameObject goMira;
    private Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard;

    public NavegacaoPeloBoard(VisualElement root, GameObject goMira, Dictionary<int, Dictionary<int, GameObject>> dicionarioGosBoard)
    {
        this.goMira = goMira;
        this.dicionarioGosBoard = dicionarioGosBoard;

        configurarBotoes(root);
    }

    private void configurarBotoes(VisualElement root)
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
        bool resultProximaPosicao = colunaAtual + 1 < dicionarioGosBoard[linhaAtual].Count;
        bool resultPos7Par = (linhaAtual % 2 != 0) && colunaAtual + 1 == 6;
        return resultProximaPosicao && !resultPos7Par;
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

    public void navegarCimaTotal()
    {
        linhaAtual = dicionarioGosBoard.Count - 1;
        posicionarMira(linhaAtual, colunaAtual);
    }

    public void navegarBaixoTotal()
    {
        linhaAtual = 0;
        posicionarMira(linhaAtual, colunaAtual);
    }

    public void navegarTrasTotal()
    {
        colunaAtual = 0;
        posicionarMira(linhaAtual, colunaAtual);
    }

    public void navegarFrenteTotal()
    {
        colunaAtual = dicionarioGosBoard[linhaAtual].Count - 1;
        posicionarMira(linhaAtual, colunaAtual);
    }
}
