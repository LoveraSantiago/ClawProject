using UnityEngine;

public class ColetavelEntidade
{
    public int indice { get; private set; }
    public string nome { get { return coletavelEntidadeDto.Nome; } }
    public string nomeSprite { get { return sprite.name; } }
    public Sprite sprite { get { return coletavelEntidadeDto.Sprite; } }

    public MapaEntidade mapaEntidade { get; private set; }
    private ColetavelEntidadeDto coletavelEntidadeDto;

    public ColetavelEntidade(int indice, ColetavelEntidadeDto coletavelEntidadeDto)
    {
        this.indice = indice;                     
    }            

    public void setMapaEntidade(MapaEntidade mapaEntidade)
    {
        this.mapaEntidade = mapaEntidade;
    }    
}
