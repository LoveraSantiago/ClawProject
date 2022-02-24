using System.Collections.Generic;

public class FilterLevelsAll : FilterLevels
{
    protected override void filtrar(List<string> levelAlias, LevelEntidade levelEntidade)
    {
        levelAlias.Add(levelEntidade.level.ToString());
    }
}
