using System.Collections.Generic;
using UnityEngine;

public class EditorLevelHelper 
{
    public static List<string> listaDeNomesMapas { get; private set; }
    public static List<string> listaDeNomesLevelsNaoObstaculos { get; private set; }

    public static void inicializar()
    {
        listaDeNomesMapas = new List<string>();
        listaDeNomesLevelsNaoObstaculos = new List<string>();

        MapaEnum[] mapas = Mapas.getTodosMapas();
        for(int contadorMapas = 0; contadorMapas < mapas.Length; contadorMapas++)
        {
            MapaEnum mapaIt = mapas[contadorMapas];
            listaDeNomesMapas.Add(mapaIt.ToString());
            Debug.Log("Iterando mapa " + mapaIt.ToString());

            MapaEntidade mapaEntidadeIt = FactoryMapaEntidade.getMapaEntidadeByMapaEnum(mapaIt);
            for(int contadorLevels = 1; contadorLevels <= mapaEntidadeIt.getQtdLevels(); contadorLevels++)
            {
                AbstractLevel levelIt = mapaEntidadeIt.getLevel(contadorLevels);

                if (!LevelUtils.isObstaculoLevel(levelIt))
                {
                    listaDeNomesLevelsNaoObstaculos.Add(levelIt.getLevelName());
                }
            }
        }
    }
}
