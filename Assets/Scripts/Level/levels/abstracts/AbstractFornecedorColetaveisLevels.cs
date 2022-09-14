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

    protected abstract ColetavelEntidade[] getArrayDeColetaveis();

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + getPathSprite() + "/";
    }

    public abstract string getPathSprite();

    public AbstractLevel getLevel(ColetavelEntidade coletavelEntidade)
    {
        return getLevelToColetavel(coletavelEntidade);
    }

    protected abstract AbstractLevel getLevelToColetavel(ColetavelEntidade coletavelEntidade);

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
            arrayDeColetaveis[contador].setMapaEnum(levelMapDto.MapaEnum);
            ColetavelEntidadeDto coletavelEntidadeIt = levelMapDto.ColetaveisDto[contador];
        }
    }
}
