using System.Collections.Generic;
using UnityEngine;
using System;

public class EditorLevelHelper 
{
    public static List<string> listaEmpty { get; private set; }
    public static List<string> listaDeNomesMapas { get; private set; }
    public static Dictionary<string, MapaEntidade> mapasEntidadesPorNomes;

    public static void inicializar()
    {
        listaDeNomesMapas = new List<string>();        

        listaEmpty = new List<string>();
        listaEmpty.Add("-");

        mapasEntidadesPorNomes = new Dictionary<string, MapaEntidade>();

        MapaEnum[] mapas = Mapas.getTodosMapas();
        for(int contadorMapas = 0; contadorMapas < mapas.Length; contadorMapas++)
        {
            MapaEnum mapaIt = mapas[contadorMapas];
            listaDeNomesMapas.Add(mapaIt.ToString());
            //Debug.Log("mapa " + mapaIt.ToString());

            MapaEntidade mapaEntidadeIt = FactoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaIt);
            //Debug.Log("MapaEntidade " + mapaEntidadeIt.title + " levels " + mapaEntidadeIt.getQtdLevels());

            mapasEntidadesPorNomes.Add(mapaIt.ToString(), mapaEntidadeIt);
        }
    }

    public static List<string> getListaDeNomesLevels(MapaEntidade mapaEntidade)
    {
        return recuperarLevels(mapaEntidade, (level) => true);       
    }

    public static List<string> getListaDeNomesLevelsNaoObstaculo(MapaEntidade mapaEntidade)
    {
        return recuperarLevels(mapaEntidade, (level) => !LevelUtils.isObstaculoLevel(level));        
    }

    public static List<string> getListaDenomesLevelsElevadores(MapaEntidade mapaEntidade)
    {
        return recuperarLevels(mapaEntidade, (level) => LevelUtils.isElevadorLevel(level));        
    }

    public static List<string> getListaDenomesLevelsObstaculos(MapaEntidade mapaEntidade)
    {
        return recuperarLevels(mapaEntidade, (level)=> LevelUtils.isObstaculoLevel(level));        
    }

    public static AbstractLevel getLevelByNameIndice(string nomeMapaEntidade, string nomeLevel)
    {
        MapaEntidade mapaEntidade = mapasEntidadesPorNomes[nomeMapaEntidade];
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevelByIndiceDezena(contadorLevels);
            if (levelIt.getLevelName().Equals(nomeLevel))
            {
                return levelIt;
            }
        }
        return null;
    }

    private static List<string> recuperarLevels(MapaEntidade mapaEntidade, Func<AbstractLevel, bool> filtro)
    {        
        List<string> listaDeNomes = new List<string>(listaEmpty);
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevelByIndiceDezena(contadorLevels);
            if (levelIt != null && filtro.Invoke(levelIt))
            {
                listaDeNomes.Add(levelIt.getLevelName());
            }
        }

        for (int contador = 0; contador < mapaEntidade.getColetaveis().Length; contador++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevelColetavelByIndice(contador);
            if (levelIt != null && filtro.Invoke(levelIt))
            {
                
                listaDeNomes.Add(levelIt.getLevelName());
                
            }
        }
        return listaDeNomes;
    }  

}
