using System;
using UnityEngine;

public abstract class BoardCleaner 
{    
    private ReferenciasDoBoard referenciasDoBoard;
    private NavegacaoPeloBoard navegacao;
    private Func<Sprite> fornecedorSpriteVazio;

    public BoardCleaner(
        ReferenciasDoBoard referenciasDoBoard,
        NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio)
    {     
        this.navegacao = navegacao;
        this.referenciasDoBoard = referenciasDoBoard;
        this.fornecedorSpriteVazio = fornecedorSpriteVazio;
    }

    protected abstract bool isSextoElementoTipoLinha(int linha, int coluna);

    public virtual void clean()
    {
        int qtdLinhas = referenciasDoBoard.getQtdLinhasDoBoard();
        for (int contadorLinha = 0; contadorLinha < qtdLinhas; contadorLinha++)
        {            
            int qtdColunas = referenciasDoBoard.getQtdColunasDoBoard(contadorLinha);
            for (int contadorColuna = 0; contadorColuna < qtdColunas; contadorColuna++)
            {
                bool estadoGo = false;
                if (isSextoElementoTipoLinha(contadorLinha, contadorColuna))
                {
                    estadoGo = false;
                    cleanElement(contadorLinha, contadorColuna, referenciasDoBoard, false);                    
                }
                else
                {
                    estadoGo = true;
                    cleanElement(contadorLinha, contadorColuna, referenciasDoBoard, true);                    
                }

                referenciasDoBoard.cleanElementoGo(contadorLinha, contadorColuna, estadoGo, fornecedorSpriteVazio.Invoke());
            }
        }
        navegacao.resetMira();
    }

    protected abstract void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoard referencias, bool estado);

    protected bool isSextoElementoLinhaPar(int linha, int coluna)
    {
        return linha % 2 != 0 && coluna == 6;
    }

    protected bool isSextoElementoLinhaImpar(int linha, int coluna)
    {
        return linha % 2 == 0 && coluna == 6;
    }
}
