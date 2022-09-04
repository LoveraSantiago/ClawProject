public class MapaEntidade 
{
    public int id { get; private set; }
    public string title { get; private set; }
    private string pathSprites;

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

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + pathSprites + "/";
    }    
}
