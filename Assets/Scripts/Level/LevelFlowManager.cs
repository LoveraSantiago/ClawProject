public class LevelFlowManager 
{
    public enum LEVEL
    {
        HUM, DOIS, TRES, QUATRO,
        COLETAVEL,
        CACANIQUEL_PUP_G, CACANIQUEL_PUP_I,
        PUP,
    }

    public static AbstractLevel getLevelByEnum(LEVEL level)
    {
        switch (level)
        {
            case LEVEL.HUM : return new Level1();
            case LEVEL.DOIS: return new Level2();
            case LEVEL.TRES: return new Level3();
            case LEVEL.QUATRO: return new Level4();
            case LEVEL.PUP: return new LevelPup();
            case LEVEL.COLETAVEL: return new LevelColetavel();
            case LEVEL.CACANIQUEL_PUP_G: return new LevelCacaNiquelPupGeral();
            case LEVEL.CACANIQUEL_PUP_I: return new LevelCacaNiquelPupIndividual();
            default: return null;
        }        
    }

    public static AbstractLevel getLevelByString(string level)
    {
        switch (level)
        {
            case "1": return getLevelByEnum(LEVEL.HUM);
            case "2": return getLevelByEnum(LEVEL.DOIS);
            case "3": return getLevelByEnum(LEVEL.TRES);
            case "4": return getLevelByEnum(LEVEL.QUATRO);
            case "Coletavel": return getLevelByEnum(LEVEL.COLETAVEL);
            case "CacaNiquelIndividual": return getLevelByEnum(LEVEL.CACANIQUEL_PUP_G);
            case "CacaNiquelGeral": return getLevelByEnum(LEVEL.CACANIQUEL_PUP_I);
            case "TreinoPup": return getLevelByEnum(LEVEL.PUP);
            default: return null;
        }        
    }
}

