public class ColetaveisMiras
{
    public void ligarAlvoFinal(string nomeAlvo)
    {
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeAlvoFinal(nomeAlvo));
    }

    public void ligar()
    {        
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligar()
    {        
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }   
}