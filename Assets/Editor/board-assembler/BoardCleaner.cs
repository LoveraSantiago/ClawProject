using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardCleaner 
{
    private ReferenciasDoBoardAssembler referenciasDoBoard;

    public BoardCleaner(ReferenciasDoBoardAssembler referenciasDoBoard)
    {
        this.referenciasDoBoard = referenciasDoBoard;
    }

    public void clean(Action<GameObject> acaoCleanGo, Action<Text> acaoCleanText)
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

                if (isSextoElementoLinhaPar(contadorLinha, contadorColuna))
                {
                    goIt.SetActive(false);
                    textIt.gameObject.SetActive(false);
                }
            }
        }
    }

    private bool isSextoElementoLinhaPar(int linha, int coluna)
    {
        return linha % 2 != 0 && coluna == 6;
    }
}
