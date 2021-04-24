using System.Collections.Generic;
using UnityEngine;

public class ColetavelQuery 
{
    private Dictionary<int, ColetavelEntidade> dicionarioDeIds;
    private Dictionary<string, ColetavelEntidade> dicionarioDeSprites;

    public ColetavelQuery()
    {
        inicializarDicionarioDeId();
        inicializarDicionarioDeSprites();
    }

    public ColetavelEntidade getColetavelById(int idQuery)
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

    public ColetavelEntidade getColetavelBySprite(string spriteName)
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
}
