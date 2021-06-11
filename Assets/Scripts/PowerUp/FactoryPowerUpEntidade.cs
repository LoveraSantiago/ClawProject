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
            bombaDaGarra = new PowerUpEntidade(PowerUpEntidade.NAME.BOMBA_DA_GARRA, 9, "bomba");
        }
        return bombaDaGarra;
    }

    private static PowerUpEntidade getMissilNuclear()
    {
        if (missilNuclear == null)
        {
            missilNuclear = new PowerUpEntidade(PowerUpEntidade.NAME.MISSIL_NUCLEAR, 9, "nuclear-bomba-btn");
        }
        return missilNuclear;
    }

    private static PowerUpEntidade getMinaTerrestre()
    {
        if (minaTerrestre == null)
        {
            minaTerrestre = new PowerUpEntidade(PowerUpEntidade.NAME.MINA_TERRESTRE, 3, PowerUpEntidade.AREA.CHAO, "mina-terrestre");
        }
        return minaTerrestre;
    }

    private static PowerUpEntidade getMissilTeleguiado()
    {
        if (missilTeleguiado == null)
        {
            missilTeleguiado = new PowerUpEntidade(PowerUpEntidade.NAME.MISSIL_TELEGUIADO, 9, "missil-btnv2");
        }
        return missilTeleguiado;
    }

    private static PowerUpEntidade getTeleporte()
    {
        if(teleporte == null)
        {
            teleporte = new PowerUpEntidade(PowerUpEntidade.NAME.TELEPORTE, 9, "teleport-btn");
        }
        return teleporte;
    }

    private static PowerUpEntidade getAsas()
    {
        if(asa == null)
        {
            asa = new PowerUpEntidade(PowerUpEntidade.NAME.ASAS, 9, "asas-botao");
        }
        return asa;
    }

    public static PowerUpEntidade getPowerUpEntidadeByEnum(PowerUpEntidade.NAME name)
    {
        switch (name)
        {
            case PowerUpEntidade.NAME.BOMBA_DA_GARRA: return getBombaDaGarra();
            case PowerUpEntidade.NAME.MISSIL_NUCLEAR: return getMissilNuclear();
            case PowerUpEntidade.NAME.MINA_TERRESTRE: return getMinaTerrestre();
            case PowerUpEntidade.NAME.MISSIL_TELEGUIADO: return getMissilTeleguiado();
            case PowerUpEntidade.NAME.TELEPORTE: return getTeleporte();
            case PowerUpEntidade.NAME.ASAS: return getAsas();
        }
        return null;
    }

}
