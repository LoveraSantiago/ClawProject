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
        if (true)//ESTAVA FILTRANDO PARA SABER SE O LEVEL ERA UM LEVEL MAP O TOBE E SER PEGAR SO OS MAPAENUM LEVELS JOGAVEIS
        {
            levelAlias.Add(levelEntidade.level.ToString());
        }
    }
}
