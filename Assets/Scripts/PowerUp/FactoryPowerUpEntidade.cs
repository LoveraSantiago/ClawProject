using UnityEngine;

public class FactoryPowerUpEntidade 
{
    private static PowerUpEntidade bombaDaGarra;
    private static PowerUpEntidade missilNuclear;
    private static PowerUpEntidade minaTerrestre;
    private static PowerUpEntidade missilTeleguiado;
    private static PowerUpEntidade teleporte;
    private static PowerUpEntidade asa;
    private static PowerUpEntidade rollback;
    private static PowerUpEntidade descarte;

    private static PowerUpEntidade getBombaDaGarra()
    {
        if (bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.BOMBA_DA_GARRA, "Bomba", "bomba")
                .configDuracao(9)                
                .configSupplierDePowerUpGo(BombaPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Jogue uma bomba nos coletaveis para espalhar suas posições.", 
                    "A bomba é segurada pela garra e no momento exato toque na tela para que ela solte em cima do seu alvo. Você tem 9 segundos antes que ela solte em um lugar aleatorio.");
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
                .configSupplierDePowerUpGo(MissilNuclearPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Jogue uma bomba de grande raio de explosão nos coletaveis para espalhar suas posições.",
                    "A bomba nuclear é segurada pela garra e no momento exato toque na tela para que ela solte em cima do seu alvo. Você tem 9 segundos antes que ela solte em um lugar aleatorio.");
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
                    "Plante uma mina de explosão terrestre nos coletaveis para espalhar suas posições.",
                    "Arraste o botão da mina terrestre para a area azulada indicada. Um explosão abaixo dos coletaveis é acionada quando a mina é solta no lugar que foi posicionada.");
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
                .configSupplierDePowerUpGo(MissilTeleguiadoPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Acerte um missil teleguiado no coletavel de interesse para mudar a posição atual dele.",
                    "Selecione a mira do coletavel de interesse a ser acertado pelo missil teleguiado.");
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
                .configSupplierDePowerUpGo(TeleportePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis para mudar suas respectivas posições.",
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
                .configSupplierDePowerUpGo(AsaPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Dê um par de asas ao coletavel do seu interesse para que ele alcance a liberdade.",
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
                .configSupplierDePowerUpGo(RollbackPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Selecione um coletado para retornar ao board para tentar uma melhor combinação de coletados.",
                    "Selecione no display de coletados o coletado que deseja ser retornado ao boarde.");
        }
        return rollback;
    }

    private static PowerUpEntidade getDescarte()
    {
        if(descarte == null)
        {
            descarte = new PowerUpEntidade()
                .configNomes(PowerUpEntidade.TIPO.DESCARTE, "Descarte", "descarte-botao")
                .configDuracao(9)
                .configSupplierDePowerUpGo(DescartePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao("Descarte um coletado para tentar uma melhor combinação de coletados.",
                "Selecione no display de coletados o coletado que deseja ser descartado.");
        }
        return descarte;
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
            case PowerUpEntidade.TIPO.DESCARTE         : return getDescarte();
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
            getRollBack(),
            getDescarte()
        };
    }

    public static PowerUpEntidade getPowerUpFromIndice(int indice)
    {
        return getAllPowerUps()[indice];
    }

    public static Sprite[] getAllSpritesPowerUp()
    {
        PowerUpEntidade[] allPups = getAllPowerUps();
        Sprite[] sprites = new Sprite[allPups.Length];
        for(int contador = 0; contador < sprites.Length; contador++)
        {
            sprites[contador] = allPups[contador].sprPowerUp;
        }
        return sprites;
    }
}
