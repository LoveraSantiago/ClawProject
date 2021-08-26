public class FactoryPowerUpEntidade 
{
    private static PowerUpEntidade bombaDaGarra;
    private static PowerUpEntidade missilNuclear;
    private static PowerUpEntidade minaTerrestre;
    private static PowerUpEntidade missilTeleguiado;
    private static PowerUpEntidade teleporte;
    private static PowerUpEntidade asa;
    private static PowerUpEntidade rollback;

    private static PowerUpEntidade getBombaDaGarra()
    {
        if (bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.BOMBA_DA_GARRA, "bomba")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(BombaPowerUpGo.getFornecedor())
                .configIsClicavel(true);
        }
        return bombaDaGarra;
    }

    private static PowerUpEntidade getMissilNuclear()
    {
        if (missilNuclear == null)
        {
            missilNuclear = new PowerUpEntidade()                
                .configNomes(PowerUpEntidade.TIPO.MISSIL_NUCLEAR, "nuclear-bomba-btn")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(MissilNuclearPowerUpGo.getFornecedor())
                .configIsClicavel(true); 
        }
        return missilNuclear;
    }

    private static PowerUpEntidade getMinaTerrestre()
    {
        if (minaTerrestre == null)
        {
            minaTerrestre = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.MINA_TERRESTRE, "mina-terrestre")
                .configDuracao(3)
                .configArea(PowerUpEntidade.AREA.CHAO)
                .configSupplierDePowerUpGo(MinaTerrestrePowerUpGo.getFornecedor())
                .configIsClicavel(false);
        }
        return minaTerrestre;
    }

    private static PowerUpEntidade getMissilTeleguiado()
    {
        if (missilTeleguiado == null)
        {
            missilTeleguiado = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.MISSIL_TELEGUIADO, "missil-btnv2")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(MissilTeleguiadoPowerUpGo.getFornecedor())
                .configIsClicavel(true); 
        }
        return missilTeleguiado;
    }

    private static PowerUpEntidade getTeleporte()
    {
        if(teleporte == null)
        {
            teleporte = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.TELEPORTE, "teleport-btn")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(TeleportePowerUpGo.getFornecedor())
                .configIsClicavel(true); 
        }
        return teleporte;
    }

    private static PowerUpEntidade getAsas()
    {
        if(asa == null)
        {
            asa = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.ASAS, "asas-botao")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(AsaPowerUpGo.getFornecedor())
                .configIsClicavel(true); 
        }
        return asa;
    }

    private static PowerUpEntidade getRollBack()
    {
        if(rollback == null)
        {
            rollback = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.ROLLBACK, "rollback-botao")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(RollbackPowerUpGo.getFornecedor())
                .configIsClicavel(true);
        }
        return rollback;
    }

    public static PowerUpEntidade getPowerUpEntidadeByEnum(PowerUpEntidade.TIPO tipo)
    {
        switch (tipo)
        {
            case PowerUpEntidade.TIPO.BOMBA_DA_GARRA   : return getBombaDaGarra();
            case PowerUpEntidade.TIPO.MISSIL_NUCLEAR   : return getMissilNuclear();
            case PowerUpEntidade.TIPO.MINA_TERRESTRE   : return getMinaTerrestre();
            case PowerUpEntidade.TIPO.MISSIL_TELEGUIADO: return getMissilTeleguiado();
            case PowerUpEntidade.TIPO.TELEPORTE        : return getTeleporte();
            case PowerUpEntidade.TIPO.ASAS             : return getAsas();
            case PowerUpEntidade.TIPO.ROLLBACK         : return getRollBack();
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
            getTeleporte(),
            getAsas(),
            getRollBack()
        };
    }
}
