using System.Collections.Generic;
using UnityEngine;

public class HelperColetaveisInGame 
{
    private static PoolDeColetaveis poolDeColetaveis;
    private static Dictionary<string, Material> poolGrayscale;

    public Coletavel criarColetavel()
    {
        return poolDeColetaveis.criarColetavel();
    }

    public int getQtdColetaveisInGame()
    {
        ContadorDeColetaveisInGame contador = new ContadorDeColetaveisInGame();
        poolDeColetaveis.executeEmTodosColetaveis(contador);
        return contador.qtd;        
    }

    public bool temColetavelInGameByNome(string name)
    {
        return poolDeColetaveis.contemNome(name);
    }

    public Coletavel getColetavelInGameByGoName(string name)
    {
        return poolDeColetaveis.getColetavelPeloGoNome(name);
    }

    public Coletavel[] getColetavelInGameDoTipo(ColetavelEntidade coletavelEntidade)
    {
        return poolDeColetaveis.getTrincaDeColetaveis(coletavelEntidade);
    }

    public Coletavel getColetavelMaisAlto()
    {
        ProcuradorGOMaisAlto<Coletavel> procurador = new ProcuradorGOMaisAlto<Coletavel>();
        poolDeColetaveis.executeEmTodosColetaveis(procurador);
        return procurador.goMaisAlto;
    }    

    public void ligarMiraAlvoFinalNoColetavel(string nomeAlvo)
    {
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public void ligarMirasNosColetaveis(bool filtrarGaiolas)
    {
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras(filtrarGaiolas));
    }

    public void desligarMirasNosColetaveis()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }

    public void fixarTodosColetaveisEixoXY()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());
    }

    public void desafixarTodosColetaveisXY()
    {
        poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
    }

    public bool isAlgumColetavelAcimaDaHaltura(float haltura)
    {
        return poolDeColetaveis.temEmAlgumColetavel(new AcimaHalturaColetavel(haltura));
    }

    public void inativarColetavel(Coletavel coletado)
    {
        poolDeColetaveis.inativarColetavel(coletado);
    }

    public Material getMaterialGrayscaleTo(Coletavel coletavel)
    {
        Sprite spr = coletavel.getSprite();
        if (!poolGrayscale.ContainsKey(spr.name))
        {
            Material material = MaterialGrayScale.of(spr);
            poolGrayscale.Add(spr.name, material);
        }
        return poolGrayscale[spr.name];
    }

    public static Coletavel criarColetavel(string nomeSprite, Vector3 posicao)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();

        Coletavel coletavel = helperInGame.criarColetavel();
        Sprite sprite = helperColetavel.getSpriteColetavelByNomeSprite(nomeSprite);
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
