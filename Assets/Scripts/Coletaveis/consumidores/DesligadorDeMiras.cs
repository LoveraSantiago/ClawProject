public class DesligadorDeMiras : Consumidor<Coletavel>
{
    public void consumir(Coletavel coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.ligarAnimacaoIdle();
        }
    }
}
