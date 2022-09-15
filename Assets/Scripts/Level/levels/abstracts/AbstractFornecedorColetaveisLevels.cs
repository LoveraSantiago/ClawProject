public abstract class AbstractFornecedorColetaveisLevels
{    
    public ColetavelEntidade[] arrayDeColetaveis { get; private set; }
    
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
            ColetavelEntidade coletavelEntidadeIt = arrayDeColetaveis[contador];
            coletavelEntidadeIt.setMapaEnum(levelMapDto.MapaEnum);

            ColetavelEntidadeDto coletavelEntidadeDtoIt = levelMapDto.ColetaveisDto[contador];
            coletavelEntidadeIt.setNome(coletavelEntidadeDtoIt.Nome);
            coletavelEntidadeIt.setSprite(coletavelEntidadeDtoIt.Sprite);
        }
    }
}
