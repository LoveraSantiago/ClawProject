using System.Collections.Generic;
using UnityEngine;

public class ColetavelEntidade 
{
    public enum FAMILIA { DEFAULTS, FRUTAS, }

    public int id { get; private set; }//Deve ser unico
    public string nome { get; private set; }
    public string nomeSprite { get; private set; }//Deve ser unico
    public FAMILIA familia { get; private set; }

    private Dictionary<int, ColetavelEntidade> dicionarioDeIds;
    private Dictionary<string, ColetavelEntidade> dicionarioDeSprites;

    public ColetavelEntidade(int id, string nome, string nomeSprite, FAMILIA familia)
    {
        this.id = id;
        this.nome = nome;
        this.nomeSprite = nomeSprite;
        this.familia = familia;
    }

    public static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES = new ColetavelEntidade[] {
        new ColetavelEntidade(0, "vazio", "tile-vazio", FAMILIA.DEFAULTS),//Range de 0 a 9 pra defaults
        new ColetavelEntidade(1, "random", "tile-random", FAMILIA.DEFAULTS),

        new ColetavelEntidade(10, "leite", "characters_0001", FAMILIA.FRUTAS),//Range de 10 a 19 frutas
        new ColetavelEntidade(11, "maca", "characters_0002", FAMILIA.FRUTAS),
        new ColetavelEntidade(12, "laranja", "characters_0003", FAMILIA.FRUTAS),
        new ColetavelEntidade(13, "pao", "characters_0004", FAMILIA.FRUTAS),
        new ColetavelEntidade(14, "aspargo?", "characters_0005", FAMILIA.FRUTAS),
        new ColetavelEntidade(15, "coco", "characters_0006", FAMILIA.FRUTAS),
        new ColetavelEntidade(16, "estrelamarinha?", "characters_0007", FAMILIA.FRUTAS)
    };

    public ColetavelEntidade getColetavelById(int idQuery)
    {
        inicializarDicionarioDeId();
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
        inicializarDicionarioDeSprites();
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
        if (dicionarioDeIds == null)
        {
            dicionarioDeIds = new Dictionary<int, ColetavelEntidade>();
            for (int contador = 0; contador < ARRAY_COLETAVEIS_ENTIDADES.Length; contador++)
            {
                ColetavelEntidade coletavelEntidadeIt = ARRAY_COLETAVEIS_ENTIDADES[contador];
                dicionarioDeIds.Add(coletavelEntidadeIt.id, coletavelEntidadeIt);
            }
        }
    }

    private void inicializarDicionarioDeSprites()
    {
        if (dicionarioDeSprites == null)
        {
            dicionarioDeSprites = new Dictionary<string, ColetavelEntidade>();
            for (int contador = 0; contador < ARRAY_COLETAVEIS_ENTIDADES.Length; contador++)
            {
                ColetavelEntidade coletavelEntidadeIt = ARRAY_COLETAVEIS_ENTIDADES[contador];
                dicionarioDeSprites.Add(coletavelEntidadeIt.nomeSprite, coletavelEntidadeIt);
            }
        }
    }
}
