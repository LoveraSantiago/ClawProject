using UnityEngine;

public class FactoryPowerUpEntidade 
{
    private static PowerUpEntidade bombaDaGarra;
    private static PowerUpEntidade missilNuclear;
    private static PowerUpEntidade minaTerrestre;
    private static PowerUpEntidade missilTeleguiado;
    private static PowerUpEntidade igual;
    private static PowerUpEntidade teleporte;
    private static PowerUpEntidade miniAsas;
    private static PowerUpEntidade asa;
    private static PowerUpEntidade rollback;
    private static PowerUpEntidade descarte;

    private static PowerUpEntidade getBombaDaGarra()
    {
        if (bombaDaGarra == null)
        {
            bombaDaGarra = new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.BOMBA_DA_GARRA, "Bomba", "bomba")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
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
                .configNomes(PowerUpEnums.TIPO.MISSIL_NUCLEAR, "Bomba Nuclear", "nuclear-bomba-btn")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)                
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
                .configNomes(PowerUpEnums.TIPO.MINA_TERRESTRE, "Mina Terrestre", "mina-terrestre")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configPreco(2)
                .configDuracao(3)
                .configArea(PowerUpEnums.AREA.CHAO)
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
                .configNomes(PowerUpEnums.TIPO.MISSIL_TELEGUIADO, "Missil Teleguiado", "missil-btnv2")
                .configFamilia(PowerUpEnums.FAMILIA.EXPLOSIVOS)
                .configPreco(2)
                .configDuracao(9)                
                .configSupplierDePowerUpGo(MissilTeleguiadoPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Acerte um missil teleguiado no coletavel de interesse para mudar a posição atual dele.",
                    "Selecione a mira do coletavel de interesse a ser acertado pelo missil teleguiado.");
        }
        return missilTeleguiado;
    }

    private static PowerUpEntidade getIgual()
    {
        if(igual == null)
        {
            igual = new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.IGUAL, "Igual", "igual-botao")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(IgualPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis para mudar suas respectivas posições.",
                    "Selecione o primeiro coletavel a ser igualado com o segundo coletavel.");
        }
        return igual;
    }

    private static PowerUpEntidade getTeleporte()
    {
        if(teleporte == null)
        {
            teleporte = new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.TELEPORTE, "Tele-Transporte", "teleport-btn")
                .configFamilia(PowerUpEnums.FAMILIA.TRANSMUTACAO)
                .configPreco(3)
                .configDuracao(9)         
                .configSupplierDePowerUpGo(TeleportePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configDescricao(
                    "Troque as posições de um par de coletaveis para mudar suas respectivas posições.",
                    "Selecione o primeiro coletavel a ser trocado de lugar. Selecione o segundo coletavel que será trocado de posicao com o primeiro");
        }
        return teleporte;
    }

    private static PowerUpEntidade getMiniAsas()
    {
        if(miniAsas == null)
        {
            miniAsas = new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.MINI_ASAS, "Mini Asas de Escape", "mini-asas-botao")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(AsaMiniPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Dê um par de mini asas ao coletavel do seu interesse para que ele tente alcançar a liberdade.",
                    "Selecione o coletavel de interesse a tentar alcançar a liberdade.");
        }
        return miniAsas;
    }

    private static PowerUpEntidade getAsas()
    {
        if(asa == null)
        {
            asa = new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.ASAS, "Asas da Liberdade", "asas-botao")
                .configFamilia(PowerUpEnums.FAMILIA.LEVITACAO)
                .configPreco(4)
                .configDuracao(9)                
                .configSupplierDePowerUpGo(AsaPowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao(
                    "Dê um par de asas ao coletavel do seu interesse para que ele alcance a liberdade.",
                    "Selecione o coletavel de interesse a alcançar a liberdade.");
        }
        return asa;
    }

    private static PowerUpEntidade getRollBack()
    {
        if(rollback == null)
        {
            rollback = new PowerUpEntidade()
                .configNomes(PowerUpEnums.TIPO.ROLLBACK, "Rollback", "rollback-botao")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
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
                .configNomes(PowerUpEnums.TIPO.DESCARTE, "Descarte", "descarte-botao")
                .configFamilia(PowerUpEnums.FAMILIA.MECANISMO)
                .configPreco(2)
                .configDuracao(9)
                .configSupplierDePowerUpGo(DescartePowerUpGo.getFornecedor())
                .configIsClicavel(true)
                .configIsColetavel(true)
                .configDescricao("Descarte um coletado para tentar uma melhor combinação de coletados.",
                "Selecione no display de coletados o coletado que deseja ser descartado.");
        }
        return descarte;
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

    public static string getNomePupByTipo(PowerUpEnums.TIPO tipo)
    {
        PowerUpEntidade[] allPups = getAllPowerUps();
        for(int contador = 0; contador < allPups.Length; contador++)
        {
            if(allPups[contador].tipo == tipo)
            {
                return allPups[contador].nome;
            }
        }
        return null;
    }

    public static string[] getNomesPupsBySprites(Sprite[] sprites)
    {
        PowerUpEntidade[] allPups = getAllPowerUps();
        string[] result = new string[sprites.Length];
        for(int contador = 0; contador < sprites.Length; contador++)
        {
            result[contador] = getPupNomeBySprite(allPups, sprites[contador]);
        }
        return result;
    }

    private static string getPupNomeBySprite(PowerUpEntidade[] allPups, Sprite sprite)
    {
        for(int contador = 0; contador < allPups.Length; contador++)
        {
            if(allPups[contador].sprPowerUp == sprite)
            {
                return allPups[contador].nome;
            }
        }
        return null;
    }
}
