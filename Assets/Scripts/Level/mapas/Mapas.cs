using System;
using System.Collections.Generic;

public class Mapas 
{
    private static MapaEnum[] MAPAS;

    public static MapaEnum[] getTodosMapas()
    {
        if (MAPAS == null)
        {
            Array array = Enum.GetValues(typeof(MapaEnum));
            MAPAS = new MapaEnum[array.Length];
            for (int contador = 0; contador < array.Length; contador++)
            {
                MAPAS[contador] = (MapaEnum)array.GetValue(contador);
            }
        }
        return MAPAS;
    }

    public static List<string> getTodosOsMapasAsListString()
    {
        getTodosMapas();
        List<string> lista = new List<string>(MAPAS.Length);
        for (int contador = 0; contador < MAPAS.Length; contador++)
        {
            lista.Add(MAPAS[contador].ToString());
        }
        return lista;
    }

    public static MapaEnum getEnumByName(string nomeMapa)
    {
        getTodosMapas();
        for (int contador = 0; contador < MAPAS.Length; contador++)
        {
            if (MAPAS[contador].ToString().Equals(nomeMapa))
            {
                return MAPAS[contador];
            }
        }
        return MapaEnum.DEFAULTS;
    }

    public static MapaEnum getMapaEnumPeloIndice(int indice)
    {
        getTodosMapas();
        return MAPAS[indice];
    }
}
