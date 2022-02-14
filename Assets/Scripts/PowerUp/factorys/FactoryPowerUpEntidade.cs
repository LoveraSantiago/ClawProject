public class FactoryPowerUpEntidade 
{   
    private static PoolPowerUps poolPups;                                         

    public static PowerUpEntidade getPowerUpEntidadeByEnum(PowerUpEnums.TIPO tipo)
    {
        if (poolPups.contem(tipo))
        {
            return poolPups.getValor(tipo);
        }
        return null;
    }

    public static PowerUpEntidade[] getAllPowerUps()
    {
        return poolPups.getArrayDeValores();       
    }

    public static PowerUpEntidade getPowerUpFromIndice(int indice)
    {
        return getAllPowerUps()[indice];
    }

    public static void resetContextoEstatico()
    {
        poolPups = new PoolPowerUps()
            .addPup(PowerUpEnums.TIPO.BOMBA_DA_GARRA   , new FactoryPowerUpBomba())
            .addPup(PowerUpEnums.TIPO.MISSIL_NUCLEAR   , new FactoryPowerUpMissilNuclear())
            .addPup(PowerUpEnums.TIPO.MINA_TERRESTRE   , new FactoryPowerUpMinaTerrestre())
            .addPup(PowerUpEnums.TIPO.MISSIL_TELEGUIADO, new FactoryPowerUpMissilTeleguiado())
            .addPup(PowerUpEnums.TIPO.IGUAL            , new FactoryPowerUpIgual())
            .addPup(PowerUpEnums.TIPO.TELEPORTE        , new FactoryPupTeleporte())            
            .addPup(PowerUpEnums.TIPO.CORINGA          , new FactoryPowerUpCoringa())
            .addPup(PowerUpEnums.TIPO.MINI_ASAS        , new FactoryPowerUpMiniAsas())
            .addPup(PowerUpEnums.TIPO.ASAS             , new FactoryPowerUpAsas())
            .addPup(PowerUpEnums.TIPO.BURACO_NEGRO     , new FactoryPowerUpBuracoNegro())
            .addPup(PowerUpEnums.TIPO.ROLLBACK         , new FactoryPowerUpRollback())
            .addPup(PowerUpEnums.TIPO.DESCARTE         , new FactoryPowerUpDescarte())
            .addPup(PowerUpEnums.TIPO.MOLA             , new FactoryPowerUpMola());
    }
}
