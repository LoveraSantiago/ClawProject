public class MapaEntidade 
{
    public MapaEnum mapaEnum { get; private set; }
    public int id { get; private set; }
    public string title { get; private set; }
    private AbstractFornecedorLevels levelFornecedor = FornecedorLevelsDefault.getInstance();
    private AbstractFornecedorColetaveisLevels coletaveisFornecedor;

    public MapaEntidade(MapaEnum mapaEnum)
    {
        this.mapaEnum = mapaEnum;
    }

    public MapaEntidade addInfo(int id, string title)
    {
        this.id = id;
        this.title = title;
        return this;
    }

    public MapaEntidade addFornecedoresLevels(AbstractFornecedorLevels levelFornecedor)
    {
        this.levelFornecedor = levelFornecedor;        
        return this;
    }

    public MapaEntidade addFornecedoresColetaveis(AbstractFornecedorColetaveisLevels coletaveisFornecedor)
    {
        this.coletaveisFornecedor = coletaveisFornecedor;
        this.coletaveisFornecedor.configurar(mapaEnum);
        return this;
    }

    public string getRootPathSprites()
    {
        return coletaveisFornecedor.getRootPathSprites();
    }    

    public AbstractLevel getLevelByIndiceDezena(int indice)
    {
        return levelFornecedor.getLevelByIndiceDezena(id, indice);        
    }

    public AbstractLevel getLevelByIndiceGeral(int indice)
    {
        return levelFornecedor.getLevelByIndiceGeral(id, indice);
    }

    public int getQtdLevels()
    {
        return levelFornecedor.getQtdLevels();        
    }

    public int getIndiceMaxLevelLiberadoDoMapa()
    {
        return levelFornecedor.getIndiceMaxLevelLiberadoDoMapa(id);
    }

    public AbstractLevel getLevelByColetavelEntidade(ColetavelEntidade coletavelEntidade)
    {
        return coletaveisFornecedor.getLevel(coletavelEntidade);
    }

    public ColetavelEntidade getColetavelEntidadeByIndice(int indice)
    {
        if(coletaveisFornecedor == null)
        {
            return null;
        }
        return coletaveisFornecedor.getColetavelEntidadeByIndice(indice);
    }
}
