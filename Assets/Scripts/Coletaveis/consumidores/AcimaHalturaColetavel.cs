public class AcimaHalturaColetavel : Predicate<Coletavel>
{
    private float alturaLimite;

    public AcimaHalturaColetavel(float alturaLimite)
    {
        this.alturaLimite = alturaLimite;
    }

    public bool test(Coletavel coletavel)
    {
        return coletavel.isAtivo() && 
             isAcimaPosicao(coletavel) &&
             (!coletavel.isImantado());         
    }

    private bool isAcimaPosicao(Coletavel coletavel)
    {
        return coletavel.getPosicao().y >= alturaLimite;
    }    
}
