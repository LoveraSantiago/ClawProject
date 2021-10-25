using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RemontadorBoard
{
    private ListaDeSprites listaDeSprites;
    private ReferenciasDoBoardAssembler referencias;

    public RemontadorBoard(
        ReferenciasDoBoardAssembler referencias, ListaDeSprites listaDeSprites)
    {
        this.listaDeSprites = listaDeSprites;
        this.referencias = referencias;
    }

    public void montarColetaveis(int[,] arrayDeColetaveis, Action<GameObject, Sprite> consumidorDeSprite)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();

        for (int contadorLinha = 0; contadorLinha < arrayDeColetaveis.GetLength(0); contadorLinha++)
        {
            Dictionary<int, GameObject>  referenciasLinha = referencias.dicionarioGosBoard[contadorLinha];
            for (int contadorColuna = 0; contadorColuna < referenciasLinha.Count; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade  = coletavelHelper.getColetavelEntidadeById(id);

                if (coletavelEntidade.isVazio())
                {
                    continue;
                }
                else if (coletavelEntidade.isRandom())
                {
                    consumidorDeSprite.Invoke(referenciasLinha[contadorColuna], listaDeSprites.getSpriteRandom());                    
                }
                else
                {
                    string nomeSprite = coletavelEntidade.nomeSprite;
                    Sprite spr = listaDeSprites.getSpriteByName(nomeSprite);
                    consumidorDeSprite.Invoke(referenciasLinha[contadorColuna], spr);
                }
            }
        }
    }

    public void montarLabels(BoardOrdem[] boardOrdem)
    {
        if (boardOrdem == null)
        {
            return;
        }

        int contadorNome = 0;
        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioTextLabels.Count; contadorLinha++)
        {
            Dictionary<int, Text> dicionarioLinha = referencias.dicionarioTextLabels[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goReferencias = referencias.dicionarioGosBoard[contadorLinha][contadorColuna];
                SpriteRenderer sprRenderer = goReferencias.GetComponent<SpriteRenderer>();
                if (!sprRenderer.sprite.name.Equals(listaDeSprites.getSpriteVazio().name))
                {
                    int nomeOrdem = contadorNome + 1;
                    BoardOrdem boardOrdemIt = getOrdemByNome(nomeOrdem, boardOrdem);
                    if(boardOrdem != null)
                    {
                        Text text = referencias.dicionarioTextLabels[contadorLinha][contadorColuna];
                        text.text = boardOrdemIt.ordem.ToString();
                    }
                    contadorNome++;
                }                
            }
        }
    }

    private BoardOrdem getOrdemByNome(int nomeOrdem, BoardOrdem[] boardOrdem)
    {
        string nomeOrdemString = nomeOrdem.ToString();
        for(int contador = 0; contador < boardOrdem.Length; contador++)
        {
            if (boardOrdem[contador].nome.Equals(nomeOrdemString))
            {
                return boardOrdem[contador];
            }
        }
        return null;
    }

}
