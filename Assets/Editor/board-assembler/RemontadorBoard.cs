using System;
using System.Collections.Generic;
using UnityEngine;

public class RemontadorBoard
{
    private ListaDeSprites listaDeSprites;
    private ReferenciasDoBoard referencias;

    public RemontadorBoard(
        ReferenciasDoBoard referencias, ListaDeSprites listaDeSprites)
    {
        this.listaDeSprites = listaDeSprites;
        this.referencias = referencias;
    }

    public void montarColetaveis(int[,] arrayDeColetaveis, Action<GameObject, Sprite> consumidorDeSprite)
    {
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();

        for (int contadorLinha = 0; contadorLinha < arrayDeColetaveis.GetLength(0); contadorLinha++)
        {
            Dictionary<int, GameObject>  referenciasLinha = referencias.dicionarioGosBoard[contadorLinha];
            for (int contadorColuna = 0; contadorColuna < referenciasLinha.Count; contadorColuna++)
            {
                int id = arrayDeColetaveis[contadorLinha, contadorColuna];
                ColetavelEntidade coletavelEntidade  = helperColetavel.getColetavelEntidadeById(id);

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
