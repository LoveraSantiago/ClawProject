using System.Collections.Generic;
using UnityEngine;

public class HelperColetavelEntidade 
{
    private static Dictionary<int, ColetavelEntidade> coletaveisPorId;    
    private static Dictionary<string, Sprite> spritesPorNome;
    private static Dictionary<MapaEnum, List<ColetavelEntidade>> familiasPorEnum;

    public static int getIndiceDaFamilia(MapaEnum mapaENum)
    {
        MapaEnum[] arrayDeMapas = Mapas.getTodosMapas();
        for (int contador = 0; contador < arrayDeMapas.Length; contador++)
        {
            if(mapaENum == arrayDeMapas[contador])
            {
                return contador;
            }
        }
        return 0;
    }

    public static Sprite getSpriteColetavelByNomeSprite(string nomeSprite)
    {   
        return spritesPorNome[nomeSprite];
    }

    public static Sprite getSpriteOvo()
    {
        MapaEntidade mapaEntidade = FactoryMapaEntidade.getMapaEntidadeByMapaEnum(MapaEnum.DEFAULTS);
        ColetavelEntidade coletavelEntidadeOvo = mapaEntidade.getColetavelEntidadeByIndice(2);
        return spritesPorNome[coletavelEntidadeOvo.nomeSprite];
    }

    public static Sprite[] getAllSpritesColetaveisOrdenados()
    {
        int totalDefault = familiasPorEnum[MapaEnum.DEFAULTS].Count;
        Sprite[] array = new Sprite[coletaveisPorId.Count - totalDefault];
        int contador = 0;
        foreach(KeyValuePair<MapaEnum, List<ColetavelEntidade>> entry in familiasPorEnum)
        {
            if(entry.Key != MapaEnum.DEFAULTS)
            {
                List <ColetavelEntidade> coletaveis = entry.Value;
                for(int contadorColetavel = 0; contadorColetavel < coletaveis.Count; contadorColetavel++)
                {
                    ColetavelEntidade coletavelIt = coletaveis[contadorColetavel];
                    Sprite sprite = spritesPorNome[coletavelIt.nomeSprite];
                    array[contador] = sprite;
                    contador++;
                }
            }
        }
        return array;
    }       

    public static bool isIndiceVazio(int indice)
    {
        return indice == -1;
    }

    public static bool isIndiceRandom(int indice)
    {
        return indice == -2;
    }

    public static int getIndiceSpriteNaoEncontrado(Sprite sprite)
    {
        if ("tile-random".Equals(sprite.name))
        {
            return -2;
        }
        else
        {
            return -1;
        }
    }
}
