using System.Collections.Generic;
using UnityEngine;

public class ColetavelQuery 
{
    private static PoolDeColetaveis poolDeColetaveis;

    private Dictionary<int, ColetavelEntidade> dicionarioDeIds;
    private Dictionary<string, ColetavelEntidade> dicionarioDeSprites;
    private Dictionary<ColetavelEntidade.FAMILIA, List<ColetavelEntidade>> dicionarioDeFamilias;

    public ColetavelQuery()
    {
        inicializarDicionarioDeId();
        inicializarDicionarioDeSprites();
        inicializarDicionarioDeFamilias();
    }

    public ColetavelEntidade getColetavelEntidadeById(int idQuery)
    {   
        if (dicionarioDeIds.ContainsKey(idQuery))
        {
            return dicionarioDeIds[idQuery];
        }
        else
        {
            Debug.LogError("O id solicitado nao existe: " + idQuery);
            return null;
        }
    }

    public Coletavel getColetavelInGameByName(string name)
    {
        return poolDeColetaveis.getColetavelPeloNome(name);
    }

    public ColetavelEntidade getColetavelEntidadeBySprite(string spriteName)
    {     
        if (dicionarioDeSprites.ContainsKey(spriteName))
        {
            return dicionarioDeSprites[spriteName];
        }
        else
        {
            Debug.LogError("O spritename solicitado nao existe: " + spriteName);
            return null;
        }
    }

    public ColetavelEntidade getColetavelEntidadeByFamilia(ColetavelEntidade.FAMILIA familia)
    {
        if (dicionarioDeFamilias.ContainsKey(familia))
        {
            List<ColetavelEntidade> listaDeFamilias = dicionarioDeFamilias[familia];
            int indiceSorteadoDaLista = Random.Range(0, listaDeFamilias.Count);
            return listaDeFamilias[indiceSorteadoDaLista];
        }
        else
        {
            Debug.LogError("A familia solicitada nao existe: " + familia);
            return null;
        }        
    }

    //TODO AGRUPAR TODOS EM UM UNICO FOR MELHOR PERFORMANCE
    private void inicializarDicionarioDeId()
    {   
        dicionarioDeIds = new Dictionary<int, ColetavelEntidade>();
        for (int contador = 0; contador < ColetavelEntidade.ARRAY_COLETAVEIS_ENTIDADES.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = ColetavelEntidade.ARRAY_COLETAVEIS_ENTIDADES[contador];
            dicionarioDeIds.Add(coletavelEntidadeIt.id, coletavelEntidadeIt);
        }        
    }

    private void inicializarDicionarioDeSprites()
    {        
        dicionarioDeSprites = new Dictionary<string, ColetavelEntidade>();
        for (int contador = 0; contador < ColetavelEntidade.ARRAY_COLETAVEIS_ENTIDADES.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = ColetavelEntidade.ARRAY_COLETAVEIS_ENTIDADES[contador];
            dicionarioDeSprites.Add(coletavelEntidadeIt.nomeSprite, coletavelEntidadeIt);
        }        
    }

    private void inicializarDicionarioDeFamilias()
    {
        dicionarioDeFamilias = new Dictionary<ColetavelEntidade.FAMILIA, List<ColetavelEntidade>>();
        for (int contador = 0; contador < ColetavelEntidade.ARRAY_COLETAVEIS_ENTIDADES.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = ColetavelEntidade.ARRAY_COLETAVEIS_ENTIDADES[contador];
            if (!dicionarioDeFamilias.ContainsKey(coletavelEntidadeIt.familia))
            {
                dicionarioDeFamilias.Add(coletavelEntidadeIt.familia, new List<ColetavelEntidade>());
            }

            List<ColetavelEntidade> lista = dicionarioDeFamilias[coletavelEntidadeIt.familia];
            lista.Add(coletavelEntidadeIt);
        }
    }

    public static void inicializarDicionarioDeColetaveisInGame(PoolDeColetaveis poolDeColetaveisArg)
    {
        poolDeColetaveis = poolDeColetaveisArg;
    }
}
