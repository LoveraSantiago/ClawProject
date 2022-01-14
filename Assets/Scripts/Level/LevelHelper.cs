public class LevelHelper
{
    private static GenericPool<Level, LevelEntidade> poolByEnum   = inicializarDicionarioDeEnum();
    private static GenericPool<string, LevelEntidade> poolByAlias = inicializarDicionarioDeAlias();

    public static AbstractLevel getLevelByEnum(Level level)
    {
        LevelEntidade levelEntidade = poolByEnum.getValor(level);
        return levelEntidade.supplierLevel.fornecer();
    }

    public static AbstractLevel getLevelByString(string level)
    {
        LevelEntidade levelEntidade = poolByAlias.getValor(level);
        return levelEntidade.supplierLevel.fornecer();
    }

    public static string[] getAllAliasLevels()
    {
        return poolByAlias.getArrayDeChaves();
    }

    private static GenericPool<Level, LevelEntidade> inicializarDicionarioDeEnum()
    {
        GenericPool<Level, LevelEntidade> dicionarioDeEnum = new GenericPool<Level, LevelEntidade>();

        LevelEntidade[] levelsEntidades = LevelEntidade.getLevelsEntidades();
        for(int contador = 0; contador < levelsEntidades.Length; contador++)
        {
            LevelEntidade levelEntidade = levelsEntidades[contador];
            dicionarioDeEnum.addChaveValor(levelEntidade.level, levelEntidade);
        }
        return dicionarioDeEnum;
    }

    private static GenericPool<string, LevelEntidade> inicializarDicionarioDeAlias()
    {
        GenericPool<string, LevelEntidade>  dicionarioDeAlias = new GenericPool<string, LevelEntidade>();

        LevelEntidade[] levelsEntidades = LevelEntidade.getLevelsEntidades();
        for (int contador = 0; contador < levelsEntidades.Length; contador++)
        {
            LevelEntidade levelEntidade = levelsEntidades[contador];
            dicionarioDeAlias.addChaveValor(levelEntidade.alias, levelEntidade);
        }
        return dicionarioDeAlias;
    }
}
