using System;
using UnityEngine;

public class ProcessadorDeColetaveis 
{
    private ReferenciasDoBoard referencias;

    public ProcessadorDeColetaveis(ReferenciasDoBoard referencias)
    {
        this.referencias = referencias;
    }

    public void processar()
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        string result = "int[,] coletaveis = new int[,]{" + Environment.NewLine;

        int totalLinhas = referencias.getQtdLinhasDoBoard();
        for (int contadorLinha = 0; contadorLinha < totalLinhas; contadorLinha++)
        {
            int colunasDalinha = referencias.getQtdColunasDoBoard(contadorLinha);
            result += "{";
            for (int contadorColuna = 0; contadorColuna < colunasDalinha; contadorColuna++)
            {   
                Sprite spriteIt = referencias.getSpriteElementoGo(contadorLinha, contadorColuna);
                ColetavelEntidade coletavelEntidade = helperColetavel.getColetavelEntidadeBySprite(spriteIt.name);

                string separador = contadorColuna == colunasDalinha - 1 ? "" : ", ";
                result += coletavelEntidade.id + separador;
            }
            string separadorFim = contadorLinha == totalLinhas - 1 ? "" : (", " + Environment.NewLine);
            result += "}" + separadorFim;
        }
        result += "};";
        Debug.Log(result);
    }
    //Resultado deve ser colocado como:
    //int[,] x = new int[,]  { { 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0} };
}
