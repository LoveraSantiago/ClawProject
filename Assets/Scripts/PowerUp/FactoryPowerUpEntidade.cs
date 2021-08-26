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
                .configNomes(PowerUpEntidade.TIPO.BOMBA_DA_GARRA, "Bomba", "bomba")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(BombaPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "-", 
                    "-");
        }
        return bombaDaGarra;
    }

    private static PowerUpEntidade getMissilNuclear()
    {
        if (missilNuclear == null)
        {
            missilNuclear = new PowerUpEntidade()                
                .configNomes(PowerUpEntidade.TIPO.MISSIL_NUCLEAR, "Bomba Nuclear", "nuclear-bomba-btn")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(MissilNuclearPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "-",
                    "-");
        }
        return missilNuclear;
    }

    private static PowerUpEntidade getMinaTerrestre()
    {
        if (minaTerrestre == null)
        {
            minaTerrestre = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.MINA_TERRESTRE, "Mina Terrestre", "mina-terrestre")
                .configDuracao(3)
                .configArea(PowerUpEntidade.AREA.CHAO)
                .configSupplierDePowerUpGo(MinaTerrestrePowerUpGo.getFornecedor())
                .configIsClicavel(false)
                .configDescricao(
                    "-",
                    "-");
        }
        return minaTerrestre;
    }

    private static PowerUpEntidade getMissilTeleguiado()
    {
        if (missilTeleguiado == null)
        {
            missilTeleguiado = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.MISSIL_TELEGUIADO, "Missil Teleguiado", "missil-btnv2")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(MissilTeleguiadoPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "-",
                    "-");
        }
        return missilTeleguiado;
    }

    private static PowerUpEntidade getTeleporte()
    {
        if(teleporte == null)
        {
            teleporte = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.TELEPORTE, "Tele-Transporte", "teleport-btn")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(TeleportePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "-",
                    "-");
        }
        return teleporte;
    }

    private static PowerUpEntidade getAsas()
    {
        if(asa == null)
        {
            asa = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.ASAS, "Asas da Liberdade", "asas-botao")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(AsaPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "-",
                    "-");
        }
        return asa;
    }

    private static PowerUpEntidade getRollBack()
    {
        if(rollback == null)
        {
            rollback = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.ROLLBACK, "Rollback", "rollback-botao")
                .configDuracao(9)
                .configArea()
                .configSupplierDePowerUpGo(RollbackPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "-",
                    "-");
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
