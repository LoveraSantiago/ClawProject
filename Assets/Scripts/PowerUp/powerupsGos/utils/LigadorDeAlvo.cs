public class LigadorDeAlvo : ConsumidorDeEvento<ColetavelTile>
{
    private string nameAlvo;

    public LigadorDeAlvo(string nameAlvo)
    {
        this.nameAlvo = nameAlvo;
    }

    public void consumirEvento(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            if (coletavel.nome.Equals(nameAlvo))
            {
                coletavel.ligarAnimacaoMiraSelecionado();
            }
            else
            {
                coletavel.desligarAnimacao();
            }
        }
    }
}