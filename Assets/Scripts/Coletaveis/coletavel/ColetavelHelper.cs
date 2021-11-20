using System.Collections.Generic;
using UnityEngine;

public class ColetavelHelper 
{
    private static PoolDeColetaveis poolDeColetaveis;
    private static Dictionary<int, ColetavelEntidade> dicionarioDeIds;
    private static Dictionary<string, ColetavelEntidade> dicionarioDeSprites;
    private static Dictionary<ColetavelEntidade.FAMILIA, List<ColetavelEntidade>> dicionarioDeFamilias;   

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

    public ColetavelTile getColetavelInGameByName(string name)
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

    public ColetavelEntidade getRandomColetavelEntidadeByFamilia(ColetavelEntidade.FAMILIA familia)
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
        return dicionarioDeFamilias[familia];
    }

    public void ligarMiraAlvoFinalNoColetavel(string nomeAlvo)
    {        
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public void ligarMirasNosColetaveis()
    {     
        poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligarMirasNosColetaveis()
    {     
        poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }    

    public ColetavelTile getColetavelMaisAlto()
    {
        ProcuradorColetavelMaisAlto procurador = new ProcuradorColetavelMaisAlto();
        poolDeColetaveis.executeEmTodosColetaveis(procurador);
        return procurador.coletavelMaisAlto;
    }
    
    private static void popularDicionarios()
    {
        ColetavelEntidade[] coletaveisEntidades = ColetavelEntidade.getColetaveisEntidades();
        for (int contador = 0; contador < coletaveisEntidades.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = coletaveisEntidades[contador];

            dicionarioDeIds.Add(coletavelEntidadeIt.id, coletavelEntidadeIt);
            dicionarioDeSprites.Add(coletavelEntidadeIt.nomeSprite, coletavelEntidadeIt);
            addAoDicionarioDeFamilias(coletavelEntidadeIt);
        }        
    }    

    private static void addAoDicionarioDeFamilias(ColetavelEntidade coletavelEntidadeIt)
    {
        if (!dicionarioDeFamilias.ContainsKey(coletavelEntidadeIt.familia))
        {
            dicionarioDeFamilias.Add(coletavelEntidadeIt.familia, new List<ColetavelEntidade>());
        }

        List<ColetavelEntidade> lista = dicionarioDeFamilias[coletavelEntidadeIt.familia];
        lista.Add(coletavelEntidadeIt);
    }    

    public static void configurar()
    {
        if (dicionarioDeIds == null)
        {
            dicionarioDeIds      = new Dictionary<int, ColetavelEntidade>();
            dicionarioDeSprites  = new Dictionary<string, ColetavelEntidade>();
            dicionarioDeFamilias = new Dictionary<ColetavelEntidade.FAMILIA, List<ColetavelEntidade>>();

            popularDicionarios();
        }
    }

    public static void configurar(PoolDeColetaveis poolDeColetaveisArg)
    {
        poolDeColetaveis = poolDeColetaveisArg;
        configurar();
    }
}
