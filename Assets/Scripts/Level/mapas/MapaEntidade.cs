public class MapaEntidade 
{
    public int id { get; private set; }
    public string title { get; private set; }
    private string pathSprites;

    public MapaEntidade(int id, string title, string pathSprites)
    {
        this.id = id;
        this.pathSprites = pathSprites;
        this.title = title;
    }

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + pathSprites + "/";
    }    
}
