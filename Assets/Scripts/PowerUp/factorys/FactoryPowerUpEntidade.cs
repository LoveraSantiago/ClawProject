public class FactoryPowerUpEntidade 
{
    private static PropriedadesFactoryPup props;
    private static PoolPowerUps poolPups;

    private static PowerUpEntidade getBombaDaGarra()
    {
        if (props.bomba == null)
        {
            props.bomba = FactoryPupBomba.factory();
        }
        return props.bomba;
    }

    private static PowerUpEntidade getMissilNuclear()
    {
        if (props.missilNuclear == null)
        {
            props.missilNuclear = FactoryPupMissilNuclear.factory();
        }
        return props.missilNuclear;
    }

    private static PowerUpEntidade getMinaTerrestre()
    {
        if (props.minaTerrestre == null)
        {
            props.minaTerrestre = FactoryPupMinaTerrestre.factory();
        }
        return props.minaTerrestre;
    }

    private static PowerUpEntidade getMissilTeleguiado()
    {
        if (props.missilTeleguiado == null)
        {
            props.missilTeleguiado = FactoryPupMissilTeleguiado.factory();
        }
        return props.missilTeleguiado;
    }

    private static PowerUpEntidade getIgual()
    {
        if(props.igual == null)
        {
            props.igual = FactoryPupIgual.factory();
        }
        return props.igual;
    }

    private static PowerUpEntidade getTeleporte()
    {
        if(props.teleporte == null)
        {
            props.teleporte = FactoryPupTeleporte.factory();
        }
        return props.teleporte;
    }

    private static PowerUpEntidade getCoringa()
    {
        if(props.coringa == null)
        {
            props.coringa = FactoryPupCoringa.factory();
        }
        return props.coringa;
    }

    private static PowerUpEntidade getMiniAsas()
    {
        if(props.miniAsas == null)
        {
            props.miniAsas = FactoryPupMiniAsas.factory();
        }
        return props.miniAsas;
    }

    private static PowerUpEntidade getAsas()
    {
        if(props.asa == null)
        {
            props.asa = FactoryPupAsas.factory();
        }
        return props.asa;
    }

    private static PowerUpEntidade getRollBack()
    {
        if(props.rollback == null)
        {
            props.rollback = FactoryPupRollback.factory();
        }
        return props.rollback;
    }

    private static PowerUpEntidade getDescarte()
    {
        if(props.descarte == null)
        {
            props.descarte = FactoryPupDescarte.factory();
        }
        return props.descarte;
    }

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
            case PowerUpEnums.TIPO.BOMBA_DA_GARRA   : return getBombaDaGarra();
            case PowerUpEnums.TIPO.MISSIL_NUCLEAR   : return getMissilNuclear();
            case PowerUpEnums.TIPO.MINA_TERRESTRE   : return getMinaTerrestre();
            case PowerUpEnums.TIPO.MISSIL_TELEGUIADO: return getMissilTeleguiado();
            case PowerUpEnums.TIPO.IGUAL            : return getIgual();
            case PowerUpEnums.TIPO.TELEPORTE        : return getTeleporte();
            case PowerUpEnums.TIPO.CORINGA          : return getCoringa();
            case PowerUpEnums.TIPO.MINI_ASAS        : return getMiniAsas();
            case PowerUpEnums.TIPO.ASAS             : return getAsas();
            case PowerUpEnums.TIPO.ROLLBACK         : return getRollBack();
            case PowerUpEnums.TIPO.DESCARTE         : return getDescarte();            
            default: return null;
        }        
    }

    public static PowerUpEntidade[] getAllPowerUps()
    {
        return new PowerUpEntidade[] {
            getBombaDaGarra(),
            getMissilNuclear(),
            getMinaTerrestre(),
            getMissilTeleguiado(),
            getIgual(),
            getTeleporte(),
            getCoringa(),
            getMiniAsas(),
            getAsas(),
            getRollBack(),
            getDescarte()
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
    }
}
