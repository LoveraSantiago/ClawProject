using UnityEngine;

public abstract class AbstractFornecedorColetaveisLevels
{
    private ColetavelEntidade[] arrayDeColetaveis;
    
    public ColetavelEntidade getColetavelEntidadeByIndice(int indice, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        if(indice < 0 || indice > arrayDeColetaveis.Length)
        {
            return arrayDeColetaveis[0];
        }
        return arrayDeColetaveis[indice];
    }

    public ColetavelEntidade getColetavelEntidadeBySprite(Sprite sprite, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        int indice = getIndiceColetavelEntidadeBySprite(sprite, mapaEntidade, levelMapDto);
        return getColetavelEntidadeByIndice(indice, mapaEntidade, levelMapDto);
    }

    public ColetavelEntidade getColetavelEntidadeBySpriteNome(string nomeSprite, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        for (int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = arrayDeColetaveis[contador];
            if (coletavelEntidadeIt.sprite.name.Equals(nomeSprite))
            {
                return coletavelEntidadeIt;
            }
        }
        return getColetavelEntidadeByIndice(0, mapaEntidade, levelMapDto);
    }

    public int getIndiceColetavelEntidadeBySprite(Sprite sprite, MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        for(int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = arrayDeColetaveis[contador];
            if(coletavelEntidadeIt.sprite == sprite)
            {
                return contador;
            }
        }
        return HelperColetavelEntidade.getIndiceSpriteNaoEncontrado(sprite);
    }    

    public AbstractLevel getLevel(int indice)
    {
        return getLevelToColetavel(indice);
    }

    protected abstract AbstractLevel getLevelToColetavel(int indice);

    public ColetavelEntidade[] getColetaveis(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(mapaEntidade, levelMapDto);
        return arrayDeColetaveis;
    }

    private void iniciarArrayDeColetaveis(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        if(arrayDeColetaveis == null)
        {            
            configurarColetaveis(mapaEntidade, levelMapDto);
        }
    }

    private void configurarColetaveis(MapaEntidade mapaEntidade, LevelMapDto levelMapDto)
    {
        int qtdColetaveisDto = levelMapDto.ColetaveisDto.Length;

        arrayDeColetaveis = new ColetavelEntidade[qtdColetaveisDto];

        for (int contador = 0; contador < qtdColetaveisDto; contador++)
        {

            ColetavelEntidadeDto coletavelEntidadeDtoIt = levelMapDto.ColetaveisDto[contador];

            ColetavelEntidade coletavelEntidadeIt = new ColetavelEntidade(contador, coletavelEntidadeDtoIt);
            coletavelEntidadeIt.setMapaEntidade(mapaEntidade);
            arrayDeColetaveis[contador] = coletavelEntidadeIt;
        }
    }
}
