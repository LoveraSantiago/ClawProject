public class FactoryPowerUpEntidade 
{
    private static PropriedadesFactoryPup props;
    private static PoolPowerUps poolPups;                                      

    private static PowerUpEntidade getMola()
    {
        if(props.mola == null)
        {
            props.mola = FactoryPupMola.factory();
        }
        return props.mola;
    }

    public static PowerUpEntidade getPowerUpEntidadeByEnum(PowerUpEnums.TIPO tipo)
    {
        switch (tipo)
        {               
            
            
            default: return null;
        }        
    }

    public static PowerUpEntidade[] getAllPowerUps()
    {
        return new PowerUpEntidade[] {                      
            
            
        };
    }

    public static PowerUpEntidade getPowerUpFromIndice(int indice)
    {
        return getAllPowerUps()[indice];
    }

    public static void resetContextoEstatico()
    {
        props = new PropriedadesFactoryPup();

        poolPups = new PoolPowerUps();
        poolPups.addPup(PowerUpEnums.TIPO.BOMBA_DA_GARRA   , new FactoryPupBomba())
                .addPup(PowerUpEnums.TIPO.MISSIL_NUCLEAR   , new FactoryPupMissilNuclear())
                .addPup(PowerUpEnums.TIPO.MINA_TERRESTRE   , new FactoryPupMinaTerrestre())
                .addPup(PowerUpEnums.TIPO.MISSIL_TELEGUIADO, new FactoryPupMissilTeleguiado())
                .addPup(PowerUpEnums.TIPO.IGUAL            , new FactoryPupIgual())
                .addPup(PowerUpEnums.TIPO.TELEPORTE        , new FactoryPupTeleporte())            
                .addPup(PowerUpEnums.TIPO.CORINGA          , new FactoryPupCoringa())
                .addPup(PowerUpEnums.TIPO.MINI_ASAS        , new FactoryPupMiniAsas())
                .addPup(PowerUpEnums.TIPO.ASAS             , new FactoryPupAsas())
                .addPup(PowerUpEnums.TIPO.ROLLBACK         , new FactoryPupRollback())
                .addPup(PowerUpEnums.TIPO.DESCARTE         , new FactoryPupDescarte());
    }
}
