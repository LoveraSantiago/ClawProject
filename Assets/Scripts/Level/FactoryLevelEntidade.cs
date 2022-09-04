public class FactoryLevelEntidade 
{
    public static LevelEntidade[] factory()
    {
        return new LevelEntidade[] {

            new LevelEntidade(Level.HUM   , null),
            new LevelEntidade(Level.DOIS  , null),
            new LevelEntidade(Level.TRES  , null),
            new LevelEntidade(Level.QUATRO, null),
            new LevelEntidade(Level.CINCO , null),
            new LevelEntidade(Level.SEIS  , null),
            new LevelEntidade(Level.SETE  , null),
            new LevelEntidade(Level.OITO  , null),

            new LevelEntidade(Level.CACANIQUEL_PUP_G, LevelCacaNiquelPowerUpGeral.getFornecedor()),
            new LevelEntidade(Level.CACANIQUEL_PUP_I, LevelCacaNiquelPowerUpIndividual.getFornecedor()),

            new LevelEntidade(Level.PUP, LevelPowerUp.getFornecedor()),

            new LevelEntidade(Level.COLETAVEL_PAO           , LevelPao.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_MACA          , LevelMaca.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_LEITE         , LevelLeite.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_COCO          , LevelCoco.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_ASPARGO       , LevelAspargo.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_LARANJA       , LevelLaranja.getFornecedor()),
            new LevelEntidade(Level.COLETAVEL_ESTRELAMARINHA, LevelEstrelaMarinha.getFornecedor())
        };
    }
}
