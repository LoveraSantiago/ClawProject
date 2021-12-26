public class LigadorDeAlvoFinal : Consumidor<ColetavelTile>
{
    private string nameAlvo;

    public LigadorDeAlvoFinal(string nameAlvo)
    {
        this.nameAlvo = nameAlvo;
    }

    public void consumir(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            if (coletavel.nome.Equals(nameAlvo))
            {
                coletavel.ligarAnimacaoMiraSelecionado();
            }
            else if (coletavel.isMiraSelecionada())
            {

            }
            else
            {
                coletavel.desligarAnimacao();
            }
        }
    }
}