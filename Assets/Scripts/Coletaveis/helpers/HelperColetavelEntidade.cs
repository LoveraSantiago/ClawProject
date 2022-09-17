using System.Collections.Generic;
using UnityEngine;

public class HelperColetavelEntidade 
{
    private static Dictionary<int, ColetavelEntidade> coletaveisPorId;
    private static Dictionary<string, ColetavelEntidade> coletaveisPorSpriteNome;
    private static Dictionary<string, Sprite> spritesPorNome;
    private static Dictionary<MapaEnum, List<ColetavelEntidade>> familiasPorEnum;      

    public static ColetavelEntidade getColetavelEntidadeBySprite(string spriteName)
    {     
        if (coletaveisPorSpriteNome.ContainsKey(spriteName))
        {
            return coletaveisPorSpriteNome[spriteName];
        }
        else
        {
            Debug.LogError("O spritename solicitado nao existe: " + spriteName);
            return null;
        }
    }

    public static ColetavelEntidade getRandomColetavelEntidadeByFamilia(MapaEnum mapaENum)
    {
        if (familiasPorEnum.ContainsKey(mapaENum))
        {
            List<ColetavelEntidade> listaDeFamilias = familiasPorEnum[mapaENum];
            int indiceSorteadoDaLista = Random.Range(0, listaDeFamilias.Count);
            return listaDeFamilias[indiceSorteadoDaLista];
        }
        else
        {
            Debug.LogError("A familia solicitada nao existe: " + mapaENum);
            return null;
        }        
    }

    public static List<ColetavelEntidade> getListaDeColetaveisEntidadeByFamiliaExcluindo(ColetavelEntidade coletavel)
    {
        List<ColetavelEntidade> listaFamilia = getListaDeColetaveisEntidadeByFamilia(coletavel.mapaEnum);
        int indiceRemover = 0;
        for(int contador = 0; contador < listaFamilia.Count; contador++)
        {
            if (listaFamilia[contador].nomeSprite.Equals(coletavel.nomeSprite))
            {
                indiceRemover = contador;
                break;
            }
        }
        listaFamilia.RemoveAt(indiceRemover);
        return listaFamilia;
    }
   
    public static List<ColetavelEntidade> getListaDeColetaveisEntidadeByFamilia(MapaEnum mapaENum)
    {
        return new List<ColetavelEntidade>(familiasPorEnum[mapaENum]);
    }    

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
