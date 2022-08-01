using System.Collections.Generic;

public abstract class FilterLevelsAlias : Consumidor<LevelEntidade>
{
    private List<string> levelAlias;

    public FilterLevelsAlias()
    {
        levelAlias = new List<string>();
        levelAlias.Add("-");
    }

    protected void somenteNomesLevels()
    {
        levelAlias.Clear();
    }

    public void consumir(LevelEntidade levelEntidade)
    {
        filtrar(levelAlias, levelEntidade);
    }

    protected abstract void filtrar(List<string> levelAlias, LevelEntidade levelEntidade);

    public List<string> getLevelsAlias(GenericPool<string, LevelEntidade> poolDeLevels)
    {
        poolDeLevels.executeEmTodosOsValores(this);
        return levelAlias;
    }
}
