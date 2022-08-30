public class FactoryLevelEntidade 
{
    public static LevelEntidade[] factory()
    {
        return new LevelEntidade[] {

            new LevelEntidade(Level.HUM   , Level1.getFornecedor()),
            new LevelEntidade(Level.DOIS  , Level2.getFornecedor()),
            new LevelEntidade(Level.TRES  , Level3.getFornecedor()),
            new LevelEntidade(Level.QUATRO, Level4.getFornecedor()),
            new LevelEntidade(Level.CINCO , Level5.getFornecedor()),
            new LevelEntidade(Level.SEIS  , Level6.getFornecedor()),
            new LevelEntidade(Level.SETE  , Level7.getFornecedor()),
            new LevelEntidade(Level.OITO  , Level8.getFornecedor()),

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
