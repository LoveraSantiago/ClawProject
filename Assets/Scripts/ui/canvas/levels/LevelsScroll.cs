using System.Collections;
using System.Collections.Generic;
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

        itemLevelCima  = levelsScrollDto.RItens[0];
        itemLevelBaixo = levelsScrollDto.RItens[levelsScrollDto.RItens.Length - 1];
    }

    public override void movimentarParaBaixo(LevelsScrollDto levelsScrollDto)
    {
        float posYItemLevel = itemLevelBaixo.transform.position.y;
        if(contadorLevels < levels.Length && posYItemLevel > posYReferenciaBaixo)
        {
            reposicionarLevelItemParaUltimaPosicao(levelsScrollDto);
            contadorLevels++;
            //Debug.Log("Contador de levels " + contadorLevels);
        }
    }

    public override void movimentarParaCima(LevelsScrollDto levelsScrollDto)
    {
        float posYPrateleira = itemLevelCima.transform.position.y;
        if(contadorLevels > 0 && posYPrateleira < posYReferenciaCima)
        {
            reposicionarLevelItemParaPrimeiraPosicao(levelsScrollDto);
            contadorLevels--;
            //Debug.Log("Contador de levels " + contadorLevels);
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
        itemLevelCima.gameObject.SetActive(true);

        itemLevelBaixo = itemLevelCima;
        int indiceItem = (int.Parse(itemLevelCima.name) + 1) % levelsScrollDto.RItens.Length;
        itemLevelCima = levelsScrollDto.RItens[indiceItem];
    }

    private void reposicionarLevelItemParaPrimeiraPosicao(LevelsScrollDto levelsScrollDto)
    {
        Vector2 posCima = itemLevelCima.anchoredPosition;
        float haltura = posCima.y + levelsScrollDto.RItens[0].rect.height;
        itemLevelBaixo.anchoredPosition = new Vector2(posCima.x, haltura);
        itemLevelBaixo.gameObject.SetActive(true);

        itemLevelCima = itemLevelBaixo;
        int indicePrateleira = ((int.Parse(itemLevelBaixo.name) + levelsScrollDto.RItens.Length) - 1) % levelsScrollDto.RItens.Length;
        itemLevelBaixo = levelsScrollDto.RItens[indicePrateleira];
    }
}
