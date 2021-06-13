public class DesligadorDeMiras : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.desligarAnimacao();
        }
    }
}
