using System.Collections.Generic;
using UnityEngine;

public class ColetaveisParaPrateleiras 
{
    public ColetavelEntidade[] coletaveis { get; private set; }
    public Dictionary<Sprite, ColetavelEntidade> dicionarioDeSprites;

    public ColetaveisParaPrateleiras()
    {
        carregarColetaveis();
        inicializarDicionarioDeSprites();
    }

    public ColetavelEntidade getColetavelPeloIndice(int indice)
    {
        return coletaveis[indice];
    }

    public ColetavelEntidade getColetavelPeloSprite(Sprite sprite)
    {
        return dicionarioDeSprites[sprite];
    }

    public int getQtdColetaveis()
    {
        return coletaveis.Length;
    }

    private void carregarColetaveis()
    {
        MapaEntidade[] mapas = HelperMapaEntidade.getMapaEntidadesLiberados(1);
        mapas[mapas.Length - 1].lockar();
        List<ColetavelEntidade> listaDeColetaveis = new List<ColetavelEntidade>();
        for (int contador = 0; contador < mapas.Length; contador++)
        {
            ColetavelEntidade[] coletaveis = mapas[contador].getColetaveis();
            listaDeColetaveis.AddRange(coletaveis);
        }
        coletaveis = listaDeColetaveis.ToArray();
    }

    private void inicializarDicionarioDeSprites()
    {
        dicionarioDeSprites = new Dictionary<Sprite, ColetavelEntidade>();
        for (int contador = 0; contador < coletaveis.Length; contador++)
        {
            ColetavelEntidade coletavelIt = coletaveis[contador];
            dicionarioDeSprites.Add(coletavelIt.sprite, coletavelIt);
        }
    }
}
