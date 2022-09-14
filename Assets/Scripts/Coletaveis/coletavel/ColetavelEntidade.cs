public class ColetavelEntidade 
{
    private static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES;        

    public int id { get; private set; }//Deve ser unico
    public int ordem { get; private set; }
    public string nome { get; private set; }
    public string nomeSprite { get; private set; }//Deve ser unico        
    public MapaEnum mapaEnum { get; private set; }

    public ColetavelEntidade(int id, int ordem, string nome, string nomeSprite)
    {
        this.id         = id;
        this.nome       = nome;
        this.nomeSprite = nomeSprite;             
        this.ordem      = ordem;
    }        

    public void setMapaEnum(MapaEnum mapaEnum)
    {
        this.mapaEnum = mapaEnum;
    }

    public static bool isIndiceVazio(int indice)
    {
        return indice == 10;
    }

    public static bool isIndiceRandom(int indice)
    {
        return indice == 11;
    }
}
