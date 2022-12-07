using UnityEngine;

public class LevelScroll 
{
    private LevelsScrollDto levelsScrollDto;

    private ItemLevelScroll itemAtual;
    private ItemLevelScroll[] itens;

    public LevelScroll(LevelsScrollDto levelsScrollDto)
    {
        this.levelsScrollDto = levelsScrollDto;
        inicializarItensLevelScroll();
        ItemLevelScroll.configurarSpritesEstrelas(levelsScrollDto.MaterialEstrelaDesligada, levelsScrollDto.MaterialEstrelaLigada);
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

    public ItemLevelScroll getPrimeiroItemLevel()
    {
        return getItemLevel(0);
    }

    public ItemLevelScroll getUltimoItemLevel()
    {
        return getItemLevel(getQtdItens() - 1);
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

    public void ligarUltimaImgMaquina()
    {
        if(itemAtual != null)
        {
            itemAtual.ligarImgMaquina();
        }
    }

    public void atualizarItemAtual(int indice)
    {
        itemAtual = getItemLevel(indice);
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
