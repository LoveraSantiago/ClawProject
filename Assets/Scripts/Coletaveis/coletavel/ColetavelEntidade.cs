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
        this.mapaEnum   = mapaEnum;        
        this.ordem      = ordem;
    }    

    public bool isVazio()
    {
        return id == 0;
    }

    public bool isRandom()
    {
        return id == 1;
    }

    public void setMapaEnum(MapaEnum mapaEnum)
    {
        this.mapaEnum = mapaEnum;
    }
}
