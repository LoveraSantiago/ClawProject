public abstract class AbstractFornecedorColetaveisLevels
{
    private ColetavelEntidade[] arrayDeColetaveis;

    public ColetavelEntidade getColetavelEntidadeByIndice(int indice, MapaEnum mapaEnum)
    {
        return null;
    }

    private void iniciarArrayDeColetaveis(MapaEnum mapaEnum)
    {
        if(arrayDeColetaveis == null)
        {
            arrayDeColetaveis = getArrayDeColetaveis();
        }
        configurarMapaEnumParaColetaveis(mapaEnum);
    }

    private void configurarMapaEnumParaColetaveis(MapaEnum mapaEnum)
    {
        for (int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            arrayDeColetaveis[contador].setMapaEnum(mapaEnum);
        }
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
}
