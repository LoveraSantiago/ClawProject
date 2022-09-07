using System.Collections.Generic;
using UnityEngine;

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
        List<string> listaDeNomes = new List<string>(listaEmpty);
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevel(contadorLevels);
            listaDeNomes.Add(levelIt.getLevelName());           
        }
        return listaDeNomes;
    }

    public static List<string> getListaDeNomesLevelsNaoObstaculo(MapaEntidade mapaEntidade)
    {
        List<string> listaDeNomes = new List<string>(listaEmpty);
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevel(contadorLevels);

            if (!LevelUtils.isObstaculoLevel(levelIt))
            {
                listaDeNomes.Add(levelIt.getLevelName());
            }
        }
        return listaDeNomes;
    }

    public static List<string> getListaDenomesLevelsElevadores(MapaEntidade mapaEntidade)
    {
        List<string> listaDeNomes = new List<string>(listaEmpty);
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevel(contadorLevels);

            if (LevelUtils.isElevadorLevel(levelIt))
            {
                listaDeNomes.Add(levelIt.getLevelName());
            }
        }
        return listaDeNomes;
    }

    public static List<string> getListaDenomesLevelsObstaculos(MapaEntidade mapaEntidade)
    {
        List<string> listaDeNomes = new List<string>(listaEmpty);
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevel(contadorLevels);

            if (LevelUtils.isObstaculoLevel(levelIt))
            {
                listaDeNomes.Add(levelIt.getLevelName());
            }
        }
        return listaDeNomes;
    }

    public static AbstractLevel getLevelByNameIndice(string nomeMapaEntidade, string nomeLevel)
    {
        MapaEntidade mapaEntidade = mapasEntidadesPorNomes[nomeMapaEntidade];
        for (int contadorLevels = 1; contadorLevels <= mapaEntidade.getQtdLevels(); contadorLevels++)
        {
            AbstractLevel levelIt = mapaEntidade.getLevel(contadorLevels);
            if (levelIt.getLevelName().Equals(nomeLevel))
            {
                return levelIt;
            }
        }
        return null;
    }
}
