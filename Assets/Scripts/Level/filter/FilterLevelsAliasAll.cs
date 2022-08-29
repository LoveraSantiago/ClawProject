using System.Collections.Generic;

public class FilterLevelsAliasAll : FilterLevelsAlias
{
    protected override void filtrar(List<string> levelAlias, LevelEntidade levelEntidade)
    {
        levelAlias.Add(levelEntidade.level.ToString());
    }
}
