using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioTextLabels.Count; contadorLinha++)
        {
            Dictionary<int, Text> dicionarioLinha = referencias.dicionarioTextLabels[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                Text textIt = referencias.dicionarioTextLabels[contadorLinha][contadorColuna];
                if (int.Parse(textIt.text) != 0)
                {
                    contadorNome++;
                    int ordem = int.Parse(textIt.text);
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
