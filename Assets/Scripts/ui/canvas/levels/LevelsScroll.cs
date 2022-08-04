using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScroll : ScrollMovimentador<LevelsScrollDto>
{
    private string[] levels;

    private float posYReferenciaBaixo;
    private float posYReferenciaCima;

    private int contadorBaixoLevels;
    private int contadorCimaLevels;

    private RectTransform itemLevelCima;
    private RectTransform itemLevelBaixo;

    public LevelsScroll(LevelsScrollDto levelsScrollDto)
    {
        carregarLevels();
        calcularTamanhoScroll(levelsScrollDto);
        carregarReferenciasPosicoes(levelsScrollDto);

        itemLevelCima  = levelsScrollDto.RItens[0];
        itemLevelBaixo = levelsScrollDto.RItens[levelsScrollDto.RItens.Length - 1];
    }

    public override void movimentarParaBaixo(LevelsScrollDto levelsScrollDto)
    {
        float posYItemLevel = itemLevelBaixo.transform.position.y;
        if(contadorBaixoLevels < levels.Length && posYItemLevel > posYReferenciaBaixo)
        {
            reposicionarLevelItemParaUltimaPosicao(levelsScrollDto);
            contadorBaixoLevels++;
        }
    }

    public override void movimentarParaCima(LevelsScrollDto levelsScrollDto)
    {
        
    }

    private void carregarLevels()
    {
        levels = LevelHelper.getAllLevelsMapsAlias();
        Debug.Log("QTD LEVELS " + levels.Length);
    }

    private void calcularTamanhoScroll(LevelsScrollDto levelsScrollDto)
    {
        float qtdItens = levels.Length - levelsScrollDto.QtdItensVisiveis;
        float yAcrescimo = qtdItens * levelsScrollDto.RItens[0].rect.height;
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
        float haltura = posBaixo.y - levelsScrollDto.RItens[0].rect.height;
        itemLevelCima.anchoredPosition = new Vector2(posBaixo.x, haltura);

        itemLevelBaixo = itemLevelCima;
        int indiceItem = (int.Parse(itemLevelCima.name) + 1) % levelsScrollDto.RItens.Length;
        itemLevelCima = levelsScrollDto.RItens[indiceItem];
    }
}
