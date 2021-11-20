using System.Collections.Generic;

public class LevelHelper
{
    private static Dictionary<Level, LevelEntidade> dicionarioDeEnum = inicializarDicionarioDeEnum();
    private static Dictionary<string, LevelEntidade> dicionarioDeAlias;

    public static AbstractLevel getLevelByEnum(Level level)
    {
        return dicionarioDeEnum[level].supplierLevel.fornecer();
    }

    public static AbstractLevel getLevelByString(string level)
    {
        return dicionarioDeAlias[level].supplierLevel.fornecer();
    }

    private static Dictionary<Level, LevelEntidade> inicializarDicionarioDeEnum()
    {
        Dictionary<Level, LevelEntidade> dicionarioDeEnum = new Dictionary<Level, LevelEntidade>();

        LevelEntidade[] levelsEntidades = LevelEntidade.getLevelsEntidades();
        for(int contador = 0; contador < levelsEntidades.Length; contador++)
        {
            LevelEntidade levelEntidade = levelsEntidades[contador];
            dicionarioDeEnum.Add(levelEntidade.level, levelEntidade);
        }
        return dicionarioDeEnum;
    }

    private static Dictionary<string, LevelEntidade> inicializarDicionarioDeAlias()
    {
        Dictionary<string, LevelEntidade>  dicionarioDeAlias = new Dictionary<string, LevelEntidade>();

        LevelEntidade[] levelsEntidades = LevelEntidade.getLevelsEntidades();
        for (int contador = 0; contador < levelsEntidades.Length; contador++)
        {
            LevelEntidade levelEntidade = levelsEntidades[contador];
            dicionarioDeAlias.Add(levelEntidade.alias, levelEntidade);
        }
        return dicionarioDeAlias;
    }
}
