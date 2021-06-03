public class DesligadorDeMiras : ConsumidorDeEvento<ColetavelTile>
{
    public void consumirEvento(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.desligarAnimacao();
        }
    }
}
