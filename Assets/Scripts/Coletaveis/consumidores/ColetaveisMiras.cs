public class ColetaveisMiras
{
    public void ligarAlvoFinal(string nomeAlvo)
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public void ligar()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligar()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeEmTodosColetaveis(new DesligadorDeMiras());
    }   
}