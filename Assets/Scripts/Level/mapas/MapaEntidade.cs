public class MapaEntidade 
{
    public int id { get; private set; }
    private string pathSprites;

    public MapaEntidade(int id, string pathSprites)
    {
        this.id = id;
        this.pathSprites = pathSprites;
    }

    public string getRootPathSprites()
    {
        return "sprites/coletaveis/" + pathSprites + "/";
    }    
}
