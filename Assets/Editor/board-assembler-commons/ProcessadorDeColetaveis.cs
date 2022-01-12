using System;
using System.Collections.Generic;
using UnityEngine;

public class ProcessadorDeColetaveis 
{
    private ReferenciasDoBoardAssembler referencias;

    public ProcessadorDeColetaveis(ReferenciasDoBoardAssembler referencias)
    {
        this.referencias = referencias;
    }

    public void processar()
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        string result = "int[,] coletaveis = new int[,]{" + Environment.NewLine;

        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = referencias.dicionarioGosBoard[0];
            result += "{";
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goIt = referencias.dicionarioGosBoard[contadorLinha][contadorColuna];
                Sprite spriteIt = goIt.GetComponent<SpriteRenderer>().sprite;

                ColetavelEntidade coletavelEntidade = helperColetavel.getColetavelEntidadeBySprite(spriteIt.name);

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
}
