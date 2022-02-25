using System;
using UnityEngine;

public class ProcessadorDeObstaculos : ProcessadorDeColetaveis
{
    private ControleObstaculos controleObstaculos;

    public ProcessadorDeObstaculos(ReferenciasDoBoardObstaculo referencias, ControleObstaculos controleObstaculos)
        : base(referencias)
    {
        this.controleObstaculos = controleObstaculos;
    }

    public void processarObstaculos()
    {
        string result = "bool[,] gaiolas = new bool[,]{" + Environment.NewLine;

        int totalLinhas = referencias.getQtdLinhasDoBoard();
        for(int contadorLinha = 0; contadorLinha < totalLinhas; contadorLinha++)
        {
            result += "{";
            int totalColunas = referencias.getQtdColunasDoBoard(contadorLinha);
            for(int contadorColuna = 0; contadorColuna < totalColunas; contadorColuna++)
            {
                result += controleObstaculos.getEstadoObstaculo(contadorLinha, contadorColuna).ToString().ToLower() + addVirgula(contadorColuna, totalColunas);
            }
            result += "}" + addNovaLinha(contadorLinha, totalLinhas);
        }
        result += "};";
        Debug.Log(result);
    }
}
