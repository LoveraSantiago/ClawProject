using System;
using System.Collections.Generic;
using UnityEngine;

public class ProcessadorDeOrdem 
{
    private ReferenciasDoBoardPositivo referencias;

    public ProcessadorDeOrdem(ReferenciasDoBoardPositivo referencias)
    {
        this.referencias = referencias;
    }

    public void processar()
    {
        SortedList<int, BoardOrdem> sortedList = new SortedList<int, BoardOrdem>();
        int contadorNome = 0;
        int totalLinhas = referencias.getQtdLinhasDoBoard();
        for (int contadorLinha = 0; contadorLinha < totalLinhas; contadorLinha++)
        {
            int totalColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for (int contadorColuna = 0; contadorColuna < totalColunas; contadorColuna++)
            {   
                int ordem = referencias.getOrdemDoElementoTexto(contadorLinha, contadorColuna);
                if (ordem != 0)
                {
                    contadorNome++;                    
                    BoardOrdem boardOrdem = new BoardOrdem(ordem, contadorNome.ToString());
                    sortedList.Add(boardOrdem.ordem, boardOrdem);
                }
            }
        }

        string result = "BoardOrdem[] ordem = new BoardOrdem[]{" + Environment.NewLine;
        for (int contador = 0; contador < sortedList.Count; contador++)
        {
            BoardOrdem boardOrdem = sortedList[contador + 1];
            result += "new BoardOrdem(" + boardOrdem.ordem + ", \"" + boardOrdem.nome + "\")";
            string separadorLinha = (contador + 1) == sortedList.Count ? "" : ("," + Environment.NewLine);
            result += separadorLinha;
        }
        result += "};";
        Debug.Log(result);
    }
}
