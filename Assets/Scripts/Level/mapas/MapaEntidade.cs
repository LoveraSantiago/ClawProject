public class MapaEntidade 
{
    public int id { get; private set; }
    public string title { get; private set; }
    private string pathSprites;
    private AbstractMapaLevelFornecedor levelFornecedor;

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

    public MapaEntidade addSupplierLevels(AbstractMapaLevelFornecedor levelFornecedor)
    {
        this.levelFornecedor = levelFornecedor;
        return this;
    }

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + pathSprites + "/";
    }    

    public AbstractLevel getLevel(int indice)
    {
        return levelFornecedor.getLevel(indice);
    }
}
