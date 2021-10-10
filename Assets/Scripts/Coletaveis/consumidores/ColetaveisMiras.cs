public class ColetaveisMiras
{
    public void ligar()
    {        
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new LigadorDeMiras());
    }

    public void desligar()
    {        
        ColetavelQuery.poolDeColetaveis.executeEmTodosColetaveis(new DesligadorDeMiras());
    }   
}