public class ColetavelConsumer 
{
    public static Consumidor<ColetavelTile> desligarAnimacoes()
    {
        return new DesligadorDeMiras();
    }

    private class DesligadorDeMiras : Consumidor<ColetavelTile>
    {
        public void consumir(ColetavelTile coletavel)
        {
            if (coletavel.isAtivo())
            {
                coletavel.desligarAnimacao();
            }
        }
    }

    private class LigadorDeAlvoFinal : Consumidor<ColetavelTile>
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

}
