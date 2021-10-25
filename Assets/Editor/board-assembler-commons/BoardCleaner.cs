using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BoardCleaner 
{
    private Action<GameObject> acaoCleanGo;
    private Action<Text> acaoCleanText;
    private ReferenciasDoBoardAssembler referenciasDoBoard;
    private NavegacaoPeloBoard navegacao;

    public BoardCleaner(
        ReferenciasDoBoardAssembler referenciasDoBoard,
        NavegacaoPeloBoard navegacao,
        Action<GameObject> acaoCleanGo,
        Action<Text> acaoCleanText)
    {
        this.acaoCleanGo = acaoCleanGo;
        this.acaoCleanText = acaoCleanText;
        this.navegacao = navegacao;
        this.referenciasDoBoard = referenciasDoBoard;
    }

    protected abstract bool isSextoElementoTipoLinha(int linha, int coluna);

    public void clean()
    {
        for (int contadorLinha = 0; contadorLinha < referenciasDoBoard.dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = referenciasDoBoard.dicionarioGosBoard[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goIt = referenciasDoBoard.dicionarioGosBoard[contadorLinha][contadorColuna];
                acaoCleanGo.Invoke(goIt);

                Text textIt = referenciasDoBoard.dicionarioTextLabels[contadorLinha][contadorColuna];
                acaoCleanText.Invoke(textIt);

                Debug.Log("linha " + contadorLinha + " coluna " + contadorColuna);
                if (isSextoElementoTipoLinha(contadorLinha, contadorColuna))
                {
                    goIt.SetActive(false);
                    textIt.gameObject.SetActive(false);
                }
                else
                {
                    goIt.SetActive(true);
                    textIt.gameObject.SetActive(true);
                }
            }
        }
        navegacao.resetMira();
    }

    protected bool isSextoElementoLinhaPar(int linha, int coluna)
    {
        return linha % 2 != 0 && coluna == 6;
    }

    protected bool isSextoElementoLinhaImpar(int linha, int coluna)
    {
        return linha % 2 == 0 && coluna == 6;
    }
}
