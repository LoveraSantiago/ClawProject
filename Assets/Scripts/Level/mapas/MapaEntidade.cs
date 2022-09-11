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

    public AbstractLevel getLevelByIndiceDezena(int indice)
    {
        if(levelFornecedor != null)
        {
            AbstractLevel level = levelFornecedor.getLevel(indice);
            level.setIndiceLevelAtual(((10 * id) - 10) + indice);
            return level;
        }
        return null;
    }

    public AbstractLevel getLevelByIndiceGeral(int indice)
    {
        int indiceLevel = (indice + 1) % 11;
        return getLevelByIndiceDezena(indiceLevel);
    }

    public int getQtdLevels()
    {
        if(levelFornecedor != null)
        {
            return levelFornecedor.getQtdLevels();
        }
        return 0;
    }

    public int getIndiceLevelsLiberado()
    {
        int maxLevelLiberado = PlayerPrefsMapas.getIndiceLevelLiberado();
        if((id * 10) <= maxLevelLiberado)
        {
            return 10; 
        }
        maxLevelLiberado = maxLevelLiberado % 10;
        if(maxLevelLiberado == 0)
        {
            return 1;
        }
        return maxLevelLiberado;         
    }

    public AbstractLevel getLevelByColetavelEntidade(ColetavelEntidade coletavelEntidade)
    {
        return levelColetavelTemporarioFornecedor.getLevel(coletavelEntidade);
    }
}
