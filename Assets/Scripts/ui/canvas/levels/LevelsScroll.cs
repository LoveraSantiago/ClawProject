using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsScroll : ScrollMovimentador<LevelsScrollDto>
{
    private string[] levels;    

    public LevelsScroll(LevelsScrollDto levelsScrollDto)
    {
        calcularTamanhoScroll(levelsScrollDto);
    }


    public override void movimentarParaBaixo(LevelsScrollDto levelsScrollDto)
    {
        throw new System.NotImplementedException();
    }

    public override void movimentarParaCima(LevelsScrollDto levelsScrollDto)
    {
        throw new System.NotImplementedException();
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
}
