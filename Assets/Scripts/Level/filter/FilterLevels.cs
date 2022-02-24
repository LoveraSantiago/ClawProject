using System.Collections.Generic;

public abstract class FilterLevels : Consumidor<LevelEntidade>
{
    private List<string> levelAlias;

    public FilterLevels()
    {
        levelAlias = new List<string>();
        levelAlias.Add("-");
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
