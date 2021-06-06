public class LigadorDeMiras : ConsumidorDeEvento<ColetavelTile>
{
    public void consumirEvento(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.ligarAnimacaoMira();
        }
    }
}