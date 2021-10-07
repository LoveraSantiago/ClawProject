using System.Collections.Generic;
using UnityEngine;
using System;

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
        ColetavelQuery coletavelQuery = new ColetavelQuery();

        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioGosBoard.Count; contadorLinha++)
        {
            Dictionary<int, GameObject>  referenciasLinha = referencias.dicionarioGosBoard[contadorLinha];
            for (int contadorColuna = 0; contadorColuna < referenciasLinha.Count; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade  = coletavelQuery.getColetavelEntidadeById(id);

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
}
