using UnityEngine;

public class ColetavelEntidade
{
    public int indice { get; private set; }
    public bool isAdquirido { get; private set; }
    public bool isExclamacao { get; private set; }
    public string nome { get { return coletavelEntidadeDto.Nome; } }
    public string nomeSprite { get { return sprite.name; } }
    public Sprite sprite { get { return coletavelEntidadeDto.Sprite; } }

    public MapaEntidade mapaEntidade { get; private set; }
    private ColetavelEntidadeDto coletavelEntidadeDto;

    public ColetavelEntidade(int indice, ColetavelEntidadeDto coletavelEntidadeDto)
    {
        this.indice = indice;
        this.coletavelEntidadeDto = coletavelEntidadeDto;
    }            

    public void setMapaEntidade(MapaEntidade mapaEntidade)
    {
        this.mapaEntidade = mapaEntidade;
    }

    public void adquirir(bool estado)
    {
        isAdquirido = estado;
    }

    public void exclamar(bool estado)
    {
        isExclamacao = estado;
    }

    public static bool isIndiceVazio(int indice)
    {
        return indice == -1;
    }

    public static bool isIndiceRandom(int indice)
    {
        return indice == -2;
    }   
}
