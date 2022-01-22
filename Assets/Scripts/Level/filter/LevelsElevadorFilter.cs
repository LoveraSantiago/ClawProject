using System.Collections.Generic;

public class LevelsElevadorFilter : Consumidor<LevelEntidade>
{
    public List<string> levelAlias { get; private set; }

    public LevelsElevadorFilter()
    {
        levelAlias = new List<string>();
        levelAlias.Add("-");
    }

    public void consumir(LevelEntidade levelEntidade)
    {
        Fornecedor<AbstractLevel> fornecedorLevel = levelEntidade.supplierLevel;
        AbstractLevel level = fornecedorLevel.fornecer();

        if (LevelUtils.isElevadorLevel(level))
        {
            levelAlias.Add(levelEntidade.level.ToString());
        }
    }
}
