using System.Collections.Generic;

public class FilterLevelsAliasMaps : FilterLevelsAlias
{
    public FilterLevelsAliasMaps()
    {
        somenteNomesLevels();
    }

    protected override void filtrar(List<string> levelAlias, LevelEntidade levelEntidade)
    {
        Fornecedor<AbstractLevel> fornecedorLevel = levelEntidade.supplierLevel;
        AbstractLevel level = fornecedorLevel.fornecer();
        if (level.isLevelMap())
        {
            levelAlias.Add(levelEntidade.level.ToString());
        }
    }
}
