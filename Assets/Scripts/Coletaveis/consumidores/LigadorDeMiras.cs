public class LigadorDeMiras : Consumidor<Coletavel>
{
    public void consumir(Coletavel coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.ligarAnimacaoMira();
        }
    }
}
