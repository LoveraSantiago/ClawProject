public class AcimaHalturaColetavel : Predicate<ColetavelTile>
{
    private float alturaLimite;

    public AcimaHalturaColetavel(float alturaLimite)
    {
        this.alturaLimite = alturaLimite;
    }

    public bool test(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            return coletavel.getPosicao().y >= alturaLimite;
        }
        return false;
    }
}
