public class LevelFlowManager 
{
    public static AbstractLevel getLevelByEnum(Level level)
    {
        switch (level)
        {
            case Level.HUM : return new Level1();
            case Level.DOIS: return new Level2();
            case Level.TRES: return new Level3();
            case Level.QUATRO: return new Level4();
            case Level.PUP: return new LevelPup();
            case Level.COLETAVEL: return new LevelColetavel();
            case Level.CACANIQUEL_PUP_G: return new LevelCacaNiquelPupGeral();
            case Level.CACANIQUEL_PUP_I: return new LevelCacaNiquelPupIndividual();
            default: return null;
        }        
    }

    public static AbstractLevel getLevelByString(string level)
    {
        switch (level)
        {
            case "1": return getLevelByEnum(Level.HUM);
            case "2": return getLevelByEnum(Level.DOIS);
            case "3": return getLevelByEnum(Level.TRES);
            case "4": return getLevelByEnum(Level.QUATRO);
            case "Coletavel": return getLevelByEnum(Level.COLETAVEL);
            case "CacaNiquelIndividual": return getLevelByEnum(Level.CACANIQUEL_PUP_G);
            case "CacaNiquelGeral": return getLevelByEnum(Level.CACANIQUEL_PUP_I);
            case "TreinoPup": return getLevelByEnum(Level.PUP);
            default: return null;
        }        
    }
}

