using UnityEngine;

public class ColetavelEntidade
{
    private static ColetavelEntidade[] ARRAY_COLETAVEIS_ENTIDADES;

    public int id { get; private set; }
    public int ordem { get; private set; }
    public string nome { get; private set; }
    public string nomeSprite { get { return sprite.name; } }
    public Sprite sprite {get; private set;}
    public MapaEnum mapaEnum { get; private set; }

    public ColetavelEntidade(int id, int ordem)
    {
        this.id         = id;        
        this.ordem      = ordem;
    }        

    public void setNome(string nome)
    {
        this.nome = nome;
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public void setMapaEnum(MapaEnum mapaEnum)
    {
        this.mapaEnum = mapaEnum;
    }    
}
