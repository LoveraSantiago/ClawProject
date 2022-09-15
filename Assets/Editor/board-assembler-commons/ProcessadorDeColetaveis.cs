using System;
using UnityEngine;

public class ProcessadorDeColetaveis 
{
    protected ReferenciasDoBoard referencias;

    public ProcessadorDeColetaveis(ReferenciasDoBoard referencias)
    {
        this.referencias = referencias;
    }

    public void processar()
    {        
        string result = "int[,] coletaveis = new int[,]{" + Environment.NewLine;

        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;

        int totalLinhas = referencias.getQtdLinhasDoBoard();
        for (int contadorLinha = 0; contadorLinha < totalLinhas; contadorLinha++)
        {
            int totalColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            result += "{";
            for (int contadorColuna = 0; contadorColuna < totalColunas; contadorColuna++)
            {   
                Sprite spriteIt = referencias.getSpriteElementoGo(contadorLinha, contadorColuna);
                ColetavelEntidade coletavelEntidade = mapaEntidade.getColetavelEntidadeBySprite(spriteIt);

                result += coletavelEntidade.id + addVirgula(contadorColuna, totalColunas);
            }            
            result += "}" + addNovaLinha(contadorLinha, totalLinhas);
        }
        result += "};";
        Debug.Log(result);
    }
    //Resultado deve ser colocado como:
    //int[,] x = new int[,]  { { 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0} };

    protected string addVirgula(int contadorColuna, int totalColunas)
    {
        return contadorColuna == totalColunas - 1 ? "" : ", ";
    }

    protected string addNovaLinha(int contadorLinha, int totalLinhas)
    {
        return contadorLinha == totalLinhas - 1 ? "" : (", " + Environment.NewLine);
    }
}
