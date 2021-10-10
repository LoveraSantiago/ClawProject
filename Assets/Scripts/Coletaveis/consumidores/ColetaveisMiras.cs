public class ColetaveisMiras
{
    public void ligarAlvoFinal(string nomeAlvo)
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public void ligar()
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligar()
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.executeEmTodosColetaveis(new DesligadorDeMiras());
    }   
}