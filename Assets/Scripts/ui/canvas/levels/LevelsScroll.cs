using UnityEngine;

public class LevelsScroll : ScrollMovimentador<LevelsScrollDto>
{
    private string[] levels;

    private float posYReferenciaBaixo;
    private float posYReferenciaCima;

    private int contadorLevels;

    private RectTransform itemLevelCima;
    private RectTransform itemLevelBaixo;

    public LevelsScroll(LevelsScrollDto levelsScrollDto)
    {
        carregarLevels();
        calcularTamanhoScroll(levelsScrollDto);
        carregarReferenciasPosicoes(levelsScrollDto);
        popularItensLevels(levelsScrollDto);

        itemLevelCima  = levelsScrollDto.ItensLevelDto[0].RItem;
        itemLevelBaixo = levelsScrollDto.ItensLevelDto[levelsScrollDto.ItensLevelDto.Length - 1].RItem;
    }

    public override void movimentarParaBaixo(LevelsScrollDto levelsScrollDto)
    {
        float posYItemLevel = itemLevelBaixo.transform.position.y;
        if(contadorLevels < levels.Length && posYItemLevel > posYReferenciaBaixo)
        {
            reposicionarLevelItemParaUltimaPosicao(levelsScrollDto);
            contadorLevels++;
        }
        Debug.Log("movimentarParaBaixo CHAMADO");
    }

    public override void movimentarParaCima(LevelsScrollDto levelsScrollDto)
    {
        float posYPrateleira = itemLevelCima.transform.position.y;
        if(contadorLevels > 0 && posYPrateleira < posYReferenciaCima)
        {
            reposicionarLevelItemParaPrimeiraPosicao(levelsScrollDto);
            contadorLevels--;            
        }
        Debug.Log("movimentarParaCima CHAMADO");
    }

    private void carregarLevels()
    {
        levels = LevelHelper.getAllLevelsMapsAlias();
        Debug.Log("QTD LEVELS " + levels.Length);
    }

    private void calcularTamanhoScroll(LevelsScrollDto levelsScrollDto)
    {
        float qtdItens = levels.Length - levelsScrollDto.QtdItensVisiveis;
        float yAcrescimo = qtdItens * levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        levelsScrollDto.RTransformScroll.offsetMin += new Vector2(0, -yAcrescimo);
    }

    private void carregarReferenciasPosicoes(LevelsScrollDto levelsScrollDto)
    {
        posYReferenciaBaixo = levelsScrollDto.RTransformRefBaixo.position.y;
        posYReferenciaCima = levelsScrollDto.RTransformRefCima.position.y;
    }

    private void reposicionarLevelItemParaUltimaPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posBaixo = itemLevelBaixo.anchoredPosition;
        float haltura = posBaixo.y - levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        itemLevelCima.anchoredPosition = new Vector2(posBaixo.x, haltura);
        itemLevelCima.gameObject.SetActive(true);

        itemLevelBaixo = itemLevelCima;
        int indiceItem = (int.Parse(itemLevelCima.name) + 1) % levelsScrollDto.ItensLevelDto.Length;
        itemLevelCima = levelsScrollDto.ItensLevelDto[indiceItem].RItem;
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posCima = itemLevelCima.anchoredPosition;
        float haltura = posCima.y + levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        itemLevelBaixo.anchoredPosition = new Vector2(posCima.x, haltura);
        itemLevelBaixo.gameObject.SetActive(true);

        itemLevelCima = itemLevelBaixo;
        int indicePrateleira = ((int.Parse(itemLevelBaixo.name) + levelsScrollDto.ItensLevelDto.Length) - 1) % levelsScrollDto.ItensLevelDto.Length;
        itemLevelBaixo = levelsScrollDto.ItensLevelDto[indicePrateleira].RItem;
    }

    private void popularItensLevels(LevelsScrollDto levelsScrollDto)
    {
        for(int contadorItensLevels = 1; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        {
            ItemLevelDto itemLevelDtoIt = levelsScrollDto.ItensLevelDto[contadorItensLevels];
            string levelAlias = levels[contadorItensLevels - 1];
            AbstractLevel level = LevelHelper.getLevelByString(levelAlias);
            string levelName = level.getLevelName();
            itemLevelDtoIt.LblLevel.text = levelName;
            contadorLevels++;
            Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
        }
    }
}
