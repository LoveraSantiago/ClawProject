public class PowerUpInfoFim 
{
    public bool preFinalizar { get; private set; }
    public bool finalizar { get; private set; }

    public bool hasColetavel { get; private set; }

    public ColetavelTile coletavelTile { get; private set; }

    public PowerUpInfoFim(bool preFinalizar, bool finalizar)
    {
        this.preFinalizar = preFinalizar;
        this.finalizar = finalizar;
        hasColetavel = false;
    }

    public void addColetavel(ColetavelTile coletavelTile)
    {
        this.coletavelTile = coletavelTile;
        hasColetavel = true;
    }
}
