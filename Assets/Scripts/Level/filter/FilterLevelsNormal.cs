using System.Collections.Generic;

public class FilterLevelsNormal : FilterLevels
{
    protected override void filtrar(List<string> levelAlias, LevelEntidade levelEntidade)
    {
        Fornecedor<AbstractLevel> fornecedorLevel = levelEntidade.supplierLevel;
        AbstractLevel level = fornecedorLevel.fornecer();

        if (!LevelUtils.isObstaculoLevel(level))
        {
            levelAlias.Add(levelEntidade.level.ToString());
        }                
    }
}
