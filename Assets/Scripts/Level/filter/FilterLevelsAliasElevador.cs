using System.Collections.Generic;

public class FilterLevelsAliasElevador : FilterLevelsAlias
{
    protected override void filtrar(List<string> levelAlias, LevelEntidade levelEntidade)
    {
        Fornecedor<AbstractLevel> fornecedorLevel = levelEntidade.supplierLevel;
        AbstractLevel level = fornecedorLevel.fornecer();

        if (LevelUtils.isElevadorLevel(level))
        {
            levelAlias.Add(levelEntidade.level.ToString());
        }        
    }
}
