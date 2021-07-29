public class LigadorDeMiras : Consumidor<ColetavelTile>
{
    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.ligarAnimacaoMira();
        }
    }
}