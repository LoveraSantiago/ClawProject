public class AcimaHalturaColetavel : Predicate<ColetavelTile>
{
    private float alturaLimite;

    public AcimaHalturaColetavel(float alturaLimite)
    {
        this.alturaLimite = alturaLimite;
    }

    public bool test(ColetavelTile coletavel)
    {
        return coletavel.getPosicao().y >= alturaLimite;
    }
}
