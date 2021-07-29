public class FixadorEixosXY : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.fixarEixoXY();            
        }
    }
}