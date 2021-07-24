using System.Collections.Generic;

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
        new ColetavelEntidade(0, "vazio" , "tile-vazio" , FAMILIA.DEFAULTS),//Range de 0 a 9 pra defaults
        new ColetavelEntidade(1, "random", "tile-random", FAMILIA.DEFAULTS),

        new ColetavelEntidade(10, "leite"          , "characters_0001", FAMILIA.FRUTAS),//Range de 10 a 19 frutas
        new ColetavelEntidade(11, "maca"           , "characters_0002", FAMILIA.FRUTAS),
        new ColetavelEntidade(12, "laranja"        , "characters_0003", FAMILIA.FRUTAS),
        new ColetavelEntidade(13, "pao"            , "characters_0004", FAMILIA.FRUTAS),
        new ColetavelEntidade(14, "aspargo?"       , "characters_0005", FAMILIA.FRUTAS),
        new ColetavelEntidade(15, "coco"           , "characters_0006", FAMILIA.FRUTAS),
        new ColetavelEntidade(16, "estrelamarinha?", "characters_0007", FAMILIA.FRUTAS)
    };

    public bool isVazio()
    {
        return id == 0;
    }

    public bool isRandom()
    {
        return id == 1;
    }
}
