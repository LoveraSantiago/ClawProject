using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardCleaner 
{    
    private ReferenciasDoBoardAssembler referenciasDoBoard;
    private NavegacaoPeloBoard navegacao;
    private Func<Sprite> fornecedorSpriteVazio;

    public BoardCleaner(
        ReferenciasDoBoardAssembler referenciasDoBoard,
        NavegacaoPeloBoard navegacao,
        Func<Sprite> fornecedorSpriteVazio)
    {     
        this.navegacao = navegacao;
        this.referenciasDoBoard = referenciasDoBoard;
        this.fornecedorSpriteVazio = fornecedorSpriteVazio;
    }

    protected abstract bool isSextoElementoTipoLinha(int linha, int coluna);

    public void clean()
    {        
        for (int contadorLinha = 0; contadorLinha < referenciasDoBoard.dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject> dicionarioLinha = referenciasDoBoard.dicionarioGosBoard[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goIt = referenciasDoBoard.dicionarioGosBoard[contadorLinha][contadorColuna];                
                Preenchedor.colocarSprVazio(goIt, fornecedorSpriteVazio.Invoke());
                

                //Debug.Log("linha " + contadorLinha + " coluna " + contadorColuna);
                if (isSextoElementoTipoLinha(contadorLinha, contadorColuna))
                {
                    goIt.SetActive(false);
                    cleanElement(contadorLinha, contadorColuna, referenciasDoBoard, false);                    
                }
                else
                {
                    goIt.SetActive(true);
                    cleanElement(contadorLinha, contadorColuna, referenciasDoBoard, true);                    
                }
            }
        }
        navegacao.resetMira();
    }

    protected abstract void cleanElement(int indiceLinha, int indiceColuna, ReferenciasDoBoardAssembler referencias, bool estado);

    protected bool isSextoElementoLinhaPar(int linha, int coluna)
    {
        return linha % 2 != 0 && coluna == 6;
    }

    protected bool isSextoElementoLinhaImpar(int linha, int coluna)
    {
        return linha % 2 == 0 && coluna == 6;
    }
}
