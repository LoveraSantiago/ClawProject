using System.Collections.Generic;
using UnityEngine;

public class HelperColetaveisInGame 
{
    private static PoolDeColetaveis poolDeColetaveis;
    private static Dictionary<string, Material> poolGrayscale;   

    public static int getQtdColetaveisInGame()
    {
        ContadorDeColetaveisInGame contador = new ContadorDeColetaveisInGame();
        poolDeColetaveis.executeEmTodosColetaveis(contador);
        return contador.qtd;        
    }

    public static bool temColetavelInGameByNome(string name)
    {
        return poolDeColetaveis.contemNome(name);
    }

    public static bool temColetavelOvoInGame()
    {
        return poolDeColetaveis.getColetavelPeloGoNome("1").isOvo();
    }

    public static bool naoTemColetavelOvoInGame()
    {
        return !temColetavelOvoInGame();
    }

    public static Coletavel getColetavelInGameByGoName(string name)
    {
        return poolDeColetaveis.getColetavelPeloGoNome(name);
    }

    public static Coletavel[] getColetavelInGameDoTipo(ColetavelEntidade coletavelEntidade)
    {
        return poolDeColetaveis.getTrincaDeColetaveis(coletavelEntidade);
    }

    public static Coletavel getColetavelMaisAlto()
    {
        ProcuradorGOMaisAlto<Coletavel> procurador = new ProcuradorGOMaisAlto<Coletavel>();
        poolDeColetaveis.executeEmTodosColetaveis(procurador);
        return procurador.goMaisAlto;
    }    

    public static void ligarMiraAlvoFinalNoColetavel(string nomeAlvo)
    {
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public static void ligarMirasNosColetaveis(bool filtrarGaiolas)
    {
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras(filtrarGaiolas));
    }

    public static void desligarMirasNosColetaveis()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }

    public static void fixarTodosColetaveisEixoXY()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());
    }

    public static void desafixarTodosColetaveisXY()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
    }

    public static bool isAlgumColetavelAcimaDaHaltura(float haltura)
    {
        return poolDeColetaveis.temEmAlgumColetavel(new AcimaHalturaColetavel(haltura));
    }

    public static void inativarColetavel(Coletavel coletado)
    {
        poolDeColetaveis.inativarColetavel(coletado);
    }

    public static Material getMaterialGrayscaleTo(Coletavel coletavel)
    {
        Sprite spr = coletavel.getSprite();
        if (!poolGrayscale.ContainsKey(spr.name))
        {
            Material material = MaterialGrayScale.of(spr);
            poolGrayscale.Add(spr.name, material);
        }
        return poolGrayscale[spr.name];
    }

    public static Coletavel criarColetavel()
    {
        return poolDeColetaveis.criarColetavel();
    }

    public static Coletavel criarColetavel(GameObject goParent)
    {
        return poolDeColetaveis.criarColetavel(goParent);
    }

    public static Coletavel criarColetavel(Sprite sprite, Vector3 posicao)
    {
        return configColetavel(criarColetavel(), sprite, posicao);
    }

    public static Coletavel criarColetavel(Sprite sprite, Vector3 posicao, GameObject goParent)
    {        
        return configColetavel(criarColetavel(goParent), sprite, posicao);
    }

    private static Coletavel configColetavel(Coletavel coletavel, Sprite sprite, Vector3 posicao)
    {   
        coletavel.receberSprite(sprite);
        coletavel.colocarNaPosicao(posicao);
        coletavel.ligar();
        return coletavel;
    }

    public static void configurar()
    {
        poolDeColetaveis = new PoolDeColetaveis(); ;
        poolGrayscale = new Dictionary<string, Material>();
    }
}
