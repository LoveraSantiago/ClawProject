using System;
using System.Collections.Generic;

public class Mapas 
{
    private static MapaEnum[] MAPAS_TODOS;
    private static MapaEnum[] MAPAS_NORMAIS;

    public static MapaEnum[] getTodosMapas()
    {
        if (MAPAS_TODOS == null)
        {
            Array array = Enum.GetValues(typeof(MapaEnum));
            MAPAS_TODOS = new MapaEnum[array.Length];
            for (int contador = 0; contador < array.Length; contador++)
            {
                MAPAS_TODOS[contador] = (MapaEnum)array.GetValue(contador);
            }
        }
        return MAPAS_TODOS;
    }

    public static MapaEnum[] getNormalMapas()
    {
        getTodosMapas();
        if(MAPAS_NORMAIS == null)
        {
            MAPAS_NORMAIS = new MapaEnum[MAPAS_TODOS.Length - 3];

            int contadorMapaFiltrado = 0;
            for(int contadorMapas = 0; contadorMapas < MAPAS_TODOS.Length; contadorMapas++)
            {
                MapaEnum mapaEnumIt = MAPAS_TODOS[contadorMapas];
                if(isNormalMapa(mapaEnumIt))
                {
                    MAPAS_NORMAIS[contadorMapaFiltrado] = MAPAS_TODOS[contadorMapas];
                    contadorMapaFiltrado++;
                }
            }

        }
        return MAPAS_NORMAIS;
    }

    private static bool isNormalMapa(MapaEnum mapaEnum)
    {
        return mapaEnum != MapaEnum.DEFAULTS && mapaEnum != MapaEnum.CACANIQUEL && mapaEnum != MapaEnum.POWERUP;
    }    

    public static MapaEnum getMapaEnumByName(string nomeMapa)
    {
        getTodosMapas();
        for (int contador = 0; contador < MAPAS_TODOS.Length; contador++)
        {
            if (MAPAS_TODOS[contador].ToString().Equals(nomeMapa))
            {
                return MAPAS_TODOS[contador];
            }
        }
        return MapaEnum.DEFAULTS;
    }

    public static MapaEnum getMapaTodosEnumPeloIndice(int indice)
    {
        getTodosMapas();
        return MAPAS_TODOS[indice];
    }

    public static MapaEnum getMapaNormalEnumPeloIndice(int indice)
    {
        getNormalMapas();
        return MAPAS_NORMAIS[indice];
    }
}
