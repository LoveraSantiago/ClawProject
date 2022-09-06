public class MapaEntidade 
{
    public int id { get; private set; }
    public string title { get; private set; }
    private string pathSprites;
    private AbstractFornecedorLevels levelFornecedor;
    private AbstractTemporarioMapaColetaveisLevelsFornecedor levelColetavelTemporarioFornecedor;

    public MapaEntidade()
    {   
    }

    public MapaEntidade addInfo(int id, string title)
    {
        this.id = id;
        this.title = title;
        return this;
    }

    public MapaEntidade addPathSprite(string path)
    {
        this.pathSprites = path;
        return this;
    }

    public MapaEntidade addFornecedoresLevels(AbstractFornecedorLevels levelFornecedor, AbstractTemporarioMapaColetaveisLevelsFornecedor levelColetavelTemporarioFornecedor)
    {
        this.levelFornecedor = levelFornecedor;
        this.levelColetavelTemporarioFornecedor = levelColetavelTemporarioFornecedor;
        return this;
    }

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + pathSprites + "/";
    }    

    public AbstractLevel getLevel(int indice)
    {
        if(levelFornecedor != null)
        {
            return levelFornecedor.getLevel(indice);
        }
        return null;
    }

    public int getQtdLevels()
    {
        if(levelFornecedor != null)
        {
            return levelFornecedor.getQtdLevels();
        }
        return 0;
    }

    public AbstractLevel getLevel(ColetavelEntidade coletavelEntidade)
    {
        return levelColetavelTemporarioFornecedor.getLevel(coletavelEntidade);
    }
}
