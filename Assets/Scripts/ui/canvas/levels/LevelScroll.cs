using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll 
{
    private LevelsScrollDto levelsScrollDto;
    private ItemLevelScroll[] itens;

    public LevelScroll(LevelsScrollDto levelsScrollDto)
    {
        this.levelsScrollDto = levelsScrollDto;
        inicializarItensLevelScroll();
    }

    public int getQtdItens()
    {
        return itens.Length;
    }

    public int getQtdItensVisiveis()
    {
        return levelsScrollDto.QtdItensVisiveis;
    }

    public ItemLevelScroll getItemLevel(int indice)
    {
        return itens[indice];
    }

    public void posicionarOffset(Vector2 posicao)
    {
        levelsScrollDto.RTransformScroll.offsetMin += posicao;
    }

    public float getPosYReferenciaBaixo()
    {
        return levelsScrollDto.RTransformRefBaixo.position.y;
    }

    public float getPosYReferenciaCima()
    {
        return levelsScrollDto.RTransformRefCima.position.y;
    }

    private void inicializarItensLevelScroll()
    {
        int qtdItens = levelsScrollDto.ItensLevelDto.Length;
        itens = new ItemLevelScroll[qtdItens];
        for(int contador = 0; contador < qtdItens; contador++)
        {
            itens[contador] = new ItemLevelScroll(levelsScrollDto.ItensLevelDto[contador]);
        }
    }

}
