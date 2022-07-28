using System.Collections.Generic;
using UnityEngine;

public class HelperColetavelEntidade 
{
    private static Dictionary<int, ColetavelEntidade> coletaveisPorId;
    private static Dictionary<string, ColetavelEntidade> coletaveisPorSpriteNome;
    private static Dictionary<string, Sprite> spritesPorNome;
    private static Dictionary<ColetavelEntidade.FAMILIA, List<ColetavelEntidade>> familiasPorEnum;   

    public ColetavelEntidade getColetavelEntidadeById(int idQuery)
    {   
        if (coletaveisPorId.ContainsKey(idQuery))
        {
            return coletaveisPorId[idQuery];
        }
        else
        {
            Debug.LogError("O id solicitado nao existe: " + idQuery);
            return null;
        }
    }

    public ColetavelEntidade getColetavelEntidadeBySprite(string spriteName)
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

    public ColetavelEntidade getRandomColetavelEntidadeByFamilia(ColetavelEntidade.FAMILIA familia)
    {
        if (familiasPorEnum.ContainsKey(familia))
        {
            List<ColetavelEntidade> listaDeFamilias = familiasPorEnum[familia];
            int indiceSorteadoDaLista = Random.Range(0, listaDeFamilias.Count);
            return listaDeFamilias[indiceSorteadoDaLista];
        }
        else
        {
            Debug.LogError("A familia solicitada nao existe: " + familia);
            return null;
        }        
    }

    public List<ColetavelEntidade> getListaDeColetaveisEntidadeByFamiliaExcluindo(ColetavelEntidade coletavel)
    {
        List<ColetavelEntidade> listaFamilia = getListaDeColetaveisEntidadeByFamilia(coletavel.familia);
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

    public List<ColetavelEntidade> getListaDeColetaveisEntidadeByFamilia(ColetavelEntidade.FAMILIA familia)
    {
        return new List<ColetavelEntidade>(familiasPorEnum[familia]);
    }    

    public int getIndiceDaFamilia(ColetavelEntidade.FAMILIA familia)
    {
        ColetavelEntidade.FAMILIA[] familias = ColetavelEntidade.getFamiliasDeColetaveis();
        for(int contador = 0; contador < familias.Length; contador++)
        {
            if(familia == familias[contador])
            {
                return contador;
            }
        }
        return 0;
    }

    public Sprite getSpriteColetavelByNomeSprite(string nomeSprite)
    {   
        return spritesPorNome[nomeSprite];
    }

    public Sprite getSpriteOvo()
    {
        ColetavelEntidade coletavelEntidadeOvo = getColetavelEntidadeById(2);
        return spritesPorNome[coletavelEntidadeOvo.nomeSprite];
    }

    public Sprite[] getAllSpritesColetaveisOrdenados()
    {
        int totalDefault = familiasPorEnum[ColetavelEntidade.FAMILIA.DEFAULTS].Count;
        Sprite[] array = new Sprite[coletaveisPorId.Count - totalDefault];
        int contador = 0;
        foreach(KeyValuePair<ColetavelEntidade.FAMILIA, List<ColetavelEntidade>> entry in familiasPorEnum)
        {
            if(entry.Key != ColetavelEntidade.FAMILIA.DEFAULTS)
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

    public static void configurar()
    {
        if (coletaveisPorId == null)
        {
            MontadorDicionariosColetaveis montador = new MontadorDicionariosColetaveis();
            montador.montarDicionariosDeColetaveis();
            coletaveisPorId      = montador.dicionarioDeIds;
            coletaveisPorSpriteNome  = montador.dicionarioDeSprites;
            familiasPorEnum = montador.dicionarioDeFamilias;
        }
    }

    public static void configurar(GameObject goPrefabSprites)
    {     
        PrefabDeSpriteDto prefabSpritesDto = goPrefabSprites.GetComponent<PrefabDeSpriteDto>();
        spritesPorNome = prefabSpritesDto.getDicionarioDeSprites();
        configurar();
    }    
}
