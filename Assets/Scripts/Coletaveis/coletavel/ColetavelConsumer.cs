public class ColetavelConsumer 
{
    public static Consumidor<Coletavel> desligarAnimacoes()
    {
        return new DesligadorDeMiras();
    }

    private class DesligadorDeMiras : Consumidor<Coletavel>
    {
        public void consumir(Coletavel coletavel)
        {
            if (coletavel.isAtivo())
            {
                coletavel.desligarAnimacao();
            }
        }
    }

    private class LigadorDeAlvoFinal : Consumidor<Coletavel>
    {
        private string nameAlvo;

        public LigadorDeAlvoFinal(string nameAlvo)
        {
            this.nameAlvo = nameAlvo;
        }

        public void consumir(Coletavel coletavel)
        {
            if (coletavel.isAtivo())
            {
                if (coletavel.nome.Equals(nameAlvo))
                {
                    coletavel.ligarAnimacaoMiraSelecionado();
                }
                else if (coletavel.isMiraSelecionada)
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
