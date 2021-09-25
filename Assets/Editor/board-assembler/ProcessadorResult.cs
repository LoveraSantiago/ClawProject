using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProcessadorResult 
{
    private ReferenciasDoBoardAssembler referencias;

    public ProcessadorResult(ReferenciasDoBoardAssembler referencias)
    {
        this.referencias = referencias;
    }

    public void gerarArrayDeIds()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        string result = "int[,] coletaveis = new int[,]{" + Environment.NewLine;

        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = referencias.dicionarioGosBoard[0];
            result += "{";
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goIt = referencias.dicionarioGosBoard[contadorLinha][contadorColuna];
                Sprite spriteIt = goIt.GetComponent<SpriteRenderer>().sprite;

                ColetavelEntidade coletavelEntidade = coletavelQuery.getColetavelEntidadeBySprite(spriteIt.name);

                string separador = contadorColuna == dicionarioLinha.Count - 1 ? "" : ", ";
                result += coletavelEntidade.id + separador;
            }
            string separadorFim = contadorLinha == referencias.dicionarioGosBoard.Count - 1 ? "" : (", " + Environment.NewLine);
            result += "}" + separadorFim;
        }
        result += "};";
        Debug.Log(result);
    }
    //Resultado deve ser colocado como:
    //int[,] x = new int[,]  { { 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0} };

    public void gerarArrayDeOrdem()
    {
        SortedList<int, BoardOrdem> sortedList = new SortedList<int, BoardOrdem>();
        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioTextLabels.Count; contadorLinha++)
        {
            Dictionary<int, Text> dicionarioLinha = referencias.dicionarioTextLabels[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                Text textIt = referencias.dicionarioTextLabels[contadorLinha][contadorColuna];
                if (!textIt.text.Equals("00"))
                {
                    int ordem = int.Parse(textIt.text);
                    BoardOrdem boardOrdem = new BoardOrdem(ordem, contadorLinha, contadorColuna);
                    sortedList.Add(boardOrdem.ordem, boardOrdem);
                }
            }
        }

        string result = "BoardOrdem[] ordem = new BoardOrdem[]{" + Environment.NewLine;
        for(int contador = 0; contador < sortedList.Count; contador++)
        {
            BoardOrdem boardOrdem = sortedList[contador];
            result += "new BoardOrdem(" + contador + ", " + boardOrdem.linha + ", " + boardOrdem.coluna + ")";
            string separadorLinha = (contador + 1) == sortedList.Count ? "" : ("," + Environment.NewLine);
            result += separadorLinha;
        }
        result += "};";
        Debug.Log(result);
    }
}
