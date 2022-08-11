using UnityEngine;

public class LevelsScroll : ScrollMovimentador<LevelsScrollDto>
{
    private string[] levels;

    private float posYReferenciaBaixo;
    private float posYReferenciaCima;

    private int contadorBaixoLevel;
    private int contadorCimaLevel;

    private ItemLevelDto itemLevelCima;
    private ItemLevelDto itemLevelBaixo;

    public LevelsScroll(LevelsScrollDto levelsScrollDto)
    {
        carregarLevels();
        calcularTamanhoScroll(levelsScrollDto);
        carregarReferenciasPosicoes(levelsScrollDto);
        popularItensLevels(levelsScrollDto);

        itemLevelCima  = levelsScrollDto.ItensLevelDto[0];
        itemLevelBaixo = levelsScrollDto.ItensLevelDto[levelsScrollDto.ItensLevelDto.Length - 1];
    }

    public override void movimentarParaBaixo(LevelsScrollDto levelsScrollDto)
    {
        float posYItemLevel = itemLevelBaixo.RItem.transform.position.y;
        if(contadorBaixoLevel < levels.Length && posYItemLevel > posYReferenciaBaixo)
        {
            popularItemLevel(itemLevelCima, levels[contadorBaixoLevel]);
            reposicionarLevelItemParaUltimaPosicao(levelsScrollDto);
            contadorBaixoLevel++;
            contadorCimaLevel++;            
            //Debug.Log("movimentarParaBaixo ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
    }

    public override void movimentarParaCima(LevelsScrollDto levelsScrollDto)
    {
        float posYPrateleira = itemLevelCima.RItem.transform.position.y;
        if(contadorCimaLevel > 0 && posYPrateleira < posYReferenciaCima)
        {
            popularItemLevel(itemLevelBaixo, levels[--contadorCimaLevel]);
            reposicionarLevelItemParaPrimeiraPosicao(levelsScrollDto);
            contadorBaixoLevel--;            
            //Debug.Log("movimentarParaCima ACIONADO contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
        }
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
        float yDiferenca = (levelsScrollDto.ItensLevelDto[0].RItem.position.y - levelsScrollDto.ItensLevelDto[1].RItem.position.y);
        posYReferenciaCima = levelsScrollDto.RTransformRefCima.position.y + yDiferenca;        
        //Debug.Log("posYReferenciaBaixo " + posYReferenciaBaixo + " posYReferenciaCima " + posYReferenciaCima);
    }

    private void reposicionarLevelItemParaUltimaPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posBaixo = itemLevelBaixo.RItem.anchoredPosition;
        float haltura = posBaixo.y - levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        itemLevelCima.RItem.anchoredPosition = new Vector2(posBaixo.x, haltura);
        itemLevelCima.RItem.gameObject.SetActive(true);

        itemLevelBaixo = itemLevelCima;
        int indiceItem = (int.Parse(itemLevelCima.RItem.name) + 1) % levelsScrollDto.ItensLevelDto.Length;
        itemLevelCima = levelsScrollDto.ItensLevelDto[indiceItem];
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posCima = itemLevelCima.RItem.anchoredPosition;
        float haltura = posCima.y + levelsScrollDto.ItensLevelDto[0].RItem.rect.height;
        itemLevelBaixo.RItem.anchoredPosition = new Vector2(posCima.x, haltura);        

        itemLevelCima = itemLevelBaixo;
        int indicePrateleira = ((int.Parse(itemLevelBaixo.RItem.name) + levelsScrollDto.ItensLevelDto.Length) - 1) % levelsScrollDto.ItensLevelDto.Length;
        itemLevelBaixo = levelsScrollDto.ItensLevelDto[indicePrateleira];
    }

    private void popularItensLevels(LevelsScrollDto levelsScrollDto)
    {
        for(int contadorItensLevels = 0; contadorItensLevels < levelsScrollDto.ItensLevelDto.Length; contadorItensLevels++)
        {
            popularItemLevel(levelsScrollDto.ItensLevelDto[contadorItensLevels], levels[contadorItensLevels]);            
            contadorBaixoLevel++;
        }
        //Debug.Log("Populado contadorcima " + contadorCimaLevel + " contadorbaixo " + contadorBaixoLevel);
    }

    private void popularItemLevel(ItemLevelDto itemLevelDtoIt, string levelAlias)
    {   
        AbstractLevel level = LevelHelper.getLevelByString(levelAlias);
        string levelName = level.getLevelName();
        itemLevelDtoIt.LblLevel.text = levelName;
        itemLevelDtoIt.LblMap.text = level.getNameMap();

        //Debug.Log("level alias " + levelAlias + " level name " + levelName + " nome componente" + itemLevelDtoIt.LblLevel.transform.parent.name);
    }
}
