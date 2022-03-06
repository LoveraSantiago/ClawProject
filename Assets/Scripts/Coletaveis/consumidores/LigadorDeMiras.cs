public class LigadorDeMiras : Consumidor<Coletavel>
{
    private bool filtrarGaiolas;

    public LigadorDeMiras(bool filtrarGaiolas)
    {
        this.filtrarGaiolas = filtrarGaiolas;
    }

    public void consumir(Coletavel coletavel)
    {
        if (coletavel.isAtivo())
        {
            if (filtrarGaiolas)
            {
                if (coletavel.isLivre())
                {
                    coletavel.ligarAnimacaoMira();
                }
            }
            else
            {
                coletavel.ligarAnimacaoMira();
            }
        }       
    }
}
