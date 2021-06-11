public class FactoryPowerUpEntidade 
{
    private static PowerUpEntidade bombaDaGarra;
    private static PowerUpEntidade missilNuclear;
    private static PowerUpEntidade minaTerrestre;
    private static PowerUpEntidade missilTeleguiado;
    private static PowerUpEntidade teleporte;
    private static PowerUpEntidade asa;

    private static PowerUpEntidade getBombaDaGarra()
    {
        if (bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.NAME.BOMBA_DA_GARRA, "bomba")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(BombaPowerUpGo.getSupplier())
                .configIsClicavel(true);
        }
        return bombaDaGarra;
    }

    private static PowerUpEntidade getMissilNuclear()
    {
        if (missilNuclear == null)
        {
            missilNuclear = new PowerUpEntidade()                
                .configNomes(PowerUpEntidade.NAME.MISSIL_NUCLEAR, "nuclear-bomba-btn")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(MissilNuclearPowerUpGo.getSupplier())
                .configIsClicavel(true); 
        }
        return missilNuclear;
    }

    private static PowerUpEntidade getMinaTerrestre()
    {
        if (minaTerrestre == null)
        {
            minaTerrestre = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.NAME.MINA_TERRESTRE, "mina-terrestre")
                .configDuracao(3)
                .configArea(PowerUpEntidade.AREA.CHAO)
                .configSupplierDePowerUpGo(MinaTerrestrePowerUpGo.getSupplier())
                .configIsClicavel(false);
        }
        return minaTerrestre;
    }

    private static PowerUpEntidade getMissilTeleguiado()
    {
        if (missilTeleguiado == null)
        {
            missilTeleguiado = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.NAME.MISSIL_TELEGUIADO, "missil-btnv2")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(MissilTeleguiadoPowerUpGo.getSupplier())
                .configIsClicavel(true); 
        }
        return missilTeleguiado;
    }

    private static PowerUpEntidade getTeleporte()
    {
        if(teleporte == null)
        {
            teleporte = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.NAME.TELEPORTE, "teleport-btn")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(TeleportePowerUpGo.getSupplier())
                .configIsClicavel(true); 
        }
        return teleporte;
    }

    private static PowerUpEntidade getAsas()
    {
        if(asa == null)
        {
            asa = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.NAME.ASAS, "asas-botao")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(AsaPowerUpGo.getSupplier())
                .configIsClicavel(true); 
        }
        return asa;
    }

    public static PowerUpEntidade getPowerUpEntidadeByEnum(PowerUpEntidade.NAME name)
    {
        switch (name)
        {
            case PowerUpEntidade.NAME.BOMBA_DA_GARRA   : return getBombaDaGarra();
            case PowerUpEntidade.NAME.MISSIL_NUCLEAR   : return getMissilNuclear();
            case PowerUpEntidade.NAME.MINA_TERRESTRE   : return getMinaTerrestre();
            case PowerUpEntidade.NAME.MISSIL_TELEGUIADO: return getMissilTeleguiado();
            case PowerUpEntidade.NAME.TELEPORTE        : return getTeleporte();
            case PowerUpEntidade.NAME.ASAS             : return getAsas();
        }
        return null;
    }

}
