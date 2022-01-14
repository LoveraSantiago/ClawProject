public class LevelHelper
{
    private static GenericPool<Level, LevelEntidade> poolByEnum = inicializarDicionarioDeEnum();

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

    public static string[] getNormalLevelsAlias()
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
}
