using System.Collections.Generic;

public class LevelsObstaculosFilter : Consumidor<LevelEntidade>
{
    public List<string> levelAlias { get; private set; }

    public LevelsObstaculosFilter()
    {
        levelAlias = new List<string>();
        levelAlias.Add("-");
    }

    public void consumir(LevelEntidade levelEntidade)
    {
        Fornecedor<AbstractLevel> fornecedorLevel = levelEntidade.supplierLevel;
        AbstractLevel level = fornecedorLevel.fornecer();
        if (LevelUtils.isObstaculoLevel(level))
        {
            levelAlias.Add(levelEntidade.level.ToString());
        }
    }
}
