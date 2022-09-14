public abstract class AbstractFornecedorColetaveisLevels
{
    private MapaEnum mapaEnum;
    private ColetavelEntidade[] arrayDeColetaveis;    

    public void configurar(MapaEnum mapaEnum)
    {
        this.mapaEnum = mapaEnum;
    }

    public ColetavelEntidade getColetavelEntidadeByIndice(int indice)
    {
        iniciarArrayDeColetaveis();
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

    private void iniciarArrayDeColetaveis()
    {
        if(arrayDeColetaveis == null)
        {
            arrayDeColetaveis = getArrayDeColetaveis();
        }
        configurarMapaEnumParaColetaveis();
    }

    private void configurarMapaEnumParaColetaveis()
    {
        for (int contador = 0; contador < arrayDeColetaveis.Length; contador++)
        {
            arrayDeColetaveis[contador].setMapaEnum(mapaEnum);
        }
    }
}
