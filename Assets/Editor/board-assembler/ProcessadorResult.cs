using System.Collections.Generic;
using UnityEngine;

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
        string result = "{";

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
            string separadorFim = contadorLinha == referencias.dicionarioGosBoard.Count - 1 ? "" : ", ";
            result += "}" + separadorFim;
        }
        result += "}";
        Debug.Log(result);
    }
    //Resultado deve ser colocado como:
    //int[,] x = new int[,]  { { 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0} };
}
