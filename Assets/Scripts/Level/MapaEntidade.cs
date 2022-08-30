using System;

public class MapaEntidade 
{
    private static MapaEnum[] MAPAS;

    public static MapaEnum[] getTodosMapas()
    {
        if(MAPAS == null)
        {
            Array array = Enum.GetValues(typeof(MapaEnum));
            MAPAS = new MapaEnum[array.Length];
            for(int contador = 0; contador < array.Length; contador++)
            {
                MAPAS[contador] = (MapaEnum)array.GetValue(contador);
            }
        }
        return MAPAS;
    }
}
