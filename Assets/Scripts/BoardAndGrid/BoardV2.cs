using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardV2 
{
    private BoardDto boardDto;
    private int[,] arrayDeColetaveis;
    private ColetavelEntidade.FAMILIA familia;

    public BoardV2(BoardDto boardDto, int[,] arrayDeColetaveis, ColetavelEntidade.FAMILIA familia)
    {
        this.boardDto = boardDto;
        this.arrayDeColetaveis = arrayDeColetaveis;
        this.familia = familia;
        validacaoArray(arrayDeColetaveis);
    }

    public void Create(PoolDeColetaveis poolDeColetaveis)
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        for(int contadorLinha = 0; contadorLinha < boardDto.PosicoesEixoY.Length; contadorLinha++)
        {
            for(int contadorColuna = 0;  contadorColuna < boardDto.PosicoesEixoX.Length; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade = coletavelQuery.getColetavelById(id);

                if (coletavelEntidade.isVazio())
                {
                }
                else if (coletavelEntidade.isRandom())
                {
                }
                else
                {
                    Vector3 posicao = new Vector3(boardDto.PosicoesEixoX[contadorColuna], boardDto.PosicoesEixoY[contadorLinha]);

                    Coletavel coletavel = poolDeColetaveis.criarColetavel();
                    coletavel.receberEntidade(coletavelEntidade);
                    coletavel.colocarNaPosicao(posicao);
                }
            }
        }
    }

        //TODO adicionar validacao para os coletaveis q vazam da maquina
        private void validacaoArray(int[,] arrayDeColetaveis)
    {
        if(arrayDeColetaveis.Length != boardDto.PosicoesEixoY.Length)
        {
            Debug.LogError("QTD DE LINHAS DO ARRAY E DAS POSICOES EIXO Y ESTAO DIFERENTES.");
        }

        if(arrayDeColetaveis.GetLength(0) != boardDto.PosicoesEixoX.Length)
        {
            Debug.LogError("QTD DE COLUNA DO ARRAY E DAS POSICOES EIXO X ESTAO DIFERENTES.");
        }
    }
}
