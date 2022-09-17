using UnityEngine;

public abstract class AbstractFornecedorColetaveisLevels
{
    private ColetavelEntidade[] arrayDeColetaveis;
    
    public ColetavelEntidade getColetavelEntidadeByIndice(int indice, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(levelMapDto);
        if(indice < 0 || indice > arrayDeColetaveis.Length)
        {
            return arrayDeColetaveis[0];
        }
        return arrayDeColetaveis[indice];
    }

    public ColetavelEntidade getColetavelEntidadeBySprite(Sprite sprite, LevelMapDto levelMapDto)
    {
        int indice = getIndiceColetavelEntidadeBySprite(sprite, levelMapDto);
        return getColetavelEntidadeByIndice(indice, levelMapDto);
    }

    public ColetavelEntidade getColetavelEntidadeBySpriteNome(string nomeSprite, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(levelMapDto);
        for (int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = arrayDeColetaveis[contador];
            if (coletavelEntidadeIt.sprite.name.Equals(nomeSprite))
            {
                return coletavelEntidadeIt;
            }
        }
        return getColetavelEntidadeByIndice(0, levelMapDto);
    }

    public int getIndiceColetavelEntidadeBySprite(Sprite sprite, LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(levelMapDto);
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

    protected abstract ColetavelEntidade[] getArrayDeColetaveis();    

    public AbstractLevel getLevel(int indice)
    {
        return getLevelToColetavel(indice);
    }

    protected abstract AbstractLevel getLevelToColetavel(int indice);

    public ColetavelEntidade[] getColetaveis(LevelMapDto levelMapDto)
    {
        iniciarArrayDeColetaveis(levelMapDto);
        return arrayDeColetaveis;
    }

    private void iniciarArrayDeColetaveis(LevelMapDto levelMapDto)
    {
        if(arrayDeColetaveis == null)
        {
            arrayDeColetaveis = getArrayDeColetaveis();
        }
        configurarColetaveis(levelMapDto);
    }

    private void configurarColetaveis(LevelMapDto levelMapDto)
    {
        for (int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            ColetavelEntidade coletavelEntidadeIt = arrayDeColetaveis[contador];
            coletavelEntidadeIt.setMapaEnum(levelMapDto.MapaEnum);

            ColetavelEntidadeDto coletavelEntidadeDtoIt = levelMapDto.ColetaveisDto[contador];
            coletavelEntidadeIt.setNome(coletavelEntidadeDtoIt.Nome);
            coletavelEntidadeIt.setSprite(coletavelEntidadeDtoIt.Sprite);
        }
    }
}
