public class AcimaHalturaColetavel : Predicate<Coletavel>
{
    private float alturaLimite;

    public AcimaHalturaColetavel(float alturaLimite)
    {
        this.alturaLimite = alturaLimite;
    }

    public bool test(Coletavel coletavel)
    {
        if (coletavel.isAtivo())
        {
            return coletavel.getPosicao().y >= alturaLimite;
        }
        return false;
    }
}
